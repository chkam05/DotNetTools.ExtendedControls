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
    public static class ListViewExColumnCreator<T> where T : Enum
    {

        //  METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Create GridView with columns. </summary>
        /// <param name="columnsConfig"> Columns config collection. </param>
        /// <returns> GridView with columns. </returns>
        public static GridView CreateGridView(GridViewExColumnConfigCollection<T> columnsConfig, IBindingMapper<T> bindingMapper)
        {
            var gridView = new GridView();

            foreach (GridViewColumnConfig<T> config in columnsConfig)
            {
                var gridViewColumn = new GridViewColumn
                {
                    Header = config.Title,
                    Width = config.Width
                };

                string bindingPath = bindingMapper.GetColumnBindingPath(config.FieldType);
                var binding = new Binding(bindingPath);

                if (config.Converter != null)
                    binding.Converter = config.Converter;

                gridViewColumn.CellTemplate = new DataTemplate()
                {
                    VisualTree = CreateFrameworkElementFactory(config.ColumType, binding)
                };

                gridView.Columns.Add(gridViewColumn);
            }

            return gridView;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Create FrameworkElementFactory for grid column cell. </summary>
        /// <param name="columnType"> Column data type. </param>
        /// <param name="binding"> Binded value. </param>
        /// <returns> FrameworkElementFactory for grid column cell. </returns>
        private static FrameworkElementFactory CreateFrameworkElementFactory(GridViewExColumnType columnType, Binding binding)
        {
            switch (columnType)
            {
                case GridViewExColumnType.PackIcon:
                    return CreatePackIconFrameworkElementFactory(binding);

                case GridViewExColumnType.Text:
                default:
                    return CreateTextBlockFrameworkElementFactory(binding);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Create PackIcon FrameworkElementFactory for grid column cell. </summary>
        /// <param name="binding"> Binded value. </param>
        /// <returns> PackIcon FrameworkElementFactory for grid column cell. </returns>
        private static FrameworkElementFactory CreatePackIconFrameworkElementFactory(Binding binding)
        {
            var factory = new FrameworkElementFactory(typeof(PackIcon));

            factory.SetBinding(PackIcon.KindProperty, binding);
            factory.SetValue(PackIcon.HeightProperty, Double.NaN);
            factory.SetValue(PackIcon.HorizontalAlignmentProperty, HorizontalAlignment.Stretch);
            factory.SetValue(PackIcon.VerticalAlignmentProperty, VerticalAlignment.Stretch);

            var widthBinding = new Binding("Height")
            {
                RelativeSource = new RelativeSource(RelativeSourceMode.Self)
            };

            factory.SetBinding(PackIcon.WidthProperty, widthBinding);

            return factory;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Create TextBlock FrameworkElementFactory for grid column cell. </summary>
        /// <param name="binding"> Binded value. </param>
        /// <returns> TextBlock FrameworkElementFactory for grid column cell. </returns>
        private static FrameworkElementFactory CreateTextBlockFrameworkElementFactory(Binding binding)
        {
            var factory = new FrameworkElementFactory(typeof(TextBlock));

            factory.SetBinding(TextBlock.TextProperty, binding);
            factory.SetValue(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Left);
            factory.SetValue(TextBlock.MarginProperty, new Thickness(0));
            factory.SetValue(TextBlock.VerticalAlignmentProperty, VerticalAlignment.Center);

            return factory;
        }

    }
}
