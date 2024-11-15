using chkam05.Tools.ControlsEx.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace chkam05.Tools.ControlsEx.Utilities
{
    public static class ColorsUtilities
    {

        //  CONST

        public const double LUMINANCE_R = 0.299;
        public const double LUMINANCE_G = 0.587;
        public const double LUMINANCE_B = 0.114;


        //  METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Convert RGB color model to hexadecimal color code representation. </summary>
        /// <param name="color"> RGB color model. </param>
        /// <returns> Hexadecimal color code representation. </returns>
        public static string ConvertColorToHexString(Color color)
        {
            return $"#{color.R:X2}{color.G:X2}{color.B:X2}";
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Convert hexadecimal color code representation to RGB color model. </summary>
        /// <param name="colorCode"> Hexadecimal color code representation. </param>
        /// <returns> RGB color model instance. </returns>
        public static Color ConvertHexStringToColor(string colorCode)
        {
            return (Color)ColorConverter.ConvertFromString(colorCode);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get foreground color depending on background color. </summary>
        /// <param name="backgroundColor"> RGB background color. </param>
        /// <returns> RBG foreground color instance. </returns>
        public static Color GetForegroundColorDependingOnBackground(Color backgroundColor)
        {
            double luminance = (LUMINANCE_R * backgroundColor.R + LUMINANCE_G * backgroundColor.G
                + LUMINANCE_B * backgroundColor.B) / 255;

            if (luminance > 0.5)
                return Colors.Black;
            else
                return Colors.White;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Update AHSL color model with new component values. </summary>
        /// <param name="color"> AHSL color model. </param>
        /// <param name="a"> Alpha. </param>
        /// <param name="h"> Hue. </param>
        /// <param name="s"> Saturation. </param>
        /// <param name="l"> Lightness. </param>
        /// <returns> Updated AHSL color model. </returns>
        public static AHSLColor UpdateColor(AHSLColor color, byte? a = null, int? h = null, int? s = null, int? l = null)
        {
            return new AHSLColor(
                a.HasValue ? a.Value : color.A,
                h.HasValue ? h.Value : color.H,
                s.HasValue ? s.Value : color.S,
                l.HasValue ? l.Value : color.L);
        }

    }
}
