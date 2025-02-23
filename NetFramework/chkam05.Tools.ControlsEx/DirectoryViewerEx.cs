using chkam05.Tools.ControlsEx.Data.Collections;
using chkam05.Tools.ControlsEx.Data.Enums;
using chkam05.Tools.ControlsEx.Data.Events;
using chkam05.Tools.ControlsEx.Resources;
using chkam05.Tools.ControlsEx.Utilities;
using chkam05.Tools.ControlsEx.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using static MaterialDesignThemes.Wpf.Theme;

namespace chkam05.Tools.ControlsEx
{
    public class DirectoryViewerEx : Control
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty BackgroundInactiveProperty = DependencyProperty.Register(
            nameof(BackgroundInactive),
            typeof(Brush),
            typeof(DirectoryViewerEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightInactive)));

        public static readonly DependencyProperty BorderBrushInactiveProperty = DependencyProperty.Register(
            nameof(BorderBrushInactive),
            typeof(Brush),
            typeof(DirectoryViewerEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightInactive)));

        public static readonly DependencyProperty CatalogsListeningProperty = DependencyProperty.Register(
            nameof(CatalogsListening),
            typeof(bool),
            typeof(DirectoryViewerEx),
            new PropertyMetadata(true, CatalogsListeningPropertyChangedCallback));

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(DirectoryViewerEx),
            new PropertyMetadata(new CornerRadius(4)));

        public static readonly DependencyProperty DrivesListeningProperty = DependencyProperty.Register(
            nameof(DrivesListening),
            typeof(bool),
            typeof(DirectoryViewerEx),
            new PropertyMetadata(true, DrivesListeningPropertyChangedCallback));

        public static readonly DependencyProperty ForegroundInactiveProperty = DependencyProperty.Register(
            nameof(ForegroundInactive),
            typeof(Brush),
            typeof(DirectoryViewerEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DarkInactive)));

        public static readonly DependencyProperty HorizontalScrollBarVisibilityProperty = DependencyProperty.Register(
            nameof(HorizontalScrollBarVisibility),
            typeof(ScrollBarVisibility),
            typeof(DirectoryViewerEx),
            new PropertyMetadata(ScrollBarVisibility.Auto));

        public static readonly DependencyProperty IconHeightProperty = DependencyProperty.Register(
            nameof(IconHeight),
            typeof(double),
            typeof(DirectoryViewerEx),
            new PropertyMetadata(16d));

        public static readonly DependencyProperty IconMarginProperty = DependencyProperty.Register(
            nameof(IconMargin),
            typeof(Thickness),
            typeof(DirectoryViewerEx),
            new PropertyMetadata(new Thickness(2,2,4,2)));

        public static readonly DependencyProperty IconWidthProperty = DependencyProperty.Register(
            nameof(IconWidth),
            typeof(double),
            typeof(DirectoryViewerEx),
            new PropertyMetadata(16d));

        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(
            nameof(ItemsSource),
            typeof(DirectoryViewExCollection),
            typeof(DirectoryViewerEx),
            new PropertyMetadata(GetDefaultItems(), ItemsSourceChangedCallback));
        
        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(
            nameof(SelectedItem),
            typeof(DirectoryViewExItem),
            typeof(DirectoryViewerEx),
            new PropertyMetadata(null, SelectedItemPropertyChangedCallback));

        public static readonly DependencyProperty ScrollViewerStyleProperty = DependencyProperty.Register(
            nameof(ScrollViewerStyle),
            typeof(Style),
            typeof(DirectoryViewerEx),
            new PropertyMetadata(GetGenericScrollViewerExStyle()));

        public static readonly DependencyProperty ShowHiddenProperty = DependencyProperty.Register(
            nameof(ShowHidden),
            typeof(bool),
            typeof(DirectoryViewerEx),
            new PropertyMetadata(false, ShowHiddenPropertyChangedCallback));

        public static readonly DependencyProperty ShowSystemProperty = DependencyProperty.Register(
            nameof(ShowSystem),
            typeof(bool),
            typeof(DirectoryViewerEx),
            new PropertyMetadata(false, ShowSystemPropertyChangedCallback));

        public static readonly DependencyProperty VerticalScrollBarVisibilityProperty = DependencyProperty.Register(
            nameof(VerticalScrollBarVisibility),
            typeof(ScrollBarVisibility),
            typeof(DirectoryViewerEx),
            new PropertyMetadata(ScrollBarVisibility.Auto));


        //  DELEGATES

        public delegate void DirectoryViewerExDoubleClickEventHandler(object sender, DirectoryViewerExDoubleClickEventArgs e);
        public delegate void DirectoryViewerExSelectionChangedEventHandler(object sender, DirectoryViewerExSelectionChangedEventArgs e);


        //  EVENTS

        public event DirectoryViewerExDoubleClickEventHandler DoubleClick;
        public event DirectoryViewerExSelectionChangedEventHandler SelectionChanged;


        //  VARIABLES

        private TreeViewEx treeView;
        private Dictionary<string, FileSystemWatcher> catalogWatchers;
        private ManagementEventWatcher diskWatcher;
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

        public bool CatalogsListening
        {
            get => (bool)GetValue(CatalogsListeningProperty);
            set => SetValue(CatalogsListeningProperty, value);
        }

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public bool DrivesListening
        {
            get => (bool)GetValue(DrivesListeningProperty);
            set => SetValue(DrivesListeningProperty, value);
        }

        public Brush ForegroundInactive
        {
            get => (Brush)GetValue(ForegroundInactiveProperty);
            set => SetValue(ForegroundInactiveProperty, value);
        }

        public ScrollBarVisibility HorizontalScrollBarVisibility
        {
            get => (ScrollBarVisibility)GetValue(HorizontalScrollBarVisibilityProperty);
            set => SetValue(VerticalScrollBarVisibilityProperty, value);
        }

        public double IconHeight
        {
            get => (double)GetValue(IconHeightProperty);
            set => SetValue(IconHeightProperty, value);
        }

        public Thickness IconMargin
        {
            get => (Thickness)GetValue(IconMarginProperty);
            set => SetValue(IconMarginProperty, value);
        }

        public double IconWidth
        {
            get => (double)GetValue(IconWidthProperty);
            set => SetValue(IconWidthProperty, value);
        }

        public DirectoryViewExCollection ItemsSource
        {
            get => (DirectoryViewExCollection)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public DirectoryViewExItem SelectedItem
        {
            get => (DirectoryViewExItem)GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        public Style ScrollViewerStyle
        {
            get => (Style)GetValue(ScrollViewerStyleProperty);
            set => SetValue(ScrollViewerStyleProperty, value);
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

        public ScrollBarVisibility VerticalScrollBarVisibility
        {
            get => (ScrollBarVisibility)GetValue(VerticalScrollBarVisibilityProperty);
            set => SetValue(VerticalScrollBarVisibilityProperty, value);
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> DirectoryViewerEx class constructor. </summary>
        static DirectoryViewerEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DirectoryViewerEx),
                new FrameworkPropertyMetadata(typeof(DirectoryViewerEx)));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> DirectoryViewerEx class constructor. </summary>
        public DirectoryViewerEx()
        {
            catalogWatchers = new Dictionary<string, FileSystemWatcher>();
            ItemsSource = CreateDrivesCollection();

            Unloaded += OnUnloaded;
            
            if (DrivesListening)
                StartDiskWatcher();
        }

        #endregion CONSTRUCTORS

        #region CATALOGS MANAGEMENT

        //  --------------------------------------------------------------------------------
        /// <summary> Create collection of catalogs/folders located in directory path. </summary>
        /// <param name="directoryPath"> Path to the directory from which the list of folders will be taken. </param>
        /// <returns> Collection of catalogs/folders located in directory path. </returns>
        private DirectoryViewExCollection CreateCatalogCollection(string directoryPath)
        {
            var catalogCollection = new DirectoryViewExCollection();

            foreach (var kvpCatalog in GetCatalogs(directoryPath))
            {
                var catalogItem = CreateCatalogItem(kvpCatalog.Key, kvpCatalog.Value);
                catalogCollection.Add(catalogItem);
            }

            return catalogCollection;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Create single catalog/folder DirectoryViewExItem object. </summary>
        /// <param name="path"> Path to catalog/folder from parent directory path. </param>
        /// <param name="directoryInfo"> Directory information object. </param>
        /// <returns> Single catalogs/folder DirectoryViewExItem object. </returns>
        private DirectoryViewExItem CreateCatalogItem(string path, DirectoryInfo directoryInfo)
        {
            return new DirectoryViewExItem(path, DirectoryViewExItemType.Catalog);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Create collection of disk/drives devices plugged to the computer. </summary>
        /// <returns> Plugged to the computer disk/drives collection. </returns>
        private DirectoryViewExCollection CreateDrivesCollection()
        {
            var drivesCollection = new DirectoryViewExCollection();

            foreach (var driveInfo in FileSystemUtilities.GetDrives())
            {
                var driveItem = CreateDriveItem(driveInfo);
                drivesCollection.Add(driveItem);
                StartWatchingDirectory(driveItem);
            }

            return drivesCollection;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Create single disk/drive DirectoryViewExItem object. </summary>
        /// <param name="driveInfo"> Disk/drive plugged to the computer. </param>
        /// <returns> Single disk/drive DirectoryViewExItem object. </returns>
        private DirectoryViewExItem CreateDriveItem(DriveInfo driveInfo)
        {
            var itemType = DirectoryViewExItemType.Catalog;

            switch (driveInfo.DriveType)
            {
                case DriveType.Fixed:
                    itemType = DirectoryViewExItemType.Harddisk;
                    break;

                case DriveType.Removable:
                    itemType = DirectoryViewExItemType.Usb;
                    break;

                case DriveType.CDRom:
                    itemType = DirectoryViewExItemType.Disc;
                    break;
            }

            var childItems = CreateCatalogCollection(driveInfo.Name);
            childItems.ItemExpanded += OnItemExpanded;
            childItems.ItemCollapsed += OnItemCollapsed;

            var driveItem = new DirectoryViewExItem(driveInfo.Name, itemType);
            driveItem.Items = childItems;

            return driveItem;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get a dict of folders paths in the given directory with DirectoryInfo. </summary>
        /// <param name="directoryPath"> Path to the directory from which the list of folders will be taken. </param>
        /// <returns> Dict of folders paths in the given directory whit DirectoryInfo. </returns>
        private Dictionary<string, DirectoryInfo> GetCatalogs(string directoryPath)
        {
            return Directory.GetDirectories(directoryPath)
                .Select(p => new KeyValuePair<string, DirectoryInfo>(p, new DirectoryInfo(p)))
                .Where(kvp =>
                {
                    var directoryInfo = kvp.Value;

                    if ((directoryInfo.Attributes & FileAttributes.Directory) != FileAttributes.Directory)
                        return false;

                    if (!ShowHidden && (directoryInfo.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                        return false;

                    if (!ShowSystem && (directoryInfo.Attributes & FileAttributes.System) == FileAttributes.System)
                        return false;

                    return true;
                }).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Update list of disk/drives after removing device or inserting new drive device. </summary>
        private void UpdateDrives()
        {
            var newDrives = FileSystemUtilities.GetDrives();
            var removedDrives = ItemsSource.Where(i => !newDrives.Any(d => d.Name == i.Path));

            ItemsSource.RemoveRange(removedDrives);

            int itemIndex = 0;

            foreach (var newDrive in newDrives)
            {
                if (!ItemsSource.Any(i => i.Path == newDrive.Name))
                    ItemsSource.Insert(itemIndex, CreateDriveItem(newDrive));

                itemIndex++;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Update child list of catalogs/folders in DirectoryViewExItem object. </summary>
        /// <param name="item"> DirectoryViewExItem object. </param>
        private void UpdateSubItems(DirectoryViewExItem item)
        {
            if (item.Items == null)
            {
                item.Items = CreateCatalogCollection(item.Path);
                item.Items.ItemExpanded += OnItemExpanded;
                item.Items.ItemCollapsed += OnItemCollapsed;
            }
            else
            {
                var newCatalogs = GetCatalogs(item.Path);
                var removedCatalogs = item.Items.Where(i => !newCatalogs.ContainsKey(i.Path));

                item.Items.RemoveRange(removedCatalogs);

                int itemIndex = 0;

                foreach (var newCatalogKvp in newCatalogs)
                {
                    if (!item.Items.Any(i => i.Path == newCatalogKvp.Key))
                        item.Items.Insert(itemIndex, CreateCatalogItem(newCatalogKvp.Key, newCatalogKvp.Value));

                    itemIndex++;
                }

                foreach (var itemExpanded in item.Items.Where(i => i.IsExpanded))
                    UpdateSubItems(itemExpanded);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Rebuild items depending on updated ShowHidden and ShowSystem properties. </summary>
        private void RebuildItems()
        {
            foreach (var item in ItemsSource)
                UpdateSubItems(item);
        }

        #endregion CATALOGS MANAGEMENT

        #region CATALOG WATCHER

        //  --------------------------------------------------------------------------------
        /// <summary> Start watching current expanded directories. </summary>
        private void StartWatchingAllDirectories()
        {
            if (CatalogsListening)
            {
                StopWathcingAllDirectories();

                foreach (var item in ItemsSource)
                {
                    if (item.ItemType != DirectoryViewExItemType.Catalog)
                        StartWatchingDirectory(item);

                    if (item.Items?.Any() == true)
                    {
                        foreach (var childItem in item.Items)
                            StartWatchingAllDirectories(childItem);
                    }
                }
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Start watching currently expanded directories recursively. </summary>
        /// <param name="item"> DirectoryViewExItem recursive object. </param>
        private void StartWatchingAllDirectories(DirectoryViewExItem item)
        {
            if (item.IsExpanded)
                StartWatchingDirectory(item);

            if (item.Items?.Any() == true)
            {
                foreach (var childItem in item.Items)
                    StartWatchingAllDirectories(childItem);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Starts listening for catalog file system changes. </summary>
        /// <param name="item"> DirectoryViewExItem with catalog path. </param>
        private void StartWatchingDirectory(DirectoryViewExItem item)
        {
            if (CatalogsListening)
            {
                if (catalogWatchers.ContainsKey(item.Path))
                    return;

                var watcher = new FileSystemWatcher(item.Path)
                {
                    IncludeSubdirectories = false,
                    NotifyFilter = NotifyFilters.DirectoryName | NotifyFilters.FileName
                };

                watcher.Created += (s, e) => OnDirectoryUpdate(item);
                watcher.Deleted += (s, e) => OnDirectoryUpdate(item);
                watcher.Renamed += (s, e) => OnDirectoryUpdate(item, e.OldFullPath, e.FullPath);
                watcher.EnableRaisingEvents = true;

                catalogWatchers[item.Path] = watcher;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Updates the subitems structure of a DirectoryViewExItem object after changes in the affected directory. </summary>
        /// <param name="item"> DirectoryViewExItem object representing the affected directory. </param>
        private void OnDirectoryUpdate(DirectoryViewExItem item)
        {
            UpdateSubItems(item);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Updates the subitems structure of a DirectoryViewExItem object after changes in the affected directory. </summary>
        /// <param name="item"> DirectoryViewExItem object representing the affected directory. </param>
        /// <param name="oldPath"> Old path before renaming. </param>
        /// <param name="newPath"> New path after renaming. </param>
        private void OnDirectoryUpdate(DirectoryViewExItem item, string oldPath, string newPath)
        {
            if (item.Path == oldPath)
                item.Path = newPath;
            else
                UpdateSubItems(item);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Stops listening all catalog file system changes. </summary>
        private void StopWathcingAllDirectories()
        {
            foreach (var wather in catalogWatchers)
            {
                wather.Value.EnableRaisingEvents = false;
                wather.Value.Dispose();
            }

            catalogWatchers.Clear();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Stop listening for catalog file system changes. </summary>
        /// <param name="item"> DirectoryViewExItem with catalog path. </param>
        private void StopWatchingDirectory(DirectoryViewExItem item)
        {
            if (CatalogsListening && catalogWatchers.TryGetValue(item.Path, out var watcher))
            {
                watcher.EnableRaisingEvents = false;
                watcher.Dispose();
                catalogWatchers.Remove(item.Path);
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
                return;

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
        /// <summary> Creates a default ItemsSource collection. </summary>
        /// <returns> Default ItemsSource collection. </returns>
        private static DirectoryViewExCollection GetDefaultItems()
        {
            return new DirectoryViewExCollection();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Triggers SelectionChanged event after changing selection. </summary>
        /// <param name="selectedItem"> Selected item. </param>
        private void InvokeSelectionChanged(DirectoryViewExItem selectedItem)
        {
            SelectionChanged?.Invoke(this, new DirectoryViewerExSelectionChangedEventArgs(selectedItem, isSelecting));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when DirectoryViewExItem element is expanded. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Event arguments. </param>
        private void OnItemCollapsed(object sender, EventArgs e)
        {
            if (sender is DirectoryViewExItem item)
            {
                foreach (var childItem in item.Items)
                {
                    StopWatchingDirectory(childItem);
                }
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when DirectoryViewExItem element is expanded. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Event arguments. </param>
        private void OnItemExpanded(object sender, EventArgs e)
        {
            if (sender is DirectoryViewExItem item)
            {
                foreach (var childItem in item.Items)
                {
                    UpdateSubItems(childItem);
                    StartWatchingDirectory(childItem);
                }
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked after double click. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Mouse button event arguments. </param>
        private void OnViewExMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is TreeViewEx treeViewEx)
            {
                var clickedElement = treeViewEx.InputHitTest(e.GetPosition(treeViewEx)) as DependencyObject;

                if (clickedElement != null)
                {
                    var treeViewItem = ObjectUtilities.FindParentAncestorByType<TreeViewItemEx>(clickedElement);

                    if (treeViewItem != null)
                    {
                        var item = (treeViewItem.DataContext ?? treeViewItem.Header) as DirectoryViewExItem;

                        if (item != null)
                            DoubleClick?.Invoke(this, new DirectoryViewerExDoubleClickEventArgs(item));
                    }
                }
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Manages the selection of elements on the DirectoryViewerEx. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Selection changed event arguments. </param>
        private void OnViewExSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            InvokeInSelectingModeEnabled(() =>
            {
                SelectedItem = (e.NewValue is DirectoryViewExItem item) ? item : null;
            });
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Updates selection item in tree view. </summary>
        /// <param name="newSelectedItem"> Selected DirectoryViewExItem object. </param>
        private void UpdateSelectionFromItem(DirectoryViewExItem newSelectedItem)
        {
            if (isSelecting)
                return;

            var items = new List<DirectoryViewExItem>();
            var paths = newSelectedItem.Path.Split(new string[] { "\\", "/" }, StringSplitOptions.None);
            
            DirectoryViewExItem currentItem = null;
            string fullPath = null;

            foreach (var pathFragment in paths)
            {
                fullPath = string.IsNullOrEmpty(fullPath) ? pathFragment : fullPath + $"\\{pathFragment}";
                currentItem = currentItem == null
                    ? ItemsSource.FirstOrDefault(i => i.Path == fullPath)
                    : currentItem.Items.FirstOrDefault(i => i.Path == fullPath);

                if (currentItem != null)
                    items.Add(currentItem);
                else
                    break;
            }

            if (currentItem != null)
            {
                foreach (var item in items)
                    item.IsExpanded = true;
            }
        }

        #endregion ITEMS

        #region PROPERTIES CHANGED CALLBACKS

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when CatalogsListening property changes. </summary>
        /// <param name="d"> Dependency object from which event has been invoked. </param>
        /// <param name="e"> Dependency property changed event arguments. </param>
        private static void CatalogsListeningPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var directoryViewerEx = d as DirectoryViewerEx;

            if (directoryViewerEx != null && e.NewValue is bool enabled)
            {
                if (enabled)
                    directoryViewerEx.StartWatchingAllDirectories();
                else
                    directoryViewerEx.StopWathcingAllDirectories();
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when DrivesListening property changes. </summary>
        /// <param name="d"> Dependency object from which event has been invoked. </param>
        /// <param name="e"> Dependency property changed event arguments. </param>
        private static void DrivesListeningPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var directoryViewerEx = d as DirectoryViewerEx;

            if (directoryViewerEx != null && e.NewValue is bool enabled)
            {
                if (enabled)
                    directoryViewerEx.StartDiskWatcher();
                else
                    directoryViewerEx.StopDiskWatcher();
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when ItemsSource property changes. </summary>
        /// <param name="d"> Dependency object from which event has been invoked. </param>
        /// <param name="e"> Dependency property changed event arguments. </param>
        private static void ItemsSourceChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var directoryViewerEx = d as DirectoryViewerEx;

            if (directoryViewerEx != null)
            {
                if (e.OldValue is DirectoryViewExCollection oldCollection && oldCollection != null)
                {
                    oldCollection.ItemExpanded -= directoryViewerEx.OnItemExpanded;
                    oldCollection.ItemCollapsed -= directoryViewerEx.OnItemCollapsed;
                }

                if (e.NewValue is DirectoryViewExCollection newCollection && newCollection != null)
                {
                    newCollection.ItemExpanded += directoryViewerEx.OnItemExpanded;
                    newCollection.ItemCollapsed += directoryViewerEx.OnItemCollapsed;
                }
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when SelectedItem property changes. </summary>
        /// <param name="d"> Dependency object from which event has been invoked. </param>
        /// <param name="e"> Dependency property changed event arguments. </param>
        private static void SelectedItemPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var directoryViewerEx = d as DirectoryViewerEx;

            if (directoryViewerEx != null && e.NewValue is DirectoryViewExItem item && item != null)
            {
                directoryViewerEx.InvokeSelectionChanged(item);
                directoryViewerEx.UpdateSelectionFromItem(item);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when ShowHidden property changes. </summary>
        /// <param name="d"> Dependency object from which event has been invoked. </param>
        /// <param name="e"> Dependency property changed event arguments. </param>
        private static void ShowHiddenPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var directoryViewerEx = d as DirectoryViewerEx;

            if (directoryViewerEx != null)
                directoryViewerEx.RebuildItems();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when ShowSystem property changes. </summary>
        /// <param name="d"> Dependency object from which event has been invoked. </param>
        /// <param name="e"> Dependency property changed event arguments. </param>
        private static void ShowSystemPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var directoryViewerEx = d as DirectoryViewerEx;

            if (directoryViewerEx != null)
                directoryViewerEx.RebuildItems();
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

        #endregion STYLES

        #region TEMPLATE

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked whenever application code or internal processes call ApplyTemplate. </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            treeView = GetTemplateChild("treeView") as TreeViewEx;

            if (treeView != null)
            {
                treeView.MouseDoubleClick += OnViewExMouseDoubleClick;
                treeView.SelectedItemChanged += OnViewExSelectedItemChanged;
            }
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

    }
}
