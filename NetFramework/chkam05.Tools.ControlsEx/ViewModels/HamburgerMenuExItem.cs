using chkam05.Tools.ControlsEx.Data;
using chkam05.Tools.ControlsEx.Data.Enums;
using chkam05.Tools.ControlsEx.Utilities;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml.Linq;

namespace chkam05.Tools.ControlsEx.ViewModels
{
    public class HamburgerMenuExItem : BaseViewModel
    {

        //  VARIABLES

        private string title = string.Empty;
        private string description = string.Empty;
        private ImageSource icon = null;
        private PackIconKind iconKind = PackIconKind.None;
        private Action action = null;
        private HamburgerMenuExItemPosition position = HamburgerMenuExItemPosition.Top;
        private HamburgerMenuExItemType itemType = HamburgerMenuExItemType.Regular;


        //  GETTERS & SETTERS

        public string Title
        {
            get => title;
            set => UpdateProperty(ref title, value);
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

        public Action Action
        {
            get => action;
            set => UpdateProperty(ref action, value);
        }

        public HamburgerMenuExItemPosition Position
        {
            get => position;
            set => UpdateProperty(ref position, value);
        }

        public HamburgerMenuExItemType ItemType
        {
            get => itemType;
            internal set => UpdateProperty(ref itemType, value);
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> HamburgerMenuExItem class constructor. </summary>
        public HamburgerMenuExItem()
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> HamburgerMenuExItem class constructor. </summary>
        /// <param name="title"> Title. </param>
        /// <param name="iconKind"> Icon kind. </param>
        /// <param name="action"> The action that will be called after selecting a menu item. </param>
        /// <param name="position"> Position in menu. </param>
        public HamburgerMenuExItem(string title, PackIconKind iconKind, Action action,
            HamburgerMenuExItemPosition position = HamburgerMenuExItemPosition.Top)
        {
            Title = title;
            IconKind = iconKind;
            Action = action;
            Position = position;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> HamburgerMenuExItem class constructor. </summary>
        /// <param name="title"> Title. </param>
        /// <param name="icon"> Icon as image. </param>
        /// <param name="action"> The action that will be called after selecting a menu item. </param>
        /// <param name="position"> Position in menu. </param>
        public HamburgerMenuExItem(string title, ImageSource icon, Action action,
            HamburgerMenuExItemPosition position = HamburgerMenuExItemPosition.Top)
        {
            Title = title;
            Icon = icon;
            Action = action;
            Position = position;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> HamburgerMenuExItem class constructor. </summary>
        /// <param name="title"> Title. </param>
        /// <param name="description"> Description. </param>
        /// <param name="iconKind"> Icon kind. </param>
        /// <param name="action"> The action that will be called after selecting a menu item. </param>
        /// <param name="position"> Position in menu. </param>
        public HamburgerMenuExItem(string title, string description, PackIconKind iconKind, Action action,
            HamburgerMenuExItemPosition position = HamburgerMenuExItemPosition.Top)
        {
            Title = title;
            Description = description;
            IconKind = iconKind;
            Action = action;
            Position = position;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> HamburgerMenuExItem class constructor. </summary>
        /// <param name="title"> Title. </param>
        /// <param name="description"> Description. </param>
        /// <param name="icon"> Icon as image. </param>
        /// <param name="action"> The action that will be called after selecting a menu item. </param>
        /// <param name="position"> Position in menu. </param>
        public HamburgerMenuExItem(string title, string description, ImageSource icon, Action action,
            HamburgerMenuExItemPosition position = HamburgerMenuExItemPosition.Top)
        {
            Title = title;
            Description = description;
            Icon = icon;
            Action = action;
            Position = position;
        }

        #endregion CONSTRUCTORS

    }
}
