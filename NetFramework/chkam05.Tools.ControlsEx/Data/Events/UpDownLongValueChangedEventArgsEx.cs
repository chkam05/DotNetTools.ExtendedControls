using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Data.Events
{
    public class UpDownLongValueChangedEventArgsEx : EventArgs
    {

        //  VARIABLES

        public bool IsUserModified { get; protected set; }
        public bool IsModificationFinished { get; protected set; }
        public long NewValue { get; protected set; }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> UpDownLongValueChangedEventArgsEx class constructor.</summary>
        /// <param name="newValue"> New entered value. </param>
        /// <param name="isUserModified"> A parameter defining whether the text was entered by the user, e.g. via the keyboard. </param>
        /// <param name="isModificationFinished"> A parameter defining whether user text entry has finished. </param>
        public UpDownLongValueChangedEventArgsEx(long newValue, bool isUserModified, bool isModificationFinished) : base()
        {
            IsUserModified = isUserModified;
            IsModificationFinished = isModificationFinished;
            NewValue = newValue;
        }

        #endregion CONSTRUCTORS
    }
}
