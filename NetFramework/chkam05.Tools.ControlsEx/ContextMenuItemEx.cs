using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace chkam05.Tools.ControlsEx
{
    public class ContextMenuItemEx : MenuItemEx
    {

        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> ContextMenuItemEx class constructor. </summary>
        static ContextMenuItemEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ContextMenuItemEx),
                new FrameworkPropertyMetadata(typeof(ContextMenuItemEx)));
        }

        #endregion CONSTRUCTORS

    }
}
