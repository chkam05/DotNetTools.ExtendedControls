using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace chkam05.Tools.ControlsEx.Utilities
{
    public static class ObjectUtilities
    {

        //  METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Calculates the distance between the parent component origin and the child component origin. </summary>
        /// <param name="child"> A child FrameworkElement, located somewhere within the parent FrameworkElement. </param>
        /// <param name="parent"> Parent FrameworkElement. </param>
        /// <returns> Distance between the parent component origin and the child component origin. </returns>
        public static Point CalculateTotalDistance(FrameworkElement child, FrameworkElement parent)
        {
            if (child == null)
                throw new ArgumentException("Child element cannot be null.");

            if (parent == null)
                throw new ArgumentNullException("Parent element cannot be null.");

            FrameworkElement currentElement = child;
            double totalXDistance = 0;
            double totalYDistance = 0;

            while (currentElement != null)
            {
                if (currentElement is FrameworkElement frameworkElement)
                {
                    var margin = frameworkElement.Margin;
                    totalXDistance += margin.Left;
                    totalYDistance += margin.Top;
                }

                if (currentElement is Control control)
                {
                    var borderThickness = control.BorderThickness;
                    var padding = control.Padding;
                    totalXDistance += (padding.Left + borderThickness.Left);
                    totalYDistance += (padding.Top + borderThickness.Top);
                }

                if (currentElement == parent)
                    break;

                currentElement = VisualTreeHelper.GetParent(currentElement) as FrameworkElement;
            }

            if (currentElement != parent)
                throw new InvalidOperationException("Parent element is not an ancestor of the child element.");

            return new Point(totalXDistance, totalYDistance);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Searches for FrameworkElement by name in the DependencyObject component tree. </summary>
        /// <param name="parent"> The root of the DependencyObject of VisualTree where the child will be searched for. </param>
        /// <param name="childName"> Child FrameworkElement name. </param>
        /// <returns> Found FrameworkElement object or null. </returns>
        public static FrameworkElement FindChildByName(DependencyObject parent, string childName)
        {
            if (parent is FrameworkElement frameworkElement && frameworkElement.Name == childName)
                return frameworkElement;

            int childCount = VisualTreeHelper.GetChildrenCount(parent);

            for (int i = 0; i < childCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                var result = FindChildByName(child, childName);

                if (result != null)
                    return result;
            }

            return null;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Searches for parent FrameworkElement by type in the DependencyObject component tree. </summary>
        /// <param name="current"> Child DependencyObject of VisualTree where the parent will be searched for. </param>
        /// <returns> Found FrameworkElement object or null. </returns>
        public static T FindParentAncestorByType<T>(DependencyObject current) where T : DependencyObject
        {
            while (current != null)
            {
                if (current is T t)
                    return t;

                current = VisualTreeHelper.GetParent(current);
            }
            return null;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Gets an object of the specified type from a collection of objects. </summary>
        /// <typeparam name="T"> Type of returned object. </typeparam>
        /// <param name="values"> Collection of objects. </param>
        /// <param name="objValue"> Returned object. </param>
        /// <returns> True - Object successfully getted; False - otherwise. </returns>
        public static bool GetValue<T>(IEnumerable<object> values, out T objValue)
        {
            var result = GetValues<T>(values, out IEnumerable<T> objValues);

            objValue = objValues.FirstOrDefault();
            return result;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Retrieves objects of the specified type from a set of objects. </summary>
        /// <typeparam name="T"> Type of returned objects. </typeparam>
        /// <param name="values"> Collection of objects. </param>
        /// <param name="objValue"> Collection of returned objects. </param>
        /// <returns> True - Objects successfully getted; False - otherwise. </returns>
        public static bool GetValues<T>(IEnumerable<object> values, out IEnumerable<T> objValues)
        {
            objValues = values.Where(v => v is T).Select(v => (T)v).ToArray();
            return objValues.Any();
        }

    }
}
