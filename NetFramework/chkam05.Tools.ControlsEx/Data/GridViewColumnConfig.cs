using chkam05.Tools.ControlsEx.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace chkam05.Tools.ControlsEx.Data
{
    public class GridViewColumnConfig<T> where T : Enum
    {
        
        //  VARIABLES

        public T FieldType { get; set; }
        public IValueConverter Converter { get; set; }
        public GridViewExColumnType ColumType {  get; set; }
        public string Title { get; set; }
        public double Width { get; set; }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> GridViewColumnConfig constructor. </summary>
        /// <param name="fieldType"> Column type field. </param>
        /// <param name="title"> Column title. </param>
        /// <param name="width"> Column width. </param>
        public GridViewColumnConfig(T fieldType, string title, double width = 128)
        {
            FieldType = fieldType;
            Converter = null;
            ColumType = GridViewExColumnType.Text;
            Title = title;
            Width = width;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> GridViewColumnConfig constructor. </summary>
        /// <param name="fieldType"> Column type field. </param>
        /// <param name="title"> Column title. </param>
        /// <param name="converter"> Column data converter. </param>
        /// <param name="width"> Column width. </param>
        public GridViewColumnConfig(T fieldType, string title, IValueConverter converter, double width = 128)
        {
            FieldType = fieldType;
            Converter = converter;
            ColumType = GridViewExColumnType.Text;
            Title = title;
            Width = width;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> GridViewColumnConfig constructor. </summary>
        /// <param name="fieldType"> Column type field. </param>
        /// <param name="title"> Column title. </param>
        /// <param name="columnType"> Column type. </param>
        /// <param name="width"> Column width. </param>
        public GridViewColumnConfig(T fieldType, string title, GridViewExColumnType columnType, double width = 128)
        {
            FieldType = fieldType;
            Converter = null;
            ColumType = columnType;
            Title = title;
            Width = width;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> GridViewColumnConfig constructor. </summary>
        /// <param name="fieldType"> Column type field. </param>
        /// <param name="title"> Column title. </param>
        /// <param name="columnType"> Column type. </param>
        /// <param name="converter"> Column data converter. </param>
        /// <param name="width"> Column width. </param>
        public GridViewColumnConfig(T fieldType, string title, GridViewExColumnType columnType, IValueConverter converter, double width = 128)
        {
            FieldType = fieldType;
            Converter = converter;
            ColumType = columnType;
            Title = title;
            Width = width;
        }

        #endregion CONSTRUCTORS

    }
}
