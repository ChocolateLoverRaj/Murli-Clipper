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

        private void button1_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Clicked");

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
}
