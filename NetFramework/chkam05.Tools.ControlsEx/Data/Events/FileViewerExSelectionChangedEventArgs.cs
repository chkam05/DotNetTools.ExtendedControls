using chkam05.Tools.ControlsEx.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Data.Events
{
    public class FileViewerExSelectionChangedEventArgs : EventArgs
    {

        //  VARIABLES

        public FileViewExItem Item { get; set; }
        public bool IsUserModified { get; set; }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> FileViewerExSelectionChangedEventArgs class constructor. </summary>
        /// <param name="item"> Selected file item. </param>
        /// <param name="isUserModified"> Is the selection made by the user interface. </param>
        public FileViewerExSelectionChangedEventArgs(FileViewExItem item, bool isUserModified)
        {
            Item = item;
        }

        #endregion CONSTRUCTORS

    }
}
