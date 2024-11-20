using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Utilities
{
    public static class ObjectUtilities
    {

        //  METHODS

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
