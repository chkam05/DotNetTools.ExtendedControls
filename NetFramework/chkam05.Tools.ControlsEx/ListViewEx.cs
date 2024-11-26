using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace chkam05.Tools.ControlsEx
{
    public class ListViewEx : ListView
    {

        //  DEPENDENCY PROPERTIES




        //  GETTERS & SETTERS




        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> ListViewEx class constructor. </summary>
        static ListViewEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ListViewEx),
                new FrameworkPropertyMetadata(typeof(ListViewEx)));
        }

        #endregion CONSTRUCTORS

    }
}
