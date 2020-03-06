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
