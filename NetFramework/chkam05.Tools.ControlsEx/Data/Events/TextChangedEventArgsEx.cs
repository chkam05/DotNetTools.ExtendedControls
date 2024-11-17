using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace chkam05.Tools.ControlsEx.Data.Events
{
    public class TextChangedEventArgsEx : TextChangedEventArgs
    {

        //  VARIABLES

        public bool IsUserModified { get; protected set; }
        public bool IsModificationFinished { get; protected set; }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> TextChangedEventArgsEx class constructor. </summary>
        /// <param name="id"> The event identifier (ID). </param>
        /// <param name="undoAction"> The UndoAction caused by the text change. </param>
        /// <param name="isUserModified"> A parameter defining whether the text was entered by the user, e.g. via the keyboard. </param>
        /// <param name="isModificationFinished"> A parameter defining whether user text entry has finished. </param>
        public TextChangedEventArgsEx(RoutedEvent id, UndoAction undoAction,
            bool isUserModified, bool isModificationFinished) : base(id, undoAction)
        {
            IsUserModified = isUserModified;
            IsModificationFinished = isModificationFinished;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> TextChangedEventArgsEx class constructor. </summary>
        /// <param name="id"> The event identifier (ID). </param>
        /// <param name="undoAction"> The UndoAction caused by the text change. </param>
        /// <param name="changes"> The changes that occurred during this event. </param>
        /// <param name="isUserModified"> A parameter defining whether the text was entered by the user, e.g. via the keyboard. </param>
        /// <param name="isModificationFinished"> A parameter defining whether user text entry has finished. </param>
        public TextChangedEventArgsEx(RoutedEvent id, UndoAction undoAction, ICollection<TextChange> changes,
            bool isUserModified, bool isModificationFinished) : base(id, undoAction, changes)
        {
            IsUserModified = isUserModified;
            IsModificationFinished = isModificationFinished;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> TextChangedEventArgsEx class constructor. </summary>
        /// <param name="base"> Base TextChanged event arguments providing data for the TextChanged event. </param>
        // <param name="isUserModified"> A parameter defining whether the text was entered by the user, e.g. via the keyboard. </param>
        /// <param name="isModificationFinished"> A parameter defining whether user text entry has finished. </param>
        public TextChangedEventArgsEx(TextChangedEventArgs @base, bool isUserModified, bool isModificationFinished)
            : base(@base.RoutedEvent, @base.UndoAction, @base.Changes)
        {
            IsUserModified = isUserModified;
            IsModificationFinished = isModificationFinished;
        }

        #endregion CONSTRUCTORS

    }
}
