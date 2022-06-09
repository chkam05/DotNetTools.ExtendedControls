﻿using chkam05.Tools.ControlsEx.Example.Data.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace chkam05.Tools.ControlsEx.Example.Pages
{
    public partial class ContextMenusPage : Page, INotifyPropertyChanged
    {

        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        public Configuration Configuration { get; private set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> ContextMenusPage class constructor. </summary>
        public ContextMenusPage()
        {
            //  Initialize data containers.
            Configuration = Configuration.Instance;

            //  Initialize interface components.
            InitializeComponent();
        }

        #endregion CLASS METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Open context menu that belongs to object. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Mouse Button Event Arguments. </param>
        private void OpenContextMenu_Click(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var button = (ButtonEx)sender;

                button.ContextMenu.Visibility = Visibility.Visible;
                button.ContextMenu.PlacementTarget = sender as Button;
                button.ContextMenu.IsOpen = true;
            }
        }

        #endregion INTERACTION METHODS

        #region NOTIFY PROPERTIES CHANGED INTERFACE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method for invoking PropertyChangedEventHandler external method. </summary>
        /// <param name="propertyName"> Changed property name. </param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion NOTIFY PROPERTIES CHANGED INTERFACE METHODS

    }
}
