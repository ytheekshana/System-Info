using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace System_Info
{
    public class CirclePictureBox : PictureBox
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            Brush brushImege;
            try
            {
                Bitmap Imagem = new Bitmap(this.Image);
                Imagem = new Bitmap(Imagem, new Size(this.Width - 1, this.Height - 1));
                brushImege = new TextureBrush(Imagem);
            }
            catch
            {
                Bitmap Imagem = new Bitmap(this.Width - 1, this.Height - 1, PixelFormat.Format24bppRgb);
                using (Graphics grp = Graphics.FromImage(Imagem))
                {
                    grp.FillRectangle(
                        Brushes.White, 0, 0, this.Width - 1, this.Height - 1);
                    Imagem = new Bitmap(this.Width - 1, this.Height - 1, grp);
                }
                brushImege = new TextureBrush(Imagem);
            }
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, this.Width - 1, this.Height - 1);
            e.Graphics.FillPath(brushImege, path);
            e.Graphics.DrawPath(Pens.White, path);
        }
    }
}
