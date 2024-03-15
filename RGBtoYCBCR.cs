using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageSteganographySusmita
{
    public class RGBtoYCBCR
    {
        public static YCbCr RGBToYCbCr(RGB rgb)
        {
            float fr = (float)rgb.R / 255;
            float fg = (float)rgb.G / 255;
            float fb = (float)rgb.B / 255;

            float Y = (float)(0.2989 * fr + 0.5866 * fg + 0.1145 * fb);
            float Cb = (float)(-0.1687 * fr - 0.3313 * fg + 0.5000 * fb);
            float Cr = (float)(0.5000 * fr - 0.4184 * fg - 0.0816 * fb);

            return new YCbCr(Y, Cb, Cr);
        }
    }
    public struct RGB
    {
        private byte _r;
        private byte _g;
        private byte _b;

        public RGB(byte r, byte g, byte b)
        {
            this._r = r;
            this._g = g;
            this._b = b;
        }

        public byte R
        {
            get { return this._r; }
            set { this._r = value; }
        }

        public byte G
        {
            get { return this._g; }
            set { this._g = value; }
        }

        public byte B
        {
            get { return this._b; }
            set { this._b = value; }
        }

        public bool Equals(RGB rgb)
        {
            return (this.R == rgb.R) && (this.G == rgb.G) && (this.B == rgb.B);
        }
    }

    public struct YCbCr
    {
        private float _y;
        private float _cb;
        private float _cr;

        public YCbCr(float y, float cb, float cr)
        {
            this._y = y;
            this._cb = cb;
            this._cr = cr;
        }

        public float Y
        {
            get { return this._y; }
            set { this._y = value; }
        }

        public float Cb
        {
            get { return this._cb; }
            set { this._cb = value; }
        }

        public float Cr
        {
            get { return this._cr; }
            set { this._cr = value; }
        }

        public bool Equals(YCbCr ycbcr)
        {
            return (this.Y == ycbcr.Y) && (this.Cb == ycbcr.Cb) && (this.Cr == ycbcr.Cr);
        }
    }


}
