using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.ViewModels
{
    /// <summary> Base View Model. </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {

        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> BaseViewModel class constructor. </summary>
        public BaseViewModel()
        {
            //
        }

        #endregion CONSTRUCTORS

        #region PROPERTIES CHANGED NOTIFICATION

        //  --------------------------------------------------------------------------------
        /// <summary> Triggers a property changed notification event. </summary>
        /// <param name="propertyName"> Property name. </param>
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion PROPERTIES CHANGED NOTIFIACTION

        #region PROPERTIES MANAGEMENT

        //  --------------------------------------------------------------------------------
        /// <summary> Sets a value in a property and triggers a property changed notification event. </summary>
        /// <typeparam name="T"> Property value type. </typeparam>
        /// <param name="field"> Reference to property. </param>
        /// <param name="newValue"> Value to set. </param>
        /// <param name="propertyName"> Property name. </param>
        protected virtual void UpdateProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = null)
        {
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentException("Property update failed. Property name cannot be null or empty.");

            field = newValue;

            NotifyPropertyChanged(propertyName);
        }

        #endregion PROPERTIES MANAGEMENT

    }
}
