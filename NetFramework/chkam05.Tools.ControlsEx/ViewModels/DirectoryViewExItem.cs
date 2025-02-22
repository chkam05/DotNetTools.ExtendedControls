using chkam05.Tools.ControlsEx.Data.Collections;
using chkam05.Tools.ControlsEx.Data.Enums;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.ViewModels
{
    public class DirectoryViewExItem : BaseViewModel
    {

        //  EVENTS

        public event EventHandler Collapsed;
        public event EventHandler Expanded;


        //  VARIABLES

        private bool isExpanded;
        private DirectoryViewExCollection items;
        private DirectoryViewExItemType itemType;
        private string path;
        private string name;
        private PackIconKind icon;


        //  GETTERS & SETTERS

        public bool IsExpanded
        {
            get => isExpanded;
            set => UpdateIsExpandedProperty(value);
        }

        public DirectoryViewExCollection Items
        {
            get => items;
            set => UpdateItemsProperty(value);
        }

        public DirectoryViewExItemType ItemType
        {
            get => itemType;
            set => UpdateItemTypeProperty(value);
        }

        public string Path
        {
            get => path;
            set => UpdatePathProperty(value);
        }

        public string Name
        {
            get => name;
            private set => UpdateProperty(ref name, value);
        }

        public PackIconKind Icon
        {
            get => icon;
            private set => UpdateProperty(ref icon, value);
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> DirectoryViewExItem class constructor. </summary>
        /// <param name="path"> Directory path. </param>
        /// <param name="itemType"> Item type. </param>
        public DirectoryViewExItem(string path, DirectoryViewExItemType itemType)
        {
            Path = path;
            ItemType = itemType;
        }

        #endregion CONSTRUCTORS

        #region PROPERTIES CHANGED NOTIFICATION

        //  --------------------------------------------------------------------------------
        /// <summary> Occurs when an item is added, removed, changed, moved, or the entire items collection is refreshed. </summary>
        private void ItemsCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged(nameof(Items));
        }

        #endregion PROPERTIES CHANGED NOTIFIACTION

        #region PROPERTIES MANAGEMENT

        //  --------------------------------------------------------------------------------
        /// <summary> Sets a value in a isExpanded property and triggers a property changed notification event. </summary>
        /// <param name="newValue"> Value to set. </param>
        protected virtual void UpdateIsExpandedProperty(bool newValue)
        {
            isExpanded = newValue;
            NotifyPropertyChanged(nameof(IsExpanded));

            if (newValue == true)
                Expanded?.Invoke(this, EventArgs.Empty);
            else
                Collapsed?.Invoke(this, EventArgs.Empty);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Sets a value in a items property and triggers a property changed notification event. </summary>
        /// <param name="newValue"> Value to set. </param>
        protected virtual void UpdateItemsProperty(DirectoryViewExCollection newValue)
        {
            items = newValue;
            items.CollectionChanged += ItemsCollectionChanged;
            NotifyPropertyChanged(nameof(Items));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Sets a value in a itemType property and triggers a property changed notification event. </summary>
        /// <param name="newValue"> Value to set. </param>
        protected virtual void UpdateItemTypeProperty(DirectoryViewExItemType newValue)
        {
            itemType = newValue;
            NotifyPropertyChanged(nameof(ItemType));

            switch (newValue)
            {
                case DirectoryViewExItemType.Catalog:
                    Icon = PackIconKind.FolderOutline;
                    break;

                case DirectoryViewExItemType.Disc:
                    Icon = PackIconKind.Disc;
                    break;

                case DirectoryViewExItemType.Harddisk:
                    Icon = PackIconKind.Harddisk;
                    break;

                case DirectoryViewExItemType.Usb:
                    Icon = PackIconKind.UsbFlashDrive;
                    break;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Sets a value in a path property and triggers a property changed notification event. </summary>
        /// <param name="newValue"> Value to set. </param>
        protected virtual void UpdatePathProperty(string newValue)
        {
            path = newValue;
            NotifyPropertyChanged(nameof(Path));

            try
            {
                string newName = System.IO.Path.GetFileName(newValue);
                Name = !string.IsNullOrEmpty(newName) ? newName : newValue;
            }
            catch
            {
                Name = path;
            }
        }

        #endregion PROPERTIES MANAGEMENT

    }
}
