using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace System_Info
{
    class cls_battery
    {
        public static Bitmap DrawBattery(float percent, int wid, int hgt, Color bg_color, Color outline_color, Color charged_color, Color uncharged_color, bool striped)
        {
            Bitmap bm = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                if (wid > hgt)
                {
                    gr.RotateTransform(90, MatrixOrder.Append);
                    gr.TranslateTransform(wid, 0, MatrixOrder.Append);
                    int temp = wid;
                    wid = hgt;
                    hgt = temp;
                }
                DrawVerticalBattery(gr, percent, wid, hgt, bg_color, outline_color, charged_color, uncharged_color, striped);
            }
            return bm;
        }

        private static void DrawVerticalBattery(Graphics gr, float percent, int wid, int hgt, Color bg_color, Color outline_color, Color charged_color, Color uncharged_color, bool striped)
        {
            gr.Clear(bg_color);
            gr.SmoothingMode = SmoothingMode.None;
            float thickness = hgt / 20f;
            RectangleF body_rect = new RectangleF(thickness * 0.5f, thickness * 1.5f, wid - thickness, hgt - thickness * 2f);

            using (Pen pen = new Pen(outline_color, thickness))
            {
                using (Brush brush = new SolidBrush(uncharged_color))
                {
                    gr.FillRectangle(brush, body_rect);
                }
                float charged_hgt = body_rect.Height * percent;
                RectangleF charged_rect = new RectangleF(body_rect.Left + 3, body_rect.Bottom - charged_hgt + 3, body_rect.Width - 6, charged_hgt - 6);
                using (Brush brush = new SolidBrush(charged_color))
                {
                    gr.FillRectangle(brush, charged_rect);
                }
                gr.DrawPath(pen, MakeRoundedRect(body_rect, thickness, thickness, true, true, true, true));
                RectangleF terminal_rect = new RectangleF(wid / 2f - thickness, 0, 2 * thickness, thickness);
                gr.DrawPath(pen, MakeRoundedRect(terminal_rect, thickness / 2f, thickness / 2f, true, true, false, false));
            }
        }

        private static GraphicsPath MakeRoundedRect(RectangleF rect, float xradius, float yradius, bool round_ul, bool round_ur, bool round_lr, bool round_ll)
        {
            PointF point1, point2;
            GraphicsPath path = new GraphicsPath();
            if (round_ul)
            {
                RectangleF corner = new RectangleF(rect.X, rect.Y, 2 * xradius, 2 * yradius);
                path.AddArc(corner, 180, 90);
                point1 = new PointF(rect.X + xradius, rect.Y);
            }
            else
            {
                point1 = new PointF(rect.X, rect.Y);
            }

            // Top side.
            if (round_ur)
            {
                point2 = new PointF(rect.Right - xradius, rect.Y);
            }
            else
            {
                point2 = new PointF(rect.Right, rect.Y);
            }
            path.AddLine(point1, point2);

            // Upper right corner.
            if (round_ur)
            {
                RectangleF corner = new RectangleF(rect.Right - 2 * xradius, rect.Y, 2 * xradius, 2 * yradius);
                path.AddArc(corner, 270, 90);
                point1 = new PointF(rect.Right, rect.Y + yradius);
            }
            else
            {
                point1 = new PointF(rect.Right, rect.Y);
            }

            // Right side.
            if (round_lr)
            {
                point2 = new PointF(rect.Right, rect.Bottom - yradius);
            }
            else
            {
                point2 = new PointF(rect.Right, rect.Bottom);
            }
            path.AddLine(point1, point2);

            // Lower right corner.
            if (round_lr)
            {
                RectangleF corner = new RectangleF(rect.Right - 2 * xradius, rect.Bottom - 2 * yradius, 2 * xradius, 2 * yradius);
                path.AddArc(corner, 0, 90);
                point1 = new PointF(rect.Right - xradius, rect.Bottom);
            }
            else
            {
                point1 = new PointF(rect.Right, rect.Bottom);
            }

            // Bottom side.
            if (round_ll)
            {
                point2 = new PointF(rect.X + xradius, rect.Bottom);
            }
            else
            {
                point2 = new PointF(rect.X, rect.Bottom);
            }
            path.AddLine(point1, point2);

            // Lower left corner.
            if (round_ll)
            {
                RectangleF corner = new RectangleF(rect.X, rect.Bottom - 2 * yradius, 2 * xradius, 2 * yradius);
                path.AddArc(corner, 90, 90);
                point1 = new PointF(rect.X, rect.Bottom - yradius);
            }
            else
            {
                point1 = new PointF(rect.X, rect.Bottom);
            }

            // Left side.
            if (round_ul)
            {
                point2 = new PointF(rect.X, rect.Y + yradius);
            }
            else
            {
                point2 = new PointF(rect.X, rect.Y);
            }
            path.AddLine(point1, point2);

            // Join with the start point.
            path.CloseFigure();
            return path;
        }







        public static Bitmap DrawBattery2(float percent, int wid, int hgt, Color bg_color, Color outline_color, Color charged_color, Color uncharged_color, bool striped)
        {
            Bitmap bm = new Bitmap(wid, hgt);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                if (wid > hgt)
                {
                    gr.RotateTransform(90, MatrixOrder.Append);
                    gr.TranslateTransform(wid, 0, MatrixOrder.Append);
                    int temp = wid;
                    wid = hgt;
                    hgt = temp;
                }
                DrawVerticalBattery2(gr, percent, wid, hgt, bg_color, outline_color, charged_color, uncharged_color, striped);
            }
            return bm;
        }

        private static void DrawVerticalBattery2(Graphics gr, float percent, int wid, int hgt, Color bg_color, Color outline_color, Color charged_color, Color uncharged_color, bool striped)
        {
            gr.Clear(bg_color);
            gr.SmoothingMode = SmoothingMode.None;
            float thickness = hgt / 20f;
            RectangleF body_rect = new RectangleF(thickness * 0.5f, thickness * 1.5f, wid - thickness, hgt - thickness * 2f);

            using (Pen pen = new Pen(outline_color, thickness))
            {
                using (Brush brush = new SolidBrush(uncharged_color))
                {
                    gr.FillRectangle(brush, body_rect);
                }
                float charged_hgt = body_rect.Height * percent;
                RectangleF charged_rect = new RectangleF(body_rect.Left + 4, body_rect.Bottom - charged_hgt + 4, body_rect.Width - 9, charged_hgt - 8);
                using (Brush brush = new SolidBrush(charged_color))
                {
                    gr.FillRectangle(brush, charged_rect);
                }
                if (frm_system_info.batcharging == 1)
                {
                    Rectangle abc = new Rectangle(10, 20, 30, 70);
                    gr.DrawImage(Properties.Resources.Plugged_in, abc);
                }
                gr.DrawPath(pen, MakeRoundedRect(body_rect, thickness, thickness, false, false, false, false));
                RectangleF terminal_rect = new RectangleF(wid / 2f - thickness, 0, 2 * thickness, thickness);
                gr.DrawPath(pen, MakeRoundedRect(terminal_rect, thickness / 2f, thickness / 2f, false, false, false, false));
            }
        }
    }
}
