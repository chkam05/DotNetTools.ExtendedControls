using chkam05.Tools.ControlsEx.Data.Enums;
using chkam05.Tools.ControlsEx.Utilities;
using chkam05.Tools.ControlsEx.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MaterialDesignThemes.Wpf.Theme.ToolBar;

namespace chkam05.Tools.ControlsEx.Data.Collections
{
    public class DirectoryViewExCollection : ObservableCollection<DirectoryViewExItem>
    {

        //  EVENTS

        public event EventHandler ItemCollapsed;
        public event EventHandler ItemExpanded;


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> DirectoryViewExCollection class constructor. </summary>
        public DirectoryViewExCollection()
        {
        }

        //  --------------------------------------------------------------------------------
        /// <summary> DirectoryViewExCollection class constructor. </summary>
        /// <param name="collection"> The collection whose elements are copied to the new collection. </param>
        public DirectoryViewExCollection(IEnumerable<DirectoryViewExItem> collection)
        {
            AddRange(collection);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> DirectoryViewExCollection class constructor. </summary>
        /// <param name="list"> The list whose elements are initially contained in the collection. </param>
        public DirectoryViewExCollection(List<DirectoryViewExItem> list)
        {
            AddRange(list);
        }

        #endregion CONSTRUCTORS

        #region EVENTS

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when DirectoryViewExItem element is collapsed. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Event arguments. </param>
        private void OnItemCollapsed(object sender, EventArgs e)
        {
            ItemCollapsed?.Invoke(sender, e);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when DirectoryViewExItem element is expanded. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Event arguments. </param>
        private void OnItemExpanded(object sender, EventArgs e)
        {
            ItemExpanded?.Invoke(sender, e);
        }

        #endregion EVENTS

        #region ITEMS MANAGEMENT

        //  --------------------------------------------------------------------------------
        /// <summary> Adds a new item to the collection. </summary>
        /// <param name="item"> The item to add. </param>
        public new void Add(DirectoryViewExItem item)
        {
            SetEventHandlers(item);
            base.Add(item);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Adds a new items to the collection. </summary>
        /// <param name="items"> The collection whose elements to be added to the new collection. </param>
        public void AddRange(IEnumerable<DirectoryViewExItem> items)
        {
            foreach (var item in items)
                Add(item);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Clears all items from the collection. </summary>
        public new void Clear()
        {
            foreach (var item in this)
                UnsetEventHandlers(item);

            base.Clear();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Inserts an item at the specified index. </summary>
        /// <param name="index"> The zero-based index at which the item should be inserted. </param>
        /// <param name="item"> The item to insert. </param>
        protected override void InsertItem(int index, DirectoryViewExItem item)
        {
            SetEventHandlers(item);
            base.InsertItem(index, item);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Removes the specified item from the collection. </summary>
        /// <param name="item"> The item to remove. </param>
        public new void Remove(DirectoryViewExItem item)
        {
            UnsetEventHandlers(item);
            base.Remove(item);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Removes the item at the specified index. </summary>
        /// <param name="index"> The zero-based index of the item to remove. </param>
        protected override void RemoveItem(int index)
        {
            if (MathUtilities.IsInRange(index, 0, Count - 1))
            {
                var item = this[index];
                UnsetEventHandlers(item);
            }

            base.RemoveItem(index);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Removes specified items from the collection. </summary>
        /// <param name="items"> Items to remove. </param>
        public void RemoveRange(IEnumerable<DirectoryViewExItem> items)
        {
            foreach (var item in items)
            {
                if (Contains(item))
                    Remove(item);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set DirectoryViewExItem item event handlers. </summary>
        /// <param name="item"> DirectoryViewExItem where event handlers are to be set. </param>
        private void SetEventHandlers(DirectoryViewExItem item)
        {
            item.Expanded += OnItemExpanded;
            item.Collapsed += OnItemCollapsed;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Unset DirectoryViewExItem item event handlers. </summary>
        /// <param name="item"> DirectoryViewExItem where event handlers are to be unset. </param>
        private void UnsetEventHandlers(DirectoryViewExItem item)
        {
            item.Expanded -= OnItemExpanded;
            item.Collapsed -= OnItemCollapsed;
        }

        #endregion ITEMS MANAGEMENT

    }
}
