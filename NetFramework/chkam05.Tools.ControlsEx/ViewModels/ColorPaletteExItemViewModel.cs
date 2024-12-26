﻿using chkam05.Tools.ControlsEx.Data;
using chkam05.Tools.ControlsEx.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace chkam05.Tools.ControlsEx.ViewModels
{
    public class ColorPaletteExItemViewModel : BaseViewModel
    {

        //  VARIABLES

        private SolidColorBrush brush;
        private Color color;
        private bool isAddItem;
        private string name;
        private bool oneWayUpdate = false;


        //  GETTERS & SETTERS

        public SolidColorBrush Brush
        {
            get => brush;
            set
            {
                UpdateProperty(ref brush, value);

                if (!oneWayUpdate)
                    InvokeOneWayUpdate(() => Color = value.Color);
            }
        }

        public Color Color
        {
            get => color;
            set
            {
                UpdateProperty(ref color, value);
                NotifyPropertyChanged(nameof(ColorCode));

                if (string.IsNullOrEmpty(name))
                    NotifyPropertyChanged(nameof(Name));

                if (!oneWayUpdate)
                    InvokeOneWayUpdate(() => Brush = new SolidColorBrush(color));
            }
        }

        public string ColorCode
        {
            get => ColorsUtilities.ConvertColorToHexString(color);
        }

        public bool IsAddItem
        {
            get => isAddItem;
            internal set => UpdateProperty(ref isAddItem, value);
        }

        public string Name
        {
            get => !string.IsNullOrEmpty(name) ? name : ColorCode;
            set => UpdateProperty(ref name, value);
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> ColorPaletteExItemViewModel class constructor. </summary>
        /// <param name="colorEx"> ColorEx model. </param>
        public ColorPaletteExItemViewModel(ColorEx colorEx)
        {
            Color = colorEx.Color;
            Name = colorEx.Name;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> ColorPaletteExItemViewModel class constructor. </summary>
        /// <param name="color"> RGB color model. </param>
        public ColorPaletteExItemViewModel(Color color)
        {
            Color = color;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> ColorPaletteExItemViewModel class constructor. </summary>
        /// <param name="color"> RGB color model. </param>
        /// <param name="name"> Color name. </param>
        public ColorPaletteExItemViewModel(Color color, string name)
        {
            Color = color;
            Name = name;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Create ColorPaletteExItemViewModel instance from hexadecimal color code representation. </summary>
        /// <param name="hexCode"> Hexadecimal color code representation. </param>
        /// <param name="name"> (Optional) Color name. </param>
        /// <returns> ColorPaletteExItemViewModel class instance. </returns>
        public static ColorPaletteExItemViewModel CreateFromHexCode(string hexCode, string name = null)
        {
            return new ColorPaletteExItemViewModel(
                ColorsUtilities.ConvertHexStringToColor(hexCode), name);
        }

        #endregion CONSTRUCTORS

        #region UPDATE

        //  --------------------------------------------------------------------------------
        /// <summary> Performs the action in one way update mode. </summary>
        /// <param name="action"> Action to be performed. </param>
        private void InvokeOneWayUpdate(Action action)
        {
            oneWayUpdate = true;
            action?.Invoke();
            oneWayUpdate = false;
        }

        #endregion UPDATE

    }
}
