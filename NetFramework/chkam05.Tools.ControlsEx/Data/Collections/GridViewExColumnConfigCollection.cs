using chkam05.Tools.ControlsEx.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Data.Collections
{
    public class GridViewExColumnConfigCollection<T> : ObservableCollection<GridViewColumnConfig<T>> where T : Enum
    {

        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> ListViewExColumnConfigCollection class constructor. </summary>
        public GridViewExColumnConfigCollection()
        {
        }

        //  --------------------------------------------------------------------------------
        /// <summary> ListViewExColumnConfigCollection class constructor. </summary>
        /// <param name="collection"> The collection whose elements are copied to the new collection. </param>
        public GridViewExColumnConfigCollection(IEnumerable<GridViewColumnConfig<T>> collection)
        {
            AddRange(collection);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> ListViewExColumnConfigCollection class constructor. </summary>
        /// <param name="list"> The list whose elements are initially contained in the collection. </param>
        public GridViewExColumnConfigCollection(List<GridViewColumnConfig<T>> list)
        {
            AddRange(list);
        }

        #endregion CONSTRUCTORS

        #region ITEMS MANAGEMENT

        //  --------------------------------------------------------------------------------
        /// <summary> Adds a new item to the collection. </summary>
        /// <param name="item"> The item to add. </param>
        public new void Add(GridViewColumnConfig<T> item)
        {
            base.Add(item);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Adds a new items to the collection. </summary>
        /// <param name="items"> The collection whose elements to be added to the new collection. </param>
        public void AddRange(IEnumerable<GridViewColumnConfig<T>> items)
        {
            foreach (var item in items)
                Add(item);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Clears all items from the collection. </summary>
        public new void Clear()
        {
            base.Clear();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Inserts an item at the specified index. </summary>
        /// <param name="index"> The zero-based index at which the item should be inserted. </param>
        /// <param name="item"> The item to insert. </param>
        protected override void InsertItem(int index, GridViewColumnConfig<T> item)
        {
            base.InsertItem(index, item);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Removes the specified item from the collection. </summary>
        /// <param name="item"> The item to remove. </param>
        public new void Remove(GridViewColumnConfig<T> item)
        {
            base.Remove(item);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Removes the item at the specified index. </summary>
        /// <param name="index"> The zero-based index of the item to remove. </param>
        protected override void RemoveItem(int index)
        {
            base.RemoveItem(index);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Removes specified items from the collection. </summary>
        /// <param name="items"> Items to remove. </param>
        public void RemoveRange(IEnumerable<GridViewColumnConfig<T>> items)
        {
            foreach (var item in items)
            {
                if (Contains(item))
                    Remove(item);
            }
        }

        #endregion ITEMS MANAGEMENT

    }
}
