using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace chkam05.Tools.ControlsEx
{
    public class ComboBoxEx : ComboBox
    {

        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> ComboBoxEx class constructor. </summary>
        static ComboBoxEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ComboBoxEx),
                new FrameworkPropertyMetadata(typeof(ComboBoxEx)));
        }

        #endregion CONSTRUCTORS

    }
}
