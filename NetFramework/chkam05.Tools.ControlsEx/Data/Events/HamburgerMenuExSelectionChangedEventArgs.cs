using chkam05.Tools.ControlsEx.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace chkam05.Tools.ControlsEx.Data.Events
{
    public class HamburgerMenuExSelectionChangedEventArgs : EventArgs
    {

        //  VARIABLES

        public HamburgerMenuExItemViewModel MenuItem { get; set; }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> HamburgerMenuExSelectionChangedEventArgs class constructor. </summary>
        /// <param name="menuItem"> Selected menu item. </param>
        public HamburgerMenuExSelectionChangedEventArgs(HamburgerMenuExItemViewModel menuItem)
        {
            MenuItem = menuItem;
        }

        #endregion CONSTRUCTORS

    }
}
