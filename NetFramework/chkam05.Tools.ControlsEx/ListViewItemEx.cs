using chkam05.Tools.ControlsEx.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace chkam05.Tools.ControlsEx
{
    public class ListViewItemEx : ListViewItem
    {

        //  DEPENDENCY PROPERTIES

        


        //  GETTERS & SETTERS




        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> ListViewItemEx class constructor. </summary>
        static ListViewItemEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ListViewItemEx),
                new FrameworkPropertyMetadata(typeof(ListViewItemEx)));
        }

        #endregion CONSTRUCTORS

    }
}
