using chkam05.Tools.ControlsEx.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace chkam05.Tools.ControlsEx
{
    public class GeometryThumbEx : ThumbEx
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty GeometryProperty = DependencyProperty.Register(
            nameof(Geometry),
            typeof(Geometry),
            typeof(GeometryThumbEx),
            new PropertyMetadata(GetGenericBaseGeometryData()));


        //  GETTERS & SETTERS

        public Geometry Geometry
        {
            get => (Geometry)GetValue(GeometryProperty);
            set => SetValue(GeometryProperty, value);
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> GeometryThumbEx class constructor. </summary>
        static GeometryThumbEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GeometryThumbEx),
                new FrameworkPropertyMetadata(typeof(GeometryThumbEx)));
        }

        #endregion CONSTRUCTORS

        #region STYLES

        //  --------------------------------------------------------------------------------
        /// <summary> Get generic base geometry data from resources. </summary>
        /// <returns> Base geometry data. </returns>
        protected static Geometry GetGenericBaseGeometryData()
        {
            var uri = new Uri("pack://application:,,,/chkam05.Tools.ControlsEx;component/Themes/GeometryThumbEx.xaml", UriKind.Absolute);
            var resourceDictionary = new ResourceDictionary { Source = uri };
            return resourceDictionary["GeometryThumbEx.BaseGeometry"] as Geometry;
        }

        #endregion STYLES

    }
}
