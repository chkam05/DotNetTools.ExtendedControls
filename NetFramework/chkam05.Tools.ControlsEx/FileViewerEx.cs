﻿using chkam05.Tools.ControlsEx.Data;
using chkam05.Tools.ControlsEx.Data.Collections;
using chkam05.Tools.ControlsEx.Data.Enums;
using chkam05.Tools.ControlsEx.Data.Events;
using chkam05.Tools.ControlsEx.Resources;
using chkam05.Tools.ControlsEx.Utilities;
using chkam05.Tools.ControlsEx.Utilities.Interfaces;
using chkam05.Tools.ControlsEx.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using static MaterialDesignThemes.Wpf.Theme;
using static MaterialDesignThemes.Wpf.Theme.ToolBar;

namespace chkam05.Tools.ControlsEx
{
    public class FileViewerEx : Control
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty BackgroundInactiveProperty = DependencyProperty.Register(
            nameof(BackgroundInactive),
            typeof(Brush),
            typeof(FileViewerEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightInactive)));

        public static readonly DependencyProperty BorderBrushInactiveProperty = DependencyProperty.Register(
            nameof(BorderBrushInactive),
            typeof(Brush),
            typeof(FileViewerEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightInactive)));

        public static readonly DependencyProperty CatalogListeningProperty = DependencyProperty.Register(
            nameof(CatalogListening),
            typeof(bool),
            typeof(FileViewerEx),
            new PropertyMetadata(true, CatalogListeningPropertyChangedCallback));

        public static readonly DependencyProperty ColumnsSourceProperty = DependencyProperty.Register(
            nameof(ColumnsSource),
            typeof(GridViewExColumnConfigCollection<FileViewExColumnFieldType>),
            typeof(FileViewerEx),
            new PropertyMetadata(GetDefaultColumnItems(), ColumnsSourcePropertyChangedCallback));

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(FileViewerEx),
            new PropertyMetadata(new CornerRadius(4)));

        public static readonly DependencyProperty ExtensionFilterProperty = DependencyProperty.Register(
            nameof(ExtensionFilter),
            typeof(ObservableCollection<string>),
            typeof(FileViewerEx),
            new PropertyMetadata(null, ExtensionFilterPropertyChangedCallback));

        public static readonly DependencyProperty ForegroundInactiveProperty = DependencyProperty.Register(
            nameof(ForegroundInactive),
            typeof(Brush),
            typeof(FileViewerEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DarkInactive)));

        public static readonly DependencyProperty IconMapperProperty = DependencyProperty.Register(
            nameof(IconMapper),
            typeof(IFileViewExItemIconMapper),
            typeof(FileViewerEx),
            new PropertyMetadata(new FileViewExItemIconMapper(), IconMapperChangedCallback));

        public static readonly DependencyProperty ItemIconSizeProperty = DependencyProperty.Register(
            nameof(ItemIconSize),
            typeof(double),
            typeof(FileViewerEx),
            new PropertyMetadata(72d));

        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(
            nameof(ItemsSource),
            typeof(FileViewExCollection),
            typeof(FileViewerEx),
            new PropertyMetadata(GetDefaultItems()));

        public static readonly DependencyProperty NameFilterProperty = DependencyProperty.Register(
            nameof(NameFilter),
            typeof(string),
            typeof(FileViewerEx),
            new PropertyMetadata(null, NameFilterPropertyChangedCallback));

        public static readonly DependencyProperty PathProperty = DependencyProperty.Register(
            nameof(Path),
            typeof(string),
            typeof(FileViewerEx),
            new PropertyMetadata(null, PathPropertyChangedCallback));

        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(
            nameof(SelectedItem),
            typeof(FileViewExItem),
            typeof(FileViewerEx),
            new PropertyMetadata(null, SelectedItemPropertyChangedCallback));

        public static readonly DependencyProperty ScrollViewerStyleProperty = DependencyProperty.Register(
            nameof(ScrollViewerStyle),
            typeof(Style),
            typeof(FileViewerEx),
            new PropertyMetadata(GetGenericScrollViewerExStyle()));

        public static readonly DependencyProperty ShowDirectoriesProperty = DependencyProperty.Register(
            nameof(ShowDirectories),
            typeof(bool),
            typeof(FileViewerEx),
            new PropertyMetadata(true, ShowDirectoriesPropertyChangedCallback));

        public static readonly DependencyProperty ShowHiddenProperty = DependencyProperty.Register(
            nameof(ShowHidden),
            typeof(bool),
            typeof(FileViewerEx),
            new PropertyMetadata(false, ShowHiddenPropertyChangedCallback));

        public static readonly DependencyProperty ShowSystemProperty = DependencyProperty.Register(
            nameof(ShowSystem),
            typeof(bool),
            typeof(FileViewerEx),
            new PropertyMetadata(false, ShowSystemPropertyChangedCallback));

        public static readonly DependencyProperty ViewTypeProperty = DependencyProperty.Register(
            nameof(ViewType),
            typeof(FileViewExViewType),
            typeof(FileViewerEx),
            new PropertyMetadata(FileViewExViewType.Icons, ViewTypePropertyChangedCallback));


        //  DELEGATES

        public delegate void FileViewerExDoubleClickEventHandler(object sender, FileViewerExDoubleClickEventArgs e);
        public delegate void FileViewerExSelectionChangedEventHandler(object sender, FileViewerExSelectionChangedEventArgs e);


        //  EVENTS

        public event FileViewerExDoubleClickEventHandler DoubleClick;
        public event FileViewerExSelectionChangedEventHandler SelectionChanged;


        //  VARIABLES

        private FileSystemWatcher catalogWatcher = null;
        private ManagementEventWatcher diskWatcher = null;
        private ListViewEx listView = null;
        private ListViewExColumnCreator<FileViewExColumnFieldType> listViewColumnCreator;
        private bool diskWatcherStopped = true;
        private bool isSelecting = false;


        //  GETTERS & SETTERS

        public Brush BackgroundInactive
        {
            get => (Brush)GetValue(BackgroundInactiveProperty);
            set => SetValue(BackgroundInactiveProperty, value);
        }

        public Brush BorderBrushInactive
        {
            get => (Brush)GetValue(BorderBrushInactiveProperty);
            set => SetValue(BorderBrushInactiveProperty, value);
        }

        public bool CatalogListening
        {
            get => (bool)GetValue(CatalogListeningProperty);
            set => SetValue(CatalogListeningProperty, value);
        }

        public GridViewExColumnConfigCollection<FileViewExColumnFieldType> ColumnsSource
        {
            get => (GridViewExColumnConfigCollection<FileViewExColumnFieldType>)GetValue(ColumnsSourceProperty);
            set => SetValue(ColumnsSourceProperty, value);
        }

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public ObservableCollection<string> ExtensionFilter
        {
            get => (ObservableCollection<string>)GetValue(ExtensionFilterProperty);
            set => SetValue(ExtensionFilterProperty, value);
        }

        public Brush ForegroundInactive
        {
            get => (Brush)GetValue(ForegroundInactiveProperty);
            set => SetValue(ForegroundInactiveProperty, value);
        }

        public IFileViewExItemIconMapper IconMapper
        {
            get => (IFileViewExItemIconMapper)GetValue(IconMapperProperty);
            set => SetValue(IconMapperProperty, value);
        }

        public double ItemIconSize
        {
            get => (double)GetValue(ItemIconSizeProperty);
            set => SetValue(ItemIconSizeProperty, value);
        }

        public FileViewExCollection ItemsSource
        {
            get => (FileViewExCollection)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public string NameFilter
        {
            get => (string)GetValue(NameFilterProperty);
            set => SetValue(NameFilterProperty, value);
        }

        public string Path
        {
            get => (string)GetValue(PathProperty);
            set => SetValue(PathProperty, value);
        }

        public FileViewExItem SelectedItem
        {
            get => (FileViewExItem)GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        public Style ScrollViewerStyle
        {
            get => (Style)GetValue(ScrollViewerStyleProperty);
            set => SetValue(ScrollViewerStyleProperty, value);
        }

        public bool ShowDirectories
        {
            get => (bool)GetValue(ShowDirectoriesProperty);
            set => SetValue(ShowDirectoriesProperty, value);
        }

        public bool ShowHidden
        {
            get => (bool)GetValue(ShowHiddenProperty);
            set => SetValue(ShowHiddenProperty, value);
        }

        public bool ShowSystem
        {
            get => (bool)GetValue(ShowSystemProperty);
            set => SetValue(ShowSystemProperty, value);
        }

        public FileViewExViewType ViewType
        {
            get => (FileViewExViewType)GetValue(ViewTypeProperty);
            set => SetValue(ViewTypeProperty, value);
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> FileViewerEx class constructor. </summary>
        static FileViewerEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FileViewerEx),
                new FrameworkPropertyMetadata(typeof(FileViewerEx)));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> FileViewerEx class constructor. </summary>
        public FileViewerEx()
        {
            var gridViewBindingMapper = new FileViewExColumnBindingMapper();
            listViewColumnCreator = new ListViewExColumnCreator<FileViewExColumnFieldType>(gridViewBindingMapper);

            ItemsSource = CreateCollection();
            Unloaded += OnUnloaded;
        }

        #endregion CONSTRUCTORS

        #region CATALOG WATCHER

        //  --------------------------------------------------------------------------------
        /// <summary> Updates the subitems structure of a DirectoryViewExItem object after changes in the affected directory. </summary>
        /// <param name="item"> DirectoryViewExItem object representing the affected directory. </param>
        private void OnDirectoryUpdate()
        {
            UpdateDirectories();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Updates the subitems structure of a DirectoryViewExItem object after changes in the affected directory. </summary>
        /// <param name="item"> DirectoryViewExItem object representing the affected directory. </param>
        /// <param name="oldPath"> Old path before renaming. </param>
        /// <param name="newPath"> New path after renaming. </param>
        private void OnDirectoryUpdate(string oldPath, string newPath)
        {
            if (Path == oldPath)
                Path = newPath;
            else
                UpdateDirectories();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Starts listening for catalog file system changes. </summary>
        private void StartWatchingDirectory()
        {
            if (catalogWatcher != null)
                StopWatchingDirectory();

            if (CatalogListening)
            {
                if (!Directory.Exists(Path))
                    return;

                var watcher = new FileSystemWatcher(Path)
                {
                    IncludeSubdirectories = false,
                    NotifyFilter = NotifyFilters.DirectoryName | NotifyFilters.FileName
                };

                watcher.Created += (s, e) => OnDirectoryUpdate();
                watcher.Deleted += (s, e) => OnDirectoryUpdate();
                watcher.Renamed += (s, e) => OnDirectoryUpdate(e.OldFullPath, e.FullPath);
                watcher.EnableRaisingEvents = true;

                catalogWatcher = watcher;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Stop listening for catalog file system changes. </summary>
        private void StopWatchingDirectory()
        {
            if (catalogWatcher != null)
            {
                catalogWatcher.EnableRaisingEvents = false;
                catalogWatcher.Dispose();
                catalogWatcher = null;
            }
        }

        #endregion CATALOG WATCHER

        #region CONTROL

        //  --------------------------------------------------------------------------------
        /// <summary> Triggered when a component is unloaded. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Routed event arguments. </param>
        protected void OnUnloaded(object sender, RoutedEventArgs e)
        {
            StopDiskWatcher();
            StopWatchingDirectory();
        }

        #endregion CONTROL

        #region DISK WATCHER

        //  --------------------------------------------------------------------------------
        /// <summary> Triggered when a disk device is connected or disconnected. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Event arrived event args. </param>
        private void OnDiskChanged(object sender, EventArrivedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                UpdateDrives();
            });
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Starts listening for device changes. </summary>
        private void StartDiskWatcher()
        {
            if (diskWatcher != null && !diskWatcherStopped)
                StopDiskWatcher();

            var query = new WqlEventQuery("SELECT * FROM Win32_VolumeChangeEvent WHERE EventType = 2 OR EventType = 3");

            diskWatcher = new ManagementEventWatcher(query);
            diskWatcher.EventArrived += OnDiskChanged;
            diskWatcher.Stopped += (s, e) => { diskWatcherStopped = true; };

            diskWatcherStopped = false;
            diskWatcher.Start();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Stops listening for device changes. </summary>
        private void StopDiskWatcher()
        {
            if (diskWatcher != null)
            {
                diskWatcher.Stop();
                diskWatcher.Dispose();
                diskWatcher = null;
            }

            diskWatcherStopped = true;
        }

        #endregion DISK WATCHER

        #region ITEMS

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked after ColumnsSource collection changed. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Notify collection changed event arguments. </param>
        private void OnColumnsSourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            BuildGridColumns();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Create FileViewExItem collection. </summary>
        /// <returns> FileViewItemEx collection. </returns>
        private FileViewExCollection CreateCollection()
        {
            StopDiskWatcher();
            StopWatchingDirectory();

            if (string.IsNullOrEmpty(Path))
                return CreateDrivesCollection();
            else
                return CreateDirectoryCollection(Path);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Create collection of files and catalogs/folders placed in specified directory. </summary>
        /// <param name="path"> Directory path. </param>
        /// <returns> Collection of files and catalogs/folders placed in specified directory. </returns>
        private FileViewExCollection CreateDirectoryCollection(string path)
        {
            var collection = new FileViewExCollection();

            if (ShowDirectories)
            {
                foreach (var directoryInfo in FileSystemUtilities.GetCatalogs(path))
                {
                    var directoryItem = new FileViewExItem(directoryInfo, iconMapper: IconMapper);
                    collection.Add(directoryItem);
                }
            }

            foreach (var fileInfo in FileSystemUtilities.GetFiles(path))
            {
                var fileItem = new FileViewExItem(fileInfo, IconMapper);
                collection.Add(fileItem);
            }

            StartWatchingDirectory();
            return collection;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Create collection of disk/drives devices plugged to the computer. </summary>
        /// <returns> Plugged to the computer disk/drives collection. </returns>
        private FileViewExCollection CreateDrivesCollection()
        {
            var collection = new FileViewExCollection();

            foreach (var driveInfo in FileSystemUtilities.GetDrives())
            {
                var driveItem = new FileViewExItem(driveInfo, IconMapper);
                collection.Add(driveItem);
            }

            StartDiskWatcher();
            return collection;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Creates a default ColumnItems collection. </summary>
        /// <returns> Default ColumnItems collection. </returns>
        private static GridViewExColumnConfigCollection<FileViewExColumnFieldType> GetDefaultColumnItems()
        {
            return new GridViewExColumnConfigCollection<FileViewExColumnFieldType>()
            {
                new GridViewColumnConfig<FileViewExColumnFieldType>(FileViewExColumnFieldType.Icon, "Icon", GridViewExColumnType.PackIcon, 48),
                new GridViewColumnConfig<FileViewExColumnFieldType>(FileViewExColumnFieldType.Name, "Name", 256),
                new GridViewColumnConfig<FileViewExColumnFieldType>(FileViewExColumnFieldType.Size, "Size", 72),
                new GridViewColumnConfig<FileViewExColumnFieldType>(FileViewExColumnFieldType.Owner, "Owner", 128),
            };
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Creates a default ItemsSource collection. </summary>
        /// <returns> Default ItemsSource collection. </returns>
        private static FileViewExCollection GetDefaultItems()
        {
            return new FileViewExCollection();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Triggers SelectionChanged event after changing selection. </summary>
        /// <param name="selectedItem"> Selected item. </param>
        private void InvokeSelectionChanged(FileViewExItem selectedItem)
        {
            SelectionChanged?.Invoke(this, new FileViewerExSelectionChangedEventArgs(selectedItem, isSelecting));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked after double click. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Mouse button event arguments. </param>
        private void OnViewExMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListViewEx listViewEx)
            {
                var element = listViewEx.InputHitTest(e.GetPosition(listView)) as FrameworkElement;

                if (element != null)
                {
                    var item = element.DataContext as FileViewExItem;

                    if (item != null)
                        DoubleClick?.Invoke(this, new FileViewerExDoubleClickEventArgs(item));
                }
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Manages the selection of elements on the FileViewerEx. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Selection changed event arguments. </param>
        private void OnViewExSelectedItemChanged(object sender, SelectionChangedEventArgs e)
        {
            InvokeInSelectingModeEnabled(() =>
            {
                try
                {
                    var selectedItems = e.AddedItems.Cast<FileViewExItem>().ToList();

                    if (selectedItems.Any())
                        SelectedItem = selectedItems.First();
                }
                catch
                {
                    SelectedItem = null;
                }
            });
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Update list of files and catalogs/folders after files/folders modification. </summary>
        /// <param name="rebuild"> If set to true, it does not update the list, it just rebuilds it. </param>
        private void UpdateDirectories(bool rebuild = false)
        {
            if (string.IsNullOrEmpty(Path))
                return;

            if (rebuild)
            {
                ItemsSource = CreateCollection();
                return;
            }

            StopWatchingDirectory();

            int itemIndex = 0;

            if (ShowDirectories)
            {
                var newCatalogs = FileSystemUtilities.GetCatalogs(Path);
                var removedCatalogs = ItemsSource.Where(i => !newCatalogs.Any(c => c.FullName == i.Path));

                ItemsSource.RemoveRange(removedCatalogs);

                foreach (var newCatalog in newCatalogs)
                {
                    if (!ItemsSource.Any(i => i.Path == newCatalog.FullName))
                        ItemsSource.Insert(itemIndex, new FileViewExItem(newCatalog, iconMapper: IconMapper));

                    itemIndex++;
                }
            }

            var newFiles = FileSystemUtilities.GetFiles(Path);
            var removedFiles = ItemsSource.Where(i => !newFiles.Any(f => f.FullName == i.Path));

            ItemsSource.RemoveRange(removedFiles);

            foreach (var newFile in newFiles)
            {
                if (!ItemsSource.Any(i => i.Path == newFile.FullName))
                    ItemsSource.Insert(itemIndex, new FileViewExItem(newFile, IconMapper));

                itemIndex++;
            }

            StartWatchingDirectory();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Update list of disk/drives after removing device or inserting new drive device. </summary>
        /// <param name="rebuild"> If set to true, it does not update the list, it just rebuilds it. </param>
        private void UpdateDrives(bool rebuild = false)
        {
            if (rebuild)
            {
                ItemsSource = CreateCollection();
                return;
            }

            StopDiskWatcher();

            int itemIndex = 0;
            var newDrives = FileSystemUtilities.GetDrives();
            var removedDrives = ItemsSource.Where(i => !newDrives.Any(d => d.Name == i.Path));

            ItemsSource.RemoveRange(removedDrives);

            foreach (var newDrive in newDrives)
            {
                if (!ItemsSource.Any(i => i.Path == newDrive.Name))
                    ItemsSource.Insert(itemIndex, new FileViewExItem(newDrive, IconMapper));

                itemIndex++;
            }

            StartDiskWatcher();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Updates selection item in list view. </summary>
        /// <param name="newSelectedItem"> Selected FileViewExItem object. </param>
        private void UpdateSelectionFromItem(FileViewExItem newSelectedItem)
        {
            if (isSelecting)
                return;

            if (ItemsSource.Contains(newSelectedItem))
                listView.SelectedItem = newSelectedItem;
        }

        #endregion ITEMS

        #region PROPERTIES CHANGED CALLBACKS

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when CatalogsListening property changes. </summary>
        /// <param name="d"> Dependency object from which event has been invoked. </param>
        /// <param name="e"> Dependency property changed event arguments. </param>
        private static void CatalogListeningPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var fileViewerEx = d as FileViewerEx;

            if (fileViewerEx != null && e.NewValue is bool enabled)
            {
                if (enabled)
                    fileViewerEx.StartWatchingDirectory();
                else
                    fileViewerEx.StopWatchingDirectory();
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when ColumnsSource property changes. </summary>
        /// <param name="d"> Dependency object from which event has been invoked. </param>
        /// <param name="e"> Dependency property changed event arguments. </param>
        private static void ColumnsSourcePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var fileViewerEx = d as FileViewerEx;

            if (fileViewerEx != null && e.NewValue is GridViewExColumnConfigCollection<FileViewExColumnFieldType> columnsCollection)
            {
                if (e.OldValue is GridViewExColumnConfigCollection<FileViewExColumnFieldType> oldCollection && oldCollection != columnsCollection)
                    oldCollection.CollectionChanged -= fileViewerEx.OnColumnsSourceCollectionChanged;

                columnsCollection.CollectionChanged += fileViewerEx.OnColumnsSourceCollectionChanged;
                fileViewerEx.BuildGridColumns();
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when ExtensionFilter property changes. </summary>
        /// <param name="d"> Dependency object from which event has been invoked. </param>
        /// <param name="e"> Dependency property changed event arguments. </param>
        private static void ExtensionFilterPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var fileViewerEx = d as FileViewerEx;

            if (fileViewerEx != null && !string.IsNullOrEmpty(fileViewerEx.Path))
                fileViewerEx.UpdateDirectories(true);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when IconMapper property changes. </summary>
        /// <param name="d"> Dependency object from which event has been invoked. </param>
        /// <param name="e"> Dependency property changed event arguments. </param>
        private static void IconMapperChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var fileViewerEx = d as FileViewerEx;

            if ((fileViewerEx?.ItemsSource?.Any() ?? false) && e.NewValue is IFileViewExItemIconMapper iconMapper)
            {
                foreach (var item in fileViewerEx.ItemsSource)
                    item.IconMapper = iconMapper;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when NameFilter property changes. </summary>
        /// <param name="d"> Dependency object from which event has been invoked. </param>
        /// <param name="e"> Dependency property changed event arguments. </param>
        private static void NameFilterPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var fileViewerEx = d as FileViewerEx;

            if (fileViewerEx != null && !string.IsNullOrEmpty(fileViewerEx.Path))
                fileViewerEx.UpdateDirectories(true);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when Path property changes. </summary>
        /// <param name="d"> Dependency object from which event has been invoked. </param>
        /// <param name="e"> Dependency property changed event arguments. </param>
        private static void PathPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var fileViewerEx = d as FileViewerEx;

            if (fileViewerEx != null)
            {
                if (string.IsNullOrEmpty(fileViewerEx?.Path))
                    fileViewerEx.UpdateDrives(true);
                else
                    fileViewerEx.UpdateDirectories(true);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when SelectedItem property changes. </summary>
        /// <param name="d"> Dependency object from which event has been invoked. </param>
        /// <param name="e"> Dependency property changed event arguments. </param>
        private static void SelectedItemPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var fileViewerEx = d as FileViewerEx;

            if (fileViewerEx != null && e.NewValue is FileViewExItem item && item != null)
            {
                fileViewerEx.InvokeSelectionChanged(item);
                fileViewerEx.UpdateSelectionFromItem(item);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when ShowDirectories property changes. </summary>
        /// <param name="d"> Dependency object from which event has been invoked. </param>
        /// <param name="e"> Dependency property changed event arguments. </param>
        private static void ShowDirectoriesPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var fileViewerEx = d as FileViewerEx;

            if (fileViewerEx != null && !string.IsNullOrEmpty(fileViewerEx.Path))
                fileViewerEx.UpdateDirectories(true);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when ShowHidden property changes. </summary>
        /// <param name="d"> Dependency object from which event has been invoked. </param>
        /// <param name="e"> Dependency property changed event arguments. </param>
        private static void ShowHiddenPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var fileViewerEx = d as FileViewerEx;

            if (fileViewerEx != null && !string.IsNullOrEmpty(fileViewerEx.Path))
                fileViewerEx.UpdateDirectories(true);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when ShowSystem property changes. </summary>
        /// <param name="d"> Dependency object from which event has been invoked. </param>
        /// <param name="e"> Dependency property changed event arguments. </param>
        private static void ShowSystemPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var fileViewerEx = d as FileViewerEx;

            if (fileViewerEx != null && !string.IsNullOrEmpty(fileViewerEx.Path))
                fileViewerEx.UpdateDirectories(true);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when ViewType property changes. </summary>
        /// <param name="d"> Dependency object from which event has been invoked. </param>
        /// <param name="e"> Dependency property changed event arguments. </param>
        private static void ViewTypePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var fileViewerEx = d as FileViewerEx;

            if (fileViewerEx != null && e.NewValue is FileViewExViewType viewType)
                fileViewerEx.UpdateView(viewType, e.OldValue as FileViewExViewType?);
        }

        #endregion PROPERTIES CHANGED CALLBACKS

        #region STYLES

        //  --------------------------------------------------------------------------------
        /// <summary> Get generic ScrollViewerEx style from resources. </summary>
        /// <returns> ScrollViewerEx style. </returns>
        protected static Style GetGenericScrollViewerExStyle()
        {
            var uri = new Uri("pack://application:,,,/chkam05.Tools.ControlsEx;component/Themes/ScrollViewerEx.xaml", UriKind.Absolute);
            var resourceDictionary = new ResourceDictionary { Source = uri };
            return resourceDictionary["ScrollViewerExStyle"] as Style;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get ListViewItemEx data template from resources, based on view type configuration. </summary>
        /// <param name="viewType"> View type. </param>
        /// <returns> ListViewItemEx data template. </returns>
        private static DataTemplate GetListViewExDataTemplate(FileViewExViewType viewType)
        {
            string resourceKey = "FileViewerEx.Icon.DataTemplate";

            switch (viewType)
            {
                case FileViewExViewType.Icons:
                    resourceKey = "FileViewerEx.Icon.DataTemplate";
                    break;

                case FileViewExViewType.SmallIcons:
                    resourceKey = "FileViewerEx.SmallIcon.DataTemplate";
                    break;

                case FileViewExViewType.Tails:
                    resourceKey = "FileViewerEx.Tile.DataTemplate";
                    break;

                case FileViewExViewType.List:
                    resourceKey = "FileViewerEx.List.DataTemplate";
                    break;

                case FileViewExViewType.Details:
                    resourceKey = null;
                    break;
            }

            if (string.IsNullOrEmpty(resourceKey))
                return null;

            var uri = new Uri("pack://application:,,,/chkam05.Tools.ControlsEx;component/Themes/FileViewerEx.xaml", UriKind.Absolute);
            var resourceDictionary = new ResourceDictionary { Source = uri };
            return resourceDictionary[resourceKey] as DataTemplate;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get ListViewItemEx style from resources, based on view type configuration. </summary>
        /// <param name="viewType"> View type. </param>
        /// <returns> ListViewItemEx style. </returns>
        private static Style GetListViewItemExStyle(FileViewExViewType viewType)
        {
            string resourceKey = "FileViewerEx.Icon.ListViewItemExStyle";

            switch (viewType)
            {
                case FileViewExViewType.Icons:
                    resourceKey = "FileViewerEx.Icon.ListViewItemExStyle";
                    break;

                case FileViewExViewType.SmallIcons:
                    resourceKey = "FileViewerEx.SmallIcon.ListViewItemExStyle";
                    break;

                case FileViewExViewType.Tails:
                    resourceKey = "FileViewerEx.Tile.ListViewItemExStyle";
                    break;

                case FileViewExViewType.List:
                    resourceKey = "FileViewerEx.List.ListViewItemExStyle";
                    break;

                case FileViewExViewType.Details:
                    resourceKey = "FileViewerEx.Details.ListViewItemExStyle";
                    break;
            }

            var uri = new Uri("pack://application:,,,/chkam05.Tools.ControlsEx;component/Themes/FileViewerEx.xaml", UriKind.Absolute);
            var resourceDictionary = new ResourceDictionary { Source = uri };
            return resourceDictionary[resourceKey] as Style;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get ListViewEx style from resources, based on view type configuration. </summary>
        /// <param name="viewType"> View type. </param>
        /// <returns> ListViewEx style. </returns>
        private static Style GetListViewExStyle(FileViewExViewType viewType)
        {
            string resourceKey = "FileViewerEx.Icon.ListViewExStyle";

            switch (viewType)
            {
                case FileViewExViewType.Icons:
                case FileViewExViewType.SmallIcons:
                case FileViewExViewType.Tails:
                    resourceKey = "FileViewerEx.Icon.ListViewExStyle";
                    break;

                case FileViewExViewType.List:
                    resourceKey = "FileViewerEx.List.ListViewExStyle";
                    break;

                case FileViewExViewType.Details:
                    resourceKey = "FileViewerEx.Details.ListViewExStyle";
                    break;
            }

            var uri = new Uri("pack://application:,,,/chkam05.Tools.ControlsEx;component/Themes/FileViewerEx.xaml", UriKind.Absolute);
            var resourceDictionary = new ResourceDictionary { Source = uri };
            return resourceDictionary[resourceKey] as Style;
        }

        #endregion STYLES

        #region TEMPLATE

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked whenever application code or internal processes call ApplyTemplate. </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            listView = GetTemplateChild("listView") as ListViewEx;

            if (listView != null)
            {
                listView.MouseDoubleClick += OnViewExMouseDoubleClick;
                listView.SelectionChanged += OnViewExSelectedItemChanged;
            }

            UpdateView(ViewType);
        }

        #endregion TEMPLATE

        #region UTILITIES

        //  --------------------------------------------------------------------------------
        /// <summary> Invokes an action in the selecting mode enabled. </summary>
        /// <param name="action"> The action that will be invoked. </param>
        private void InvokeInSelectingModeEnabled(Action action)
        {
            isSelecting = true;
            action?.Invoke();
            isSelecting = false;
        }

        #endregion UTILITIES

        #region VIEW

        //  --------------------------------------------------------------------------------
        /// <summary> Build grid columns. </summary>
        protected virtual void BuildGridColumns()
        {
            if (ViewType != FileViewExViewType.Details)
                return;

            if (listView != null)
                listView.View = listViewColumnCreator.CreateGridView(ColumnsSource);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Updates items view of FileViewerEx. </summary>
        /// <param name="viewType"> View type. </param>
        protected virtual void UpdateView(FileViewExViewType viewType, FileViewExViewType? oldViewType = null)
        {
            var dataTemplate = GetListViewExDataTemplate(viewType);
            var listViewItemExStyle = GetListViewItemExStyle(viewType);
            var listViewExStyle = GetListViewExStyle(viewType);
            
            if (listView != null)
            {
                if (oldViewType == FileViewExViewType.Details && viewType != oldViewType)
                    listView.View = null;

                listView.Style = listViewExStyle;
                listView.ItemContainerStyle = listViewItemExStyle;
                listView.ItemTemplate = dataTemplate;
                BuildGridColumns();
                listView.UpdateLayout();
            }
        }

        #endregion VIEW

    }
}
