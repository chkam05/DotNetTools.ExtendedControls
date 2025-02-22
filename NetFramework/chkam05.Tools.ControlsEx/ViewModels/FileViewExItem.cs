using chkam05.Tools.ControlsEx.Data.Enums;
using MaterialDesignThemes.Wpf;
using chkam05.Tools.ControlsEx.Utilities.Interfaces;
using chkam05.Tools.ControlsEx.Utilities;
using System.IO;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace chkam05.Tools.ControlsEx.ViewModels
{
    public class FileViewExItem : BaseViewModel
    {

        //  VARIABLES

        private FileViewExItemType itemType;
        private string path;
        private string name;
        private PackIconKind icon;
        private IFileViewExItemIconMapper iconMapper;

        private List<string> attributes;
        private DateTime creationDate;
        private string creator;
        private DateTime modificationDate;
        private string modificator;
        private string owner;
        private long size;


        //  GETTERS & SETTERS

        public FileViewExItemType ItemType
        {
            get => itemType;
            set => UpdateProperty(ref itemType, value);
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

        public IFileViewExItemIconMapper IconMapper
        {
            get => iconMapper;
            set => UpdateIconMapperProperty(value);
        }

        public List<string> Attributes
        {
            get => attributes;
            private set => UpdateProperty(ref attributes, value);
        }

        public DateTime CreationDate
        {
            get => creationDate;
            private set => UpdateProperty(ref creationDate, value);
        }

        public string Creator
        {
            get => creator;
            private set => UpdateProperty(ref creator, value);
        }

        public DateTime ModificationDate
        {
            get => modificationDate;
            private set => UpdateProperty(ref modificationDate, value);
        }

        public string Modificator
        {
            get => modificator;
            private set => UpdateProperty(ref modificator, value);
        }

        public string Owner
        {
            get => owner;
            private set => UpdateProperty(ref owner, value);
        }

        public long Size
        {
            get => size;
            private set => UpdateProperty(ref size, value);
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> FileViewExItem class constructor. </summary>
        /// <param name="directoryInfo"> DirectoryInfo object. </param>
        /// <param name="iconMapper"> Icon mapper interface. </param>
        public FileViewExItem(DirectoryInfo directoryInfo, bool includeLength = false, IFileViewExItemIconMapper iconMapper = null)
        {
            Path = directoryInfo.FullName;
            ItemType = FileViewExItemType.Catalog;
            IconMapper = iconMapper ?? new FileViewExItemIconMapper();

            Attributes = FileSystemUtilities.GetDirectoryAttributes(directoryInfo);
            CreationDate = directoryInfo.CreationTime;
            Creator = FileSystemUtilities.GetDirectoryCreator(directoryInfo);
            ModificationDate = directoryInfo.LastWriteTime;
            Modificator = FileSystemUtilities.GetDirectoryModifier(directoryInfo);
            Owner = FileSystemUtilities.GetDirectoryOwner(directoryInfo);
            Size = includeLength ? FileSystemUtilities.GetDirectorySize(directoryInfo) : 0;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> FileViewExItem class constructor. </summary>
        /// <param name="fileInfo"> FileInfo object. </param>
        /// <param name="iconMapper"> Icon mapper interface. </param>
        public FileViewExItem(FileInfo fileInfo, IFileViewExItemIconMapper iconMapper = null)
        {
            Path = fileInfo.FullName;
            ItemType = FileViewExItemType.File;
            IconMapper = iconMapper ?? new FileViewExItemIconMapper();

            Attributes = FileSystemUtilities.GetFileAttributes(fileInfo);
            CreationDate = fileInfo.CreationTime;
            Creator = FileSystemUtilities.GetFileCreator(fileInfo);
            ModificationDate = fileInfo.LastWriteTime;
            Modificator = FileSystemUtilities.GetFileModifier(fileInfo);
            Owner = FileSystemUtilities.GetFileOwner(fileInfo);
            Size = fileInfo.Length;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> FileViewExItem class constructor. </summary>
        /// <param name="driveInfo"> DriveInfo object. </param>
        /// <param name="iconMapper"> Icon mapper interface. </param>
        public FileViewExItem(DriveInfo driveInfo, IFileViewExItemIconMapper iconMapper = null)
        {
            Path = driveInfo.Name;
            ItemType = GetItemType(driveInfo);
            IconMapper = iconMapper ?? new FileViewExItemIconMapper();

            Size = driveInfo.TotalSize;
        }

        #endregion CONSTRUCTORS

        #region PROPERTIES MANAGEMENT

        //  --------------------------------------------------------------------------------
        /// <summary> Sets a value in a path property and triggers a property changed notification event. </summary>
        /// <param name="newValue"> Value to set. </param>
        protected virtual void UpdatePathProperty(string newValue)
        {
            path = newValue;
            NotifyPropertyChanged(nameof(Path));
            UpdateIcon();

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

        //  --------------------------------------------------------------------------------
        /// <summary> Sets a value in a iconMapper property and triggers a property changed notification event. </summary>
        /// <param name="newValue"> Value to set. </param>
        protected virtual void UpdateIconMapperProperty(IFileViewExItemIconMapper newValue)
        {
            iconMapper = newValue;
            NotifyPropertyChanged(nameof(IconMapper));
            UpdateIcon();
        }

        #endregion PROPERTIES MANAGEMENT

        #region UTILITIES

        //  --------------------------------------------------------------------------------
        /// <summary> Get FileViewExItemType based on DriveInfo. </summary>
        /// <param name="driveInfo"> DriveInfo object. </param>
        /// <returns> FileViewExItemType based on DriveInfo. </returns>
        private FileViewExItemType GetItemType(DriveInfo driveInfo)
        {
            switch (driveInfo.DriveType)
            {
                case DriveType.Fixed:
                    return FileViewExItemType.Harddisk;

                case DriveType.Removable:
                    return FileViewExItemType.Usb;

                case DriveType.CDRom:
                    return FileViewExItemType.Disc;
            }

            return FileViewExItemType.Unknown;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Updates item icon using icon mapper. </summary>
        private void UpdateIcon()
        {
            if (iconMapper != null)
                Icon = iconMapper.GetIcon(ItemType, System.IO.Path.GetExtension(path));
        }

        #endregion UTILITIES

    }
}
