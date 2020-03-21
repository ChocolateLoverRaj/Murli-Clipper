using System;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

using iText.Kernel.Pdf;
using iText.Kernel.Geom;
using iText.IO.Image;
using iText.Kernel.Pdf.Canvas;
using Ghostscript.NET;
using System.Drawing.Drawing2D;

namespace Murli_Clipper
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        private bool isEven(int num)
        {
            return (num / 2) * 2 == num;
        }

        private string tempPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "./temp");
        private string resPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "./res");

        public Form1()
        {
            InitializeComponent();

            //Delete old temporary files
            string[] files = Directory.GetFiles(tempPath);
            for (var i = 0; i < files.Length; i++)
            {
                File.Delete(files[i]);
            }
        }

        //Change to a tab
        private int currentTab = 0;
        private void changeToTab(int tabNumber)
        {
            //Change to tab
            currentTab = tabNumber;
            tabControl1.SelectedTab = tabControl1.TabPages[tabNumber];
        }

        private void tabChangeAttempted(object sender, TabControlCancelEventArgs e)
        {
            //Check if it is the selected tab
            if (e.TabPageIndex != currentTab)
            {
                e.Cancel = true;
            }
        }

        //Open source dialog;
        private OpenFileDialog srcDialog = new OpenFileDialog();
        private void srcDialogClicked(object sender, EventArgs e)
        {
            srcDialog.Filter = "Pdf Files (*.pdf)|*.pdf|All files (*.*)|*.*";
            if (srcDialog.ShowDialog() == DialogResult.OK)
            {
                srcPath.Text = srcDialog.FileName;
                validateSrcPath();
            }
        }

        private void srcPathChanged(object sender, EventArgs e)
        {
            validateSrcPath();
        }

        //Validate srcPath
        private PdfReader reader;
        private PdfDocument document;
        private void validateSrcPath()
        {
            //Check if file exists
            if (File.Exists(srcPath.Text) && System.IO.Path.GetExtension(srcPath.Text) == ".pdf")
            {
                //Check if pdf has 21 pages
                reader = new PdfReader(srcPath.Text);
                document = new PdfDocument(reader);

                if (document.GetNumberOfPages() == 21)
                {
                    srcValidity.Text = "Path Is Valid";
                    srcValidity.ForeColor = Color.Green;
                    step1Next.Enabled = true;
                }
                else
                {
                    srcValidity.Text = "Pdf Doesn't Have 21 Pages";
                    srcValidity.ForeColor = Color.Red;
                    step1Next.Enabled = false;
                }
            }
            else
            {
                srcValidity.Text = "Not a Valid Path";
                srcValidity.ForeColor = Color.Red;
                step1Next.Enabled = false;
            }
        }

        private void step1Done(object sender, EventArgs e)
        {
            //Next tab
            changeToTab(1);
        }

        private void step2Back(object sender, EventArgs e)
        {
            //Previous tab
            changeToTab(0);
        }

        private void step2Done(object sender, EventArgs e)
        {
            //Next tab
            changeToTab(2);
            //Update
            tabControl1.Update();
            //Start step 3
            startStep3();
        }

        //Start generating images
        private const int x_dpi = 400;
        private const int y_dpi = 400;
        private GhostscriptImageDeviceResolution resolution = new GhostscriptImageDeviceResolution(x_dpi, y_dpi);
        GhostscriptPngDevice device = new GhostscriptPngDevice(GhostscriptPngDeviceType.PngGray);

        private System.Drawing.Image[] images = new System.Drawing.Image[14];

        private void startStep3()
        {
            device.GraphicsAlphaBits = GhostscriptImageDeviceAlphaBits.V_4;
            device.TextAlphaBits = GhostscriptImageDeviceAlphaBits.V_4;
            device.ResolutionXY = resolution;
            device.InputFiles.Add(srcPath.Text);
            device.CustomSwitches.Add("-dDOINTERPOLATE");

            int[] pageOrder = { 1, 3, 4, 6, 7, 9, 10, 12, 13, 15, 16, 18, 19, 21 };
            int photosSaved = 0;
            while (photosSaved < 14)
            {
                //Get photo
                device.OutputPath = System.IO.Path.Combine(tempPath, "./" + photosSaved + ".png");
                device.Pdf.FirstPage = pageOrder[photosSaved];
                device.Pdf.LastPage = pageOrder[photosSaved];
                device.Process();

                //Get image from file system
                images[photosSaved] = System.Drawing.Image.FromFile(device.OutputPath);

                //Update display
                photosSaved++;
                step3ProgressBar.Value = photosSaved;
                step3Label.Text = photosSaved + " out of 14 images generated.";
                step3ProgressBar.Update();
                step3Label.Update();
            }

            //Next tab
            changeToTab(3);
            //Update
            tabControl1.Update();
            //Start step 4
            startStep4();
        }

        //Margin Tab
        private enum CropTab
        {
            Top = 0,
            Right = 1
        }
        private GraphicsPath getMarginTab(int position, CropTab cropTab)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            System.Drawing.Point[] points = new System.Drawing.Point[5];
            if (cropTab == CropTab.Top)
            {
                points = new System.Drawing.Point[]{
                    new System.Drawing.Point(position - 10, 0),
                    new System.Drawing.Point(position - 10, 10),
                    new System.Drawing.Point(position, 20),
                    new System.Drawing.Point(position + 10, 10),
                    new System.Drawing.Point(position + 10, 0)
                };
            }
            else
            {
                points = new System.Drawing.Point[]{
                    new System.Drawing.Point(cropPicture.Width, position - 10),
                    new System.Drawing.Point(cropPicture.Width - 10, position - 10),
                    new System.Drawing.Point(cropPicture.Width - 20, position),
                    new System.Drawing.Point(cropPicture.Width - 10, position + 10),
                    new System.Drawing.Point(cropPicture.Width, position + 10)
                };
            }
            graphicsPath.AddPolygon(points);
            return graphicsPath;
        }

        private bool horizontalMarginUnlocked = true;

        private System.Drawing.Image cropImage;
        private float scale;

        private int realHorizontalMargin;
        private int realVerticalMargin;

        private int croppedImageX;
        private int croppedImageWidth;

        private int currentPage = 0;

        private int[] croppedImageYs = new int[14];
        private int[] croppedImageHeights = new int[14];

        private int leftMarginX;
        private int leftMarginXMin;
        private int leftMarginXMax;
        private bool leftTabMouseDown = false;
        private GraphicsPath leftTabPath = new GraphicsPath();

        private int rightMarginX;
        private int rightMarginXMin;
        private int rightMarginXMax;
        private bool rightTabMouseDown = false;
        private GraphicsPath rightTabPath = new GraphicsPath();

        private int[] topMarginYs = new int[14];
        private int[] bottomMarginYs = new int[14];

        private int topMarginY;
        private int topMarginYMin;
        private int topMarginYMax;
        private bool topTabMouseDown = false;
        private GraphicsPath topTabPath = new GraphicsPath();

        private int bottomMarginY;
        private int bottomMarginYMin;
        private int bottomMarginYMax;
        private bool bottomTabMouseDown = false;
        private GraphicsPath bottomTabPath = new GraphicsPath();

        private SolidBrush tabBrush = new SolidBrush(Color.Blue);
        private SolidBrush grayBrush = new SolidBrush(Color.FromArgb(50, 100, 100, 100));
        private Pen splitterPen = new Pen(Color.Blue);

        private void startStep4()
        {
            //Get the first page image
            cropImage = images[0];

            //Set the image
            cropPicture.Image = cropImage;

            //Get the ratio of the display with to the image's width
            if ((float)cropImage.Width / cropImage.Height > (float)cropPicture.Width / cropPicture.Height)
            {
                scale = (float)cropImage.Width / cropPicture.Width;
            }
            else
            {
                scale = (float)cropImage.Height / cropPicture.Height;
            }

            //Calculate the real margins
            realHorizontalMargin = Convert.ToInt32((cropPicture.Width - cropImage.Width / scale) / 2);
            realVerticalMargin = Convert.ToInt32((cropPicture.Height - cropImage.Height / scale) / 2);

            leftMarginX = realHorizontalMargin;
            leftMarginXMin = realHorizontalMargin;
            leftMarginXMax = realHorizontalMargin + (cropPicture.Width - realHorizontalMargin * 2) / 4;

            rightMarginX = cropPicture.Width - realHorizontalMargin;
            rightMarginXMin = cropPicture.Width - realHorizontalMargin - (cropPicture.Width - realHorizontalMargin * 2) / 4;
            rightMarginXMax = cropPicture.Width - realHorizontalMargin;

            topMarginY = realVerticalMargin;
            topMarginYMin = realVerticalMargin;
            topMarginYMax = cropPicture.Height - realVerticalMargin;

            bottomMarginY = cropPicture.Height - realVerticalMargin;
            bottomMarginYMin = realVerticalMargin;
            bottomMarginYMax = cropPicture.Height - realVerticalMargin;

            //Refresh
            calculateWidth();
            cropPicture.Refresh();
        }

        private void cropPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //Left grayed out area
            g.FillRectangle(grayBrush, new System.Drawing.Rectangle(0, 0, leftMarginX, cropPicture.Height));
            //Left tab
            leftTabPath = getMarginTab(leftMarginX, CropTab.Top);
            //Left tab
            g.FillPath(tabBrush, leftTabPath);
            //Left Cutter Line
            g.DrawLine(splitterPen, leftMarginX, 20, leftMarginX, cropPicture.Height);

            //Right grayed out area
            g.FillRectangle(grayBrush, new System.Drawing.Rectangle(rightMarginX, 0, cropPicture.Width - rightMarginX, cropPicture.Height));
            //Right tab
            rightTabPath = getMarginTab(rightMarginX, CropTab.Top);
            //Right tab
            g.FillPath(tabBrush, rightTabPath);
            //Right Cutter Line
            g.DrawLine(splitterPen, rightMarginX, 20, rightMarginX, cropPicture.Height);

            if (!horizontalMarginUnlocked)
            {
                //Top grayed out area
                g.FillRectangle(grayBrush, new System.Drawing.Rectangle(leftMarginX, 0, rightMarginX - leftMarginX, topMarginY));
                //Top tab
                topTabPath = getMarginTab(topMarginY, CropTab.Right);
                //Top tab
                g.FillPath(tabBrush, topTabPath);
                //Top Cutter Line
                g.DrawLine(splitterPen, 0, topMarginY, cropPicture.Width - 20, topMarginY);

                //Bottom grayed out area
                g.FillRectangle(grayBrush, new System.Drawing.Rectangle(leftMarginX, bottomMarginY, rightMarginX - leftMarginX, cropPicture.Height - bottomMarginY));
                //Bottom tab
                bottomTabPath = getMarginTab(bottomMarginY, CropTab.Right);
                //Bottom tab
                g.FillPath(tabBrush, bottomTabPath);
                //Bottom Cutter Line
                g.DrawLine(splitterPen, 0, bottomMarginY, cropPicture.Width - 20, bottomMarginY);
            }
        }

        private void cropMouseDown(object sender, MouseEventArgs e)
        {
            if (horizontalMarginUnlocked)
            {
                //Check if left tab is being clicked
                if (leftTabPath.IsVisible(e.Location))
                {
                    leftTabMouseDown = true;
                }

                //Check if right tab is being clicked
                if (rightTabPath.IsVisible(e.Location))
                {
                    rightTabMouseDown = true;
                }
            }
            //Check if top tab is being clicked
            if (topTabPath.IsVisible(e.Location))
            {
                topTabMouseDown = true;
            }

            //Check if bottom tab is being clicked
            if (bottomTabPath.IsVisible(e.Location))
            {
                bottomTabMouseDown = true;
            }
        }

        private void calculateWidth()
        {
            //Calculate image x and width
            croppedImageX = Convert.ToInt32((leftMarginX - realHorizontalMargin) * scale);
            croppedImageWidth = Convert.ToInt32((rightMarginX - realHorizontalMargin) * scale) - croppedImageX;
        }

        private void calculateHeight()
        {
            //Calculate image y and height
            croppedImageYs[currentPage] = Convert.ToInt32((topMarginY - realVerticalMargin) * scale);
            croppedImageHeights[currentPage] = Convert.ToInt32((bottomMarginY - realVerticalMargin) * scale) - croppedImageYs[currentPage];

            //Store the ui y positions
            topMarginYs[currentPage] = topMarginY;
            bottomMarginYs[currentPage] = bottomMarginY;
        }

        private void cropMouseUp(object sender, MouseEventArgs e)
        {
            if (leftTabMouseDown || rightTabMouseDown)
            {
                //Calculate image x and width
                calculateWidth();
            }
            leftTabMouseDown = false;
            rightTabMouseDown = false;
            if (topTabMouseDown || bottomTabMouseDown)
            {
                //Calculate image y and height
                calculateHeight();
            }
            topTabMouseDown = false;
            bottomTabMouseDown = false;
        }

        private void cropMouseMoved(object sender, MouseEventArgs e)
        {
            //Update cursor
            if (leftTabPath.IsVisible(e.Location) || rightTabPath.IsVisible(e.Location))
            {
                if (horizontalMarginUnlocked)
                {
                    cropPicture.Cursor = Cursors.Hand;
                }
                else
                {
                    cropPicture.Cursor = Cursors.No;
                }
            }
            else if (topTabPath.IsVisible(e.Location) || bottomTabPath.IsVisible(e.Location))
            {
                cropPicture.Cursor = Cursors.Hand;
            }
            else
            {
                cropPicture.Cursor = Cursors.Default;
            }

            //Check if left position was changed and it is a valid position
            if (leftTabMouseDown && e.X != leftMarginX)
            {
                //Update position
                if (e.X < leftMarginXMin)
                {
                    leftMarginX = leftMarginXMin;
                }
                else if (e.X > leftMarginXMax)
                {
                    leftMarginX = leftMarginXMax;
                }
                else
                {
                    leftMarginX = e.X;
                }
                //Redraw
                cropPicture.Refresh();
            }

            //Check if right position was changed and it is a valid position
            if (rightTabMouseDown && e.X != rightMarginX)
            {
                //Update position
                if (e.X < rightMarginXMin)
                {
                    rightMarginX = rightMarginXMin;
                }
                else if (e.X > rightMarginXMax)
                {
                    rightMarginX = rightMarginXMax;
                }
                else
                {
                    rightMarginX = e.X;
                }
                //Redraw
                cropPicture.Refresh();
            }

            //Check if top position was changed and it is a valid position
            if (topTabMouseDown && e.Y != topMarginY)
            {
                //Update position
                if (e.Y < topMarginYMin)
                {
                    topMarginY = topMarginYMin;
                }
                else if (bottomMarginY - e.Y < 20)
                {
                    topMarginY = bottomMarginY - 20;
                }
                else
                {
                    topMarginY = e.Y;
                }
                //Redraw
                cropPicture.Refresh();
            }

            //Check if bottom position was changed and it is a valid position
            if (bottomTabMouseDown && e.Y != bottomMarginY)
            {
                //Update position
                if (e.Y - topMarginY < 20)
                {
                    bottomMarginY = topMarginY + 20;
                }
                else if (e.Y > bottomMarginYMax)
                {
                    bottomMarginY = bottomMarginYMax;
                }
                else
                {
                    bottomMarginY = e.Y;
                }
                //Redraw
                cropPicture.Refresh();
            }
        }

        private void updateCropDisplay()
        {
            if (horizontalMarginUnlocked)
            {
                cropLabel.Text = "Choose Horizontal Margins";
                calculateWidth();
                cropPicture.Refresh();
            }
            else if (currentPage < 14)
            {
                //Check if the vertical margins for this page have already been selected
                if (bottomMarginYs[currentPage] != 0)
                {
                    topMarginY = topMarginYs[currentPage];
                    bottomMarginY = bottomMarginYs[currentPage];
                }
                //Adjust the top and bottom marginYs based on current page
                else
                {
                    if (isEven(currentPage))
                    {
                        topMarginY = topMarginYMin;
                        bottomMarginY = cropPicture.Height / 2;
                    }
                    else
                    {
                        topMarginY = cropPicture.Height / 2;
                        bottomMarginY = bottomMarginYMax;
                    }
                    //Calculate the height
                    calculateHeight();
                }
                //Set new image
                cropPicture.Image = images[currentPage];
                //Update label
                cropLabel.Text = "Crop Page " + (currentPage + 1);
            }
            else
            {
                currentPage = 13;

                changeToTab(4);
            }
        }

        private void nextImage(object sender, EventArgs e)
        {
            //If currently choosing horizontal margin
            if (horizontalMarginUnlocked)
            {
                horizontalMarginUnlocked = false;
            }
            else
            {
                currentPage++;
            }
            //Update display
            updateCropDisplay();
        }

        private void step4Back(object sender, EventArgs e)
        {
            //Back to a cropping step
            if (currentPage > 0)
            {
                currentPage--;
                updateCropDisplay();
            }
            //Back to choosing horizontal margins
            else if (currentPage == 0 && !horizontalMarginUnlocked)
            {
                horizontalMarginUnlocked = true;
                topTabPath = new GraphicsPath();
                bottomTabPath = new GraphicsPath();
                updateCropDisplay();
            }
            //Restart the application
            else
            {
                Application.Restart();
            }
        }

        //Dest dialog
        private FolderBrowserDialog destDialog = new FolderBrowserDialog();
        //The export file name
        private string destFileName;
        private DateTime startDate;
        private DateTime endDate;
        //Pdf stuff
        private Bitmap croppedImage;
        private ImageConverter imageConverter = new ImageConverter();
        private System.Drawing.Rectangle cropRectangle;
        private ImageData[] imageDatas = new ImageData[14];
        private PdfWriter writer;
        private PdfDocument pdf;
        private PdfPage page;
        private PdfCanvas canvas;
        private int togetherHeight;
        private float pageImageHeightRatio;
        private float pageImageWidthRatio;
        private float smallerRatio;
        private float bottomSpace;

        private void validateDestPath()
        {
            //Check if file exists
            if (Directory.Exists(destPath.Text))
            {
                destValidity.Text = "Folder Is Valid";
                destValidity.ForeColor = Color.Green;
                createButton.Enabled = true;
            }
            else
            {
                destValidity.Text = "Folder Doesn't Exist";
                destValidity.ForeColor = Color.Red;
                createButton.Enabled = false;
            }
        }

        private void destDialogClicked(object sender, EventArgs e)
        {
            if (destDialog.ShowDialog() == DialogResult.OK)
            {
                destPath.Text = destDialog.SelectedPath;
                validateDestPath();
            }
        }

        private void destPathChanged(object sender, EventArgs e)
        {
            validateDestPath();
        }

        private void step5Back(object sender, EventArgs e)
        {
            changeToTab(3);
        }

        private void createClicked(object sender, EventArgs e)
        {
            //Figure out the file name
            startDate = dateTimePicker1.Value;
            endDate = startDate.AddDays(7);

            destFileName = destPath.Text + "/";
            destFileName += startDate.ToString("yyyy MMMM d");
            destFileName += " - ";
            if (endDate.Year != startDate.Year) destFileName += endDate.ToString("yyyy") + " ";
            if (endDate.Month != startDate.Month) destFileName += endDate.ToString("MMMM") + " ";
            destFileName += endDate.Day;
            destFileName += " Murlis";
            destFileName += ".pdf";

            createButton.Text = "Creating...";
            createButton.Refresh();

            //Create the pdf
            writer = new PdfWriter(destFileName);
            pdf = new PdfDocument(writer);
            //Loop through each day
            for(int i = 0; i < 14; i += 2)
            {
                //Reset togetherHeight
                togetherHeight = 0;
                //Crop the images
                for(int j = 0; j < 2; j++)
                {
                    //Rectangle for part of image we want
                    cropRectangle = new System.Drawing.Rectangle(croppedImageX, croppedImageYs[i + j], croppedImageWidth, croppedImageHeights[i + j]);
                    //Get bitmap from already gotten image
                    croppedImage = new Bitmap(images[i + j]);
                    //Crop the image
                    croppedImage = croppedImage.Clone(cropRectangle, croppedImage.PixelFormat);
                    //Add the height onto the togetherHeight
                    togetherHeight += croppedImage.Height;
                    //Convert to ImageData
                    imageDatas[i + j] = ImageDataFactory.Create((byte[])imageConverter.ConvertTo(croppedImage, typeof(byte[])));
                }
                //Add a  page and canvas to the pdf
                page = pdf.AddNewPage(PageSize.A4.Rotate());
                canvas = new PdfCanvas(page);
                //Calculate ratios
                pageImageWidthRatio = page.GetPageSize().GetWidth() / croppedImage.Width;
                pageImageHeightRatio = page.GetPageSize().GetHeight() / togetherHeight;
                smallerRatio = Math.Min(pageImageWidthRatio, pageImageHeightRatio);
                bottomSpace = page.GetPageSize().GetHeight() - togetherHeight * smallerRatio;
                //Set transform
                canvas.ConcatMatrix(AffineTransform.GetScaleInstance(smallerRatio, smallerRatio));
                //Add the images onto the canvas
                canvas.AddImage(imageDatas[i], 0, imageDatas[i + 1].GetHeight() + bottomSpace, true);
                canvas.AddImage(imageDatas[i + 1], 0, bottomSpace, true);
            }
            //Save the pdf
            pdf.Close();

            openButton.Enabled = true;
            closeButton.Enabled = true;
            MessageBox.Show("PDF Successfully Created");
            createButton.Text = "Create";
        }

        private void openClicked(object sender, EventArgs e)
        {
            Process.Start(destFileName);
        }

        private void closeClicked(object sender, EventArgs e)
        {
            this.Close();
        }

        /*Crop an image
        const string src = "C:/Users/rajas/Desktop/Test Murlis/image.png";
        const string dest = "C:/Users/rajas/Desktop/Test Murlis/cropped.png";

        System.Drawing.Image img = System.Drawing.Image.FromFile(src);
        Bitmap bmpImage = new Bitmap(img);
        Bitmap bmpCrop = bmpImage.Clone(new System.Drawing.Rectangle(100, 100, 300, 300), bmpImage.PixelFormat);

        bmpCrop.Save(dest);*/

        /*Get an image from 1 page of pdf
        int desired_x_dpi = 400;
        int desired_y_dpi = 400;

        const string src = "C:/Users/rajas/Desktop/Test Murlis/og.pdf";
        const string dest = "C:/Users/rajas/Desktop/Test Murlis/image.png";

        //Get image from pdf
        GhostscriptPngDevice dev = new GhostscriptPngDevice(GhostscriptPngDeviceType.PngGray);
        dev.GraphicsAlphaBits = GhostscriptImageDeviceAlphaBits.V_4;
        dev.TextAlphaBits = GhostscriptImageDeviceAlphaBits.V_4;
        dev.ResolutionXY = new GhostscriptImageDeviceResolution(desired_x_dpi, desired_y_dpi);
        dev.InputFiles.Add(src);
        dev.Pdf.FirstPage = 1;
        dev.Pdf.LastPage = 1;
        dev.CustomSwitches.Add("-dDOINTERPOLATE");
        dev.OutputPath = dest;
        dev.Process();*/

        /*Initialize PDF writer
        const string FOX = "C:/Users/rajas/Desktop/Test Murlis/fox.png";
        ImageData fox = ImageDataFactory.Create(FOX);

        const string dest = "C:/Users/rajas/Desktop/Test Murlis/test.pdf";

        var writer = new PdfWriter(dest);
        var pdf = new PdfDocument(writer);

        PdfPage page = pdf.AddNewPage(PageSize.A4.Rotate());

        PdfCanvas canvas = new PdfCanvas(page);

        double wr = page.GetPageSize().GetWidth() / fox.GetWidth();

        double hr = page.GetPageSize().GetHeight() / fox.GetHeight();

        AffineTransform transformationMatrix = AffineTransform.GetScaleInstance(Math.Min(wr,hr), Math.Min(wr,hr));
        canvas.ConcatMatrix(transformationMatrix);

        canvas.AddImage(fox, 0, 0, false);
        canvas.AddImage(fox, 0, fox.GetHeight(), false);

        pdf.Close();
        Process.Start(dest);*/
    }
}
