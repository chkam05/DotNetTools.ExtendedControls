using chkam05.Tools.ControlsEx.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Data.Events
{
    public class DirectoryViewerExDoubleClickEventArgs : EventArgs
    {

        //  VARIABLES

        public DirectoryViewExItem Item { get; set; }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> DirectoryViewerExDoubleClickEventArgs class constructor. </summary>
        /// <param name="item"> Selected directory item. </param>
        public DirectoryViewerExDoubleClickEventArgs(DirectoryViewExItem item)
        {
            Item = item;
        }

        #endregion CONSTRUCTORS

    }
}
