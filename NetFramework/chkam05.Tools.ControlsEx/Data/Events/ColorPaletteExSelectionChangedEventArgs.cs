using chkam05.Tools.ControlsEx.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace chkam05.Tools.ControlsEx.Data.Events
{
    public class ColorPaletteExSelectionChangedEventArgs : EventArgs
    {

        //  VARIABLES

        public ColorPaletteExItemViewModel Color { get; private set; }
        public bool IsUserModified { get; protected set; }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> ColorPaletteExSelectionChangedEventArgs class constructor. </summary>
        /// <param name="color"> Selected color item view model. </param>
        public ColorPaletteExSelectionChangedEventArgs(ColorPaletteExItemViewModel color, bool isUserModified)
        {
            Color = color;
            IsUserModified = isUserModified;
        }

        #endregion CONSTRUCTORS

    }
}
