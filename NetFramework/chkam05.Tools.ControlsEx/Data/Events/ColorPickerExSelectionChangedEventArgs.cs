using chkam05.Tools.ControlsEx.Data.Theme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace chkam05.Tools.ControlsEx.Data.Events
{
    public class ColorPickerExSelectionChangedEventArgs : EventArgs
    {

        //  VARIABLES

        public Color Color { get; private set; }
        public bool IsUserModified { get; protected set; }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> ColorPickerExSelectionChangedEventArgs class constructor. </summary>
        /// <param name="color"> Selected color. </param>
        /// <param name="isUserModified"> Is selection triggered from user interface. </param>
        public ColorPickerExSelectionChangedEventArgs(Color color, bool isUserModified)
        {
            Color = color;
            IsUserModified = isUserModified;
        }

        #endregion CONSTRUCTORS

    }
}
