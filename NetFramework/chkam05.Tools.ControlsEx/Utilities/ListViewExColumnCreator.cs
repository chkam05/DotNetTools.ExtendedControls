using chkam05.Tools.ControlsEx.Data;
using chkam05.Tools.ControlsEx.Data.Collections;
using chkam05.Tools.ControlsEx.Data.Enums;
using chkam05.Tools.ControlsEx.Utilities.Interfaces;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace chkam05.Tools.ControlsEx.Utilities
{
    public class ListViewExColumnCreator<T> where T : Enum
    {

        public IBindingMapper<T> BindingMapper { get; set; }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> ListViewExColumnCreator constructor. </summary>
        /// <param name="bindingMapper"> Column paths binding mapper. </param>
        public ListViewExColumnCreator(IBindingMapper<T> bindingMapper)
        {
            BindingMapper = bindingMapper;
        }

        #endregion CONSTRUCTORS

        #region BUILDER

        //  --------------------------------------------------------------------------------
        /// <summary> Create GridView with columns. </summary>
        /// <param name="columnsConfig"> Columns config collection. </param>
        /// <returns> GridView with columns. </returns>
        public GridView CreateGridView(GridViewExColumnConfigCollection<T> columnsConfig)
        {
            var gridView = new GridView();

            foreach (GridViewColumnConfig<T> config in columnsConfig)
            {
                var gridViewColumn = new GridViewColumn
                {
                    Header = config.Title,
                    Width = config.Width
                };

                string bindingPath = BindingMapper.GetColumnBindingPath(config.FieldType);
                var binding = new Binding(bindingPath);

                if (config.Converter != null)
                    binding.Converter = config.Converter;

                gridViewColumn.CellTemplate = CreateCellTemplate(config.ColumType, binding);
                gridView.Columns.Add(gridViewColumn);
            }

            return gridView;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Create grid column cell DataTemplate. </summary>
        /// <param name="columnType"> Column data type. </param>
        /// <param name="binding"> Binded value. </param>
        /// <returns> Grid column DataTemplate. </returns>
        private DataTemplate CreateCellTemplate(GridViewExColumnType columnType, Binding binding)
        {
            return new DataTemplate()
            {
                VisualTree = CreateFrameworkElementFactory(columnType, binding)
            };
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Create FrameworkElementFactory for grid column cell. </summary>
        /// <param name="columnType"> Column data type. </param>
        /// <param name="binding"> Binded value. </param>
        /// <returns> FrameworkElementFactory for grid column cell. </returns>
        private FrameworkElementFactory CreateFrameworkElementFactory(GridViewExColumnType columnType, Binding binding)
        {
            FrameworkElementFactory factory;

            switch (columnType)
            {
                case GridViewExColumnType.PackIcon:
                    factory = new FrameworkElementFactory(typeof(PackIcon));
                    factory.SetBinding(PackIcon.KindProperty, binding);
                    factory.SetValue(PackIcon.HeightProperty, Double.NaN);
                    factory.SetValue(PackIcon.HorizontalAlignmentProperty, HorizontalAlignment.Stretch);
                    factory.SetValue(PackIcon.VerticalAlignmentProperty, VerticalAlignment.Stretch);

                    var widthBinding = new Binding("Height")
                    {
                        RelativeSource = new RelativeSource(RelativeSourceMode.Self)
                    };

                    factory.SetBinding(PackIcon.WidthProperty, widthBinding);
                    break;

                case GridViewExColumnType.Text:
                default:
                    factory = new FrameworkElementFactory(typeof(TextBlock));
                    factory.SetBinding(TextBlock.TextProperty, binding);
                    factory.SetValue(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Left);
                    factory.SetValue(TextBlock.MarginProperty, new Thickness(0));
                    factory.SetValue(TextBlock.VerticalAlignmentProperty, VerticalAlignment.Center);
                    break;
            }

            return factory;
        }

        #endregion BUILDER

    }
}
