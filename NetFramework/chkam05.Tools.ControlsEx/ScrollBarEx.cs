using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace chkam05.Tools.ControlsEx
{
    public class ScrollBarEx : ScrollBar
    {

        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> Static ScrollBarEx class constructor. </summary>
        static ScrollBarEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ScrollBarEx),
                new FrameworkPropertyMetadata(typeof(ScrollBarEx)));
        }

        #endregion CONSTRUCTORS

    }
}
