using chkam05.Tools.ControlsEx.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Data.Events
{
    public class FileViewerExDoubleClickEventArgs : EventArgs
    {

        //  VARIABLES

        public FileViewExItem Item { get; set; }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> FileViewerExDoubleClickEventArgs class constructor. </summary>
        /// <param name="item"> Selected file item. </param>
        public FileViewerExDoubleClickEventArgs(FileViewExItem item)
        {
            Item = item;
        }

        #endregion CONSTRUCTORS

    }
}
