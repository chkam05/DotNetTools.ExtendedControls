﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace chkam05.Tools.ControlsEx
{
    public class GridViewItemEx : ListViewItemEx
    {

        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> GridViewItemEx class constructor. </summary>
        static GridViewItemEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GridViewItemEx),
                new FrameworkPropertyMetadata(typeof(GridViewItemEx)));
        }

        #endregion CONSTRUCTORS

    }
}
