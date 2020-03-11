using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Kernel.Geom;
using iText.IO.Image;
using iText.Kernel.Pdf.Canvas;

using Ghostscript.NET.Rasterizer;
using Ghostscript.NET;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace Murli_Clipper
{
    public partial class Form1 : System.Windows.Forms.Form
    {
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
            changeToTab(currentTab + 1);
        }

        private void step2Done(object sender, EventArgs e)
        {
            //Next tab
            changeToTab(currentTab + 1);
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

        private void startStep3()
        {
            device.GraphicsAlphaBits = GhostscriptImageDeviceAlphaBits.V_4;
            device.TextAlphaBits = GhostscriptImageDeviceAlphaBits.V_4;
            device.ResolutionXY = resolution;
            device.InputFiles.Add(srcPath.Text);
            device.CustomSwitches.Add("-dDOINTERPOLATE");

            int photosSaved = 0;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    //Get photo
                    device.OutputPath = System.IO.Path.Combine(tempPath, "./" + i + (j == 0 ? "A" : "B") + ".png");
                    device.Pdf.FirstPage = i * 3 + j * 2 + 1;
                    device.Pdf.LastPage = i * 3 + j * 2 + 1;
                    device.Process();

                    //Update display
                    photosSaved++;
                    step3ProgressBar.Value = photosSaved;
                    step3Label.Text = photosSaved + " out of 14 images generated.";
                    step3ProgressBar.Update();
                    step3Label.Update();
                }
            }

            //Next tab
            changeToTab(currentTab + 1);
            //Update
            tabControl1.Update();
            //Start step 4
            startStep4();
        }

        //Margin Tab
        private GraphicsPath getMarginTab(int x)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            System.Drawing.Point[] points = {
                new System.Drawing.Point(x - 10, 0),
                new System.Drawing.Point(x - 10, 10),
                new System.Drawing.Point(x, 20),
                new System.Drawing.Point(x + 10, 10),
                new System.Drawing.Point(x + 10, 0)
            };
            graphicsPath.AddPolygon(points);
            return graphicsPath;
        }

        private System.Drawing.Image marginImage;
        private float scale;

        private int realHorizontalMargin; 
        private int realVerticalMargin;

        private int croppedImageX;
        private int croppedImageWidth;

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

        private SolidBrush tabBrush = new SolidBrush(Color.Blue);
        private SolidBrush grayBrush = new SolidBrush(Color.FromArgb(50, 100, 100, 100));
        private Pen splitterPen = new Pen(Color.Blue);

        private void startStep4()
        {
            marginImage = System.Drawing.Image.FromFile(System.IO.Path.Combine(resPath, "./margin.png"));

            //Get the ratio of the display with to the image's width
            if ((float)marginImage.Width / marginImage.Height > (float)marginPicture.Width / marginPicture.Height)
            {
                scale = (float)marginImage.Width / marginPicture.Width;
            }
            else
            {
                scale = (float)marginImage.Height / marginPicture.Height;
            }

            //Calculate the real margins
            realHorizontalMargin = Convert.ToInt32((marginPicture.Width - marginImage.Width / scale) / 2);
            realVerticalMargin = Convert.ToInt32((marginPicture.Height - marginImage.Height / scale) / 2);

            leftMarginX = realHorizontalMargin;
            leftMarginXMin = realHorizontalMargin;
            leftMarginXMax = realHorizontalMargin + (marginPicture.Width - realHorizontalMargin * 2) / 4;

            rightMarginX = marginPicture.Width - realHorizontalMargin;
            rightMarginXMin = marginPicture.Width - realHorizontalMargin - (marginPicture.Width - realHorizontalMargin * 2) / 4;
            rightMarginXMax = marginPicture.Width - realHorizontalMargin;

            //Refresh
            marginPicture.Refresh();
        }

        private void marginPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //Left grayed out area
            g.FillRectangle(grayBrush, new System.Drawing.Rectangle(0, 0, leftMarginX, marginPicture.Height));
            //Left tab
            leftTabPath = getMarginTab(leftMarginX);
            //Left tab
            g.FillPath(tabBrush, leftTabPath);
            //Left Cutter Line
            g.DrawLine(splitterPen, leftMarginX, 20, leftMarginX, marginPicture.Height);

            //Left grayed out area
            g.FillRectangle(grayBrush, new System.Drawing.Rectangle(rightMarginX, 0, marginPicture.Width - rightMarginX, marginPicture.Height));
            //Right tab
            rightTabPath = getMarginTab(rightMarginX);
            //Right tab
            g.FillPath(tabBrush, rightTabPath);
            //Right Cutter Line
            g.DrawLine(splitterPen, rightMarginX, 20, rightMarginX, marginPicture.Height);
        }

        private void marginMouseDown(object sender, MouseEventArgs e)
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

        private void marginMouseUp(object sender, MouseEventArgs e)
        {
            leftTabMouseDown = false;

            rightTabMouseDown = false;
        }

        private void marginMouseMoved(object sender, MouseEventArgs e)
        {
            //Update cursor
            if (leftTabPath.IsVisible(e.Location) || rightTabPath.IsVisible(e.Location))
            {
                marginPicture.Cursor = Cursors.Hand;
            }
            else
            {
                marginPicture.Cursor = Cursors.Default;
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
                marginPicture.Refresh();
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
                marginPicture.Refresh();
            }
        }

        private void step4Done(object sender, EventArgs e)
        {
            //Calculate image margin
            croppedImageX = Convert.ToInt32((leftMarginX - realHorizontalMargin) * scale);
            croppedImageWidth = Convert.ToInt32((rightMarginX - realHorizontalMargin) * scale) - croppedImageX;

            //Test it out by cropping
            const string dest = "C:/Users/rajas/Desktop/Test Murlis/iCropped.png";

            Bitmap bmpImage = new Bitmap(marginImage);
            Bitmap bmpCrop = bmpImage.Clone(new System.Drawing.Rectangle(croppedImageX, 0, croppedImageWidth, marginImage.Height), bmpImage.PixelFormat);

            bmpCrop.Save(dest);
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
