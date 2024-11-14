using chkam05.Tools.ControlsEx.Utilities;
using chkam05.Tools.ControlsEx.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace chkam05.Tools.ControlsEx.Data
{
    public class ColorEx : BaseViewModel
    {

        //  VARIABLES

        private Color color;
        private string name;


        //  GETTERS & SETTERS

        public Color Color
        {
            get => color;
            set
            {
                UpdateProperty(ref color, value);
                NotifyPropertyChanged(nameof(ColorCode));

                if (string.IsNullOrEmpty(name))
                    NotifyPropertyChanged(nameof(Name));
            }
        }

        public string ColorCode
        {
            get => ColorsUtilities.ConvertColorToHexString(color);
        }

        public string Name
        {
            get => !string.IsNullOrEmpty(name) ? name : ColorCode;
            set => UpdateProperty(ref name, value);
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> ColorEx class constructor. </summary>
        /// <param name="color"> RGB color model. </param>
        public ColorEx(Color color)
        {
            Color = color;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> ColorEx class constructor. </summary>
        /// <param name="color"> RGB color model. </param>
        /// <param name="name"> Color name. </param>
        public ColorEx(Color color, string name)
        {
            Color = color;
            Name = name;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Create ColorEx instance from hexadecimal color code representation. </summary>
        /// <param name="hexCode"> Hexadecimal color code representation. </param>
        /// <param name="name"> (Optional) Color name. </param>
        /// <returns> ColorEx class instance. </returns>
        public static ColorEx CreateFromHexCode(string hexCode, string name = null)
        {
            return new ColorEx(ColorsUtilities.ConvertHexStringToColor(hexCode), name);
        }

        #endregion CONSTRUCTORS

    }
}
