using chkam05.Tools.ControlsEx.ViewModels;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace chkam05.Tools.ControlsEx.Example.Windows
{
    public partial class MainWindow : WindowEx, INotifyPropertyChanged
    {

        //  EVENTS

        public event PropertyChangedEventHandler PropertyChanged;


        //  VARIABLES

        private ObservableCollection<HamburgerMenuItemViewModel> hamburgerMenuItems;


        //  GETTERS & SETTERS

        public ObservableCollection<HamburgerMenuItemViewModel> HamburgerMenuItems
        {
            get => hamburgerMenuItems;
            set
            {
                hamburgerMenuItems = value;
                hamburgerMenuItems.CollectionChanged += (s, e)
                    => NotifyPropertyChanged(nameof(HamburgerMenuItems));
                NotifyPropertyChanged(nameof(HamburgerMenuItems));
            }
        }


        //  METHODS

        public MainWindow(object args)
        {
            InitializeComponent();

            HamburgerMenuItems = new ObservableCollection<HamburgerMenuItemViewModel>()
            {
                HamburgerMenuItemViewModel.CreateHeaderItem(),
                new HamburgerMenuItemViewModel("Home", PackIconKind.Home, "Show home page"),
                new HamburgerMenuItemViewModel("Settings", PackIconKind.Gear, "Show settings page"),
                new HamburgerMenuItemViewModel("Info", PackIconKind.InfoBox, "Show info page"),
            };
        }

        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
