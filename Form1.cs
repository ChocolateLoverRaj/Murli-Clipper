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
        public Form1()
        {
            InitializeComponent();
        }

        //Change to a tab
        int currentTab = 0;
        void changeToTab(int tabNumber) {
            //Change to tab
            currentTab = tabNumber;
            tabControl1.SelectedTab = tabControl1.TabPages[tabNumber];
        }

        private void tabChanged(object sender, TabControlCancelEventArgs e)
        {
            //Check if it is the selected tab
            if (e.TabPageIndex != currentTab)
            {
                e.Cancel = true;
            }
        }

        //Validate srcPath
        void validateSrcPath() {
            //Check if file exists
            if (File.Exists(srcPath.Text) && System.IO.Path.GetExtension(srcPath.Text) == ".pdf") {
                srcValidity.Text = "Path Is Valid";
                srcValidity.ForeColor = Color.Green;
            }
            else
            {
                srcValidity.Text = "Not a Valid Path";
                srcValidity.ForeColor = Color.Red;
            }
        }

        private void step1Done(object sender, EventArgs e)
        {
            //Next tab
            changeToTab(currentTab + 1);
        }

        //Open source dialog;
        OpenFileDialog srcDialog = new OpenFileDialog();
        private void srcDialogClicked(object sender, EventArgs e)
        {
            srcDialog.Filter = "Pdf Files (*.pdf)|*.pdf|All files (*.*)|*.*";
            if (srcDialog.ShowDialog() == DialogResult.OK) {
                srcPath.Text = srcDialog.FileName;
                validateSrcPath();
            }
        }

        private void srcPathChanged(object sender, EventArgs e)
        {
            validateSrcPath();
        }

<<<<<<< Updated upstream
            var localGhostscriptDll = System.IO.Path.Combine(Environment.CurrentDirectory, Environment.Is64BitProcess ? "gsdll64.dll" : "gsdll32.dll");
            var localDllInfo = new GhostscriptVersionInfo(localGhostscriptDll);

            int desired_x_dpi = 96;
            int desired_y_dpi = 96;

            const string src = "C:/Users/rajas/Desktop/Test Murlis/og.pdf";
            const string dest = "C:/Users/rajas/Desktop/Test Murlis/image";

            //Get image from pdf
            GhostscriptRasterizer rasterizer = new GhostscriptRasterizer();

            rasterizer.Open(src);

            //Get the first page
            System.Drawing.Image image = rasterizer.GetPage(desired_x_dpi, desired_y_dpi, 0);

            rasterizer.Close();

            image.Save(dest, ImageFormat.Png);
            
            /*Initialize PDF writer
            const string FOX = "C:/Users/rajas/Desktop/Test Murlis/fox.png";
            ImageData fox = ImageDataFactory.Create(FOX);
            
=======
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

            AffineTransform transformationMatrix = AffineTransform.GetScaleInstance(Math.Min(wr,hr), Math.Min(wr,hr));
            canvas.ConcatMatrix(transformationMatrix);


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
