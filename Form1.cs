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

namespace Murli_Clipper
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        private string tempPath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "./temp");

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
        int currentTab = 0;
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
        private Bitmap[] bitmaps = new Bitmap[14];

        private void startStep3()
        {
            device.GraphicsAlphaBits = GhostscriptImageDeviceAlphaBits.V_4;
            device.TextAlphaBits = GhostscriptImageDeviceAlphaBits.V_4;
            device.ResolutionXY = resolution;
            device.InputFiles.Add(srcPath.Text);
            device.CustomSwitches.Add("-dDOINTERPOLATE");

            int photosSaved = 0;
            string path;
            Bitmap bitmap;
            System.Drawing.Rectangle rectangle;
            System.Drawing.Image image;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    //Calculate path
                    path = System.IO.Path.Combine(tempPath, "./" + i + (j == 0 ? "A" : "B") + ".png");

                    //Get photo
                    device.OutputPath = path;
                    device.Pdf.FirstPage = i * 3 + j * 2 + 1;
                    device.Pdf.LastPage = i * 3 + j * 2 + 1;
                    device.Process();

                    //Split photo in half
                    image = System.Drawing.Image.FromFile(path);
                    bitmap = new Bitmap(image);
                    if (j == 0)
                    {
                        rectangle = new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height / 2);
                    }
                    else
                    {
                        rectangle = new System.Drawing.Rectangle(0, bitmap.Height / 2, bitmap.Width, bitmap.Height / 2);
                    }
                    bitmap = bitmap.Clone(rectangle, bitmap.PixelFormat);
                    bitmaps[photosSaved] = bitmap;

                    //Update display
                    photosSaved++;
                    step3ProgressBar.Value = photosSaved;
                    step3Label.Text = photosSaved + " out of 14 images generated.";
                    step3ProgressBar.Update();
                    step3Label.Update();
                }
            }

            bitmaps[0].Save(tempPath + "/cropped.png");
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
