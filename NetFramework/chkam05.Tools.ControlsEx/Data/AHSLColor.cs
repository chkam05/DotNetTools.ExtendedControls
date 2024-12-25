﻿using chkam05.Tools.ControlsEx.Utilities;
using chkam05.Tools.ControlsEx.ViewModels;
using MaterialDesignColors.ColorManipulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace chkam05.Tools.ControlsEx.Data
{
    public class AHSLColor : BaseViewModel
    {

        //  CONST

        public const int HUE_MAX = 1530;
        public const int HUE_MIN = 0;
        public const int LIGHTNESS_MAX = 100;
        public const int LIGHTNESS_MIN = 0;
        public const int SATURATION_MAX = 100;
        public const int SATURATION_MIN = 0;


        //  VARIABLES

        private byte alpha;
        private int hue;
        private int saturation;
        private int lightness;


        //  GETTERS & SETTERS

        public byte A
        {
            get => alpha;
            set => UpdateProperty(ref alpha, value);
        }

        public int H
        {
            get => hue;
            set => UpdateProperty(ref hue, MathUtilities.Clamp(value, HUE_MIN, HUE_MAX));
        }

        public int S
        {
            get => saturation;
            set => UpdateProperty(ref saturation, MathUtilities.Clamp(value, SATURATION_MIN, SATURATION_MAX));
        }

        public int L
        {
            get => lightness;
            set => UpdateProperty(ref lightness, MathUtilities.Clamp(value, LIGHTNESS_MIN, LIGHTNESS_MAX));
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> AHSL color model class constructor. </summary>
        /// <param name="a"> Alpha. </param>
        /// <param name="h"> Hue. </param>
        /// <param name="s"> Saturation. </param>
        /// <param name="l"> Lightness. </param>
        public AHSLColor(byte a, int h, int s, int l)
        {
            A = a;
            H = h;
            S = s;
            L = l;
        }


        #endregion CONSTRUCTORS

        #region CONVERSION

        //  --------------------------------------------------------------------------------
        /// <summary> Convert ARGB color model to AHSL color model. </summary>
        /// <param name="color"> ARGB color model. </param>
        /// <returns> AHSL color model instance. </returns>
        public static AHSLColor FromColor(Color color)
        {
            double r = color.R / 255.0;
            double g = color.G / 255.0;
            double b = color.B / 255.0;

            double min = Math.Min(Math.Min(r, g), b);
            double max = Math.Max(Math.Max(r, g), b);
            double delta = max - min;

            //  Lightness as percentage.
            double l = (max + min) / 2.0;

            if (delta == 0)
            {
                return new AHSLColor(color.A, 0, (int)(l * 100), 0);
            }
            else
            {
                double s = (l <= 0.5) ? (delta / (max + min)) : (delta / (2 - max - min));
                double h = 0;

                if (r == max)
                    h = ((g - b) / 6) / delta;

                else if (g == max)
                    h = (1.0 / 3) + ((b - r) / 6) / delta;

                else
                    h = (2.0 / 3) + ((r - g) / 6) / delta;

                if (h < 0)
                    h += 1;

                if (h > 1)
                    h -= 1;

                return new AHSLColor(color.A, (int)Math.Round(h * 1530), (int)(s * 100), (int)(l * 100));
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Convert AHSL color model to RGB color model. </summary>
        /// <returns> RGB color model instance. </returns>
        public Color ToColor()
        {
            double h = H / 1530.0;
            double l = L / 100.0;
            double s = S / 100.0;

            if (s == 0)
            {
                return Color.FromArgb(A, (byte)(l * 255), (byte)(l * 255), (byte)(l * 255));
            }
            else
            {
                double max = (l < 0.5) ? (l * (1.0 + s)) : ((l + s) - (l * s));
                double min = 2 * l - max;

                double hr = HueToRGB(min, max, h + (1.0 / 3.0));
                double hg = HueToRGB(min, max, h);
                double hb = HueToRGB(min, max, h - (1.0 / 3.0));

                return Color.FromArgb(A, (byte)(hr * 255), (byte)(hg * 255), (byte)(hb * 255));
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Returns a string that represents the current object. </summary>
        /// <returns> String that represents the current object.</returns>
        public override string ToString()
        {
            return $"A:{A} H:{H} S:{S} L:{L}";
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Helper function to calculate RGB component in HSL to RGB conversion. </summary>
        /// <param name="min"> Minimum value. </param>
        /// <param name="max"> Maximum value. </param>
        /// <param name="hue"> The hue value to calculate from. </param>
        /// <returns> The calculated RGB component. </returns>
        private static double HueToRGB(double min, double max, double hue)
        {
            if (hue < 0)
                hue += 1.0;

            if (hue > 1)
                hue -= 1.0;

            if ((6.0 * hue) < 1)
                return (min + (max - min) * 6.0 * hue);

            if ((2.0 * hue) < 1)
                return max;

            if ((3.0 * hue) < 2)
                return (min + (max - min) * ((2.0 / 3.0) - hue) * 6.0);

            return min;
        }

        #endregion CONVERSION

    }
}
