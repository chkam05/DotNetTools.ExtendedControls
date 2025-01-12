using chkam05.Tools.ControlsEx.Data.Collections;
using chkam05.Tools.ControlsEx.Data.Enums;
using chkam05.Tools.ControlsEx.ViewModels;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Example.Data
{
    public class MainWindowDataContext : BaseViewModel
    {

        //  VARIABLES

        private HamburgerMenuExCollection hamburgerMenuExItemsCollection;


        //  GETTERS & SETTERS

        public HamburgerMenuExCollection HamburgerMenuExCollection
        {
            get => hamburgerMenuExItemsCollection;
            set => UpdateProperty(ref hamburgerMenuExItemsCollection, value);
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> MainWindowDataContext class constructor. </summary>
        public MainWindowDataContext()
        {
            SetupHamburgerMenuExCollection();
        }

        #endregion CONSTRUCTORS

        #region ACTIONS

        //  --------------------------------------------------------------------------------
        private void HomeHamburgerMenuExItemAction()
        {
            //
        }

        //  --------------------------------------------------------------------------------
        private void SettingsHamburgerMenuExItemAction()
        {
            //
        }

        //  --------------------------------------------------------------------------------
        private void InfoHamburgerMenuExItemAction()
        {
            //
        }

        #endregion ACTIONS

        #region SETUP

        //  --------------------------------------------------------------------------------
        private void SetupHamburgerMenuExCollection()
        {
            HamburgerMenuExCollection = new HamburgerMenuExCollection()
            {
                new HamburgerMenuExItemViewModel("Components", "Component testing", PackIconKind.CubeOutline,
                    HomeHamburgerMenuExItemAction),
                new HamburgerMenuExItemViewModel("Settings", "Application settings.", PackIconKind.GearOutline,
                    SettingsHamburgerMenuExItemAction, HamburgerMenuExItemPosition.Bottom),
                new HamburgerMenuExItemViewModel("Info", "Application information.", PackIconKind.InfoCircleOutline,
                    InfoHamburgerMenuExItemAction, HamburgerMenuExItemPosition.Bottom)
            };
        }

        #endregion SETUP

    }
}
