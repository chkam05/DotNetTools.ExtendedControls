using chkam05.Tools.ControlsEx.Data;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace chkam05.Tools.ControlsEx.ViewModels
{
    public class HamburgerMenuItemViewModel : BaseViewModel
    {

        //  VARIABLES

        private Action action;
        private string description;
        private ImageSource icon = null;
        private PackIconKind iconKind = PackIconKind.None;
        private HamburgerMenuItemType itemType = HamburgerMenuItemType.Regular;
        private string title;


        //  GETTERS & SETTERS

        public Action Action
        {
            get => action;
            set => UpdateProperty(ref action, value);
        }

        public string Description
        {
            get => description;
            set => UpdateProperty(ref description, value);
        }

        public ImageSource Icon
        {
            get => icon;
            set => UpdateProperty(ref icon, value);
        }

        public PackIconKind IconKind
        {
            get => iconKind;
            set => UpdateProperty(ref iconKind, value);
        }

        public HamburgerMenuItemType ItemType
        {
            get => itemType;
            private set => UpdateProperty(ref itemType, value);
        }

        public string Title
        {
            get => title;
            set => UpdateProperty(ref title, value);
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> HamburgerMenuItemViewModel class constructor. </summary>
        /// <param name="title"> Title. </param>
        /// <param name="action"> The action that will be performed after selecting item. </param>
        public HamburgerMenuItemViewModel(string title, Action action = null)
        {
            Title = title;
            Action = action;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> HamburgerMenuItemViewModel class constructor. </summary>
        /// <param name="title"> Title. </param>
        /// <param name="description"> Description. </param>
        /// <param name="action"> The action that will be performed after selecting item. </param>
        public HamburgerMenuItemViewModel(string title, string description, Action action = null)
        {
            Title = title;
            Description = description;
            Action = action;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> HamburgerMenuItemViewModel class constructor. </summary>
        /// <param name="title"> Title. </param>
        /// <param name="icon"> Custom icon ImageSource. </param>
        /// <param name="action"> The action that will be performed after selecting item. </param>
        public HamburgerMenuItemViewModel(string title, ImageSource icon, Action action = null)
        {
            Title = title;
            Icon = icon;
            Action = action;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> HamburgerMenuItemViewModel class constructor. </summary>
        /// <param name="title"> Title. </param>
        /// <param name="icon"> Custom icon ImageSource. </param>
        /// <param name="description"> Description. </param>
        /// <param name="action"> The action that will be performed after selecting item. </param>
        public HamburgerMenuItemViewModel(string title, ImageSource icon, string description, Action action = null)
        {
            Title = title;
            Icon = icon;
            Description = description;
            Action = action;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> HamburgerMenuItemViewModel class constructor. </summary>
        /// <param name="title"> Title. </param>
        /// <param name="iconKind"> Predefined icon kidn. </param>
        /// <param name="action"> The action that will be performed after selecting item. </param>
        public HamburgerMenuItemViewModel(string title, PackIconKind iconKind, Action action = null)
        {
            Title = title;
            IconKind = iconKind;
            Action = action;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> HamburgerMenuItemViewModel class constructor. </summary>
        /// <param name="title"> Title. </param>
        /// <param name="iconKind"> Predefined icon kidn. </param>
        /// <param name="description"> Description. </param>
        /// <param name="action"> The action that will be performed after selecting item. </param>
        public HamburgerMenuItemViewModel(string title, PackIconKind iconKind, string description, Action action = null)
        {
            Title = title;
            IconKind = iconKind;
            Description = description;
            Action = action;
        }

        #endregion CONSTRUCTORS

        #region STATIC CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> Creates header HamburgerMenuItemViewModel responsible for opening and closing the menu. </summary>
        /// <param name="title"> Custom title. </param>
        /// <param name="iconKind"> Custom icon. </param>
        /// <param name="description"> Custom description. </param>
        /// <param name="action"> Custom action that will be performed after selecting item. </param>
        /// <returns></returns>
        public static HamburgerMenuItemViewModel CreateHeaderItem(string title = "Menu", PackIconKind iconKind = PackIconKind.Menu,
            string description = null, Action action = null)
        {
            return new HamburgerMenuItemViewModel(
                title,
                iconKind,
                description,
                action)
            {
                ItemType = HamburgerMenuItemType.Header
            };
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Creates navigation back HamburgerMenuItemViewModel responsible for back navigation e.g. in pages view. </summary>
        /// <param name="title"> Custom title. </param>
        /// <param name="iconKind"> Custom icon. </param>
        /// <param name="description"> Custom description. </param>
        /// <param name="action"> Custom action that will be performed after selecting item. </param>
        /// <returns></returns>
        public static HamburgerMenuItemViewModel CreateNavigationBackItem(string title = "Menu", PackIconKind iconKind = PackIconKind.Menu,
            string description = null, Action action = null)
        {
            return new HamburgerMenuItemViewModel(
                title,
                iconKind,
                description,
                action)
            {
                ItemType = HamburgerMenuItemType.NavigationBack
            };
        }

        #endregion STATIC CONSTRUCTORS

    }
}
