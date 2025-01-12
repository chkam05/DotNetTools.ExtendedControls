using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Utilities
{
    public static class MathUtilities
    {

        #region CLAMP

        //  --------------------------------------------------------------------------------
        /// <summary> Clamps the given value between the given minimum and maximum values. </summary>
        /// <param name="value"> Value to restrict inside the range defined by the minimum and maximum values. </param>
        /// <param name="min"> The minimum value to compare against. </param>
        /// <param name="max"> The maximum value to compare against. </param>
        /// <returns> The minimum value if the given value is less than the minimum; Maximum value if the given value is greater than the maximum value; Value if the given value is between minimum and maximum. </returns>
        public static byte Clamp(byte value, byte min, byte max)
        {
            return Math.Max(Math.Min(value, max), min);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Clamps the given value between the given minimum and maximum values. </summary>
        /// <param name="value"> Value to restrict inside the range defined by the minimum and maximum values. </param>
        /// <param name="min"> The minimum value to compare against. </param>
        /// <param name="max"> The maximum value to compare against. </param>
        /// <returns> The minimum value if the given value is less than the minimum; Maximum value if the given value is greater than the maximum value; Value if the given value is between minimum and maximum. </returns>
        public static int Clamp(int value, int min, int max)
        {
            return Math.Max(Math.Min(value, max), min);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Clamps the given value between the given minimum and maximum values. </summary>
        /// <param name="value"> Value to restrict inside the range defined by the minimum and maximum values. </param>
        /// <param name="min"> The minimum value to compare against. </param>
        /// <param name="max"> The maximum value to compare against. </param>
        /// <returns> The minimum value if the given value is less than the minimum; Maximum value if the given value is greater than the maximum value; Value if the given value is between minimum and maximum. </returns>
        public static long Clamp(long value, long min, long max)
        {
            return Math.Max(Math.Min(value, max), min);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Clamps the given value between the given minimum and maximum values. </summary>
        /// <param name="value"> Value to restrict inside the range defined by the minimum and maximum values. </param>
        /// <param name="min"> The minimum value to compare against. </param>
        /// <param name="max"> The maximum value to compare against. </param>
        /// <returns> The minimum value if the given value is less than the minimum; Maximum value if the given value is greater than the maximum value; Value if the given value is between minimum and maximum. </returns>
        public static double Clamp(double value, double min, double max)
        {
            return Math.Max(Math.Min(value, max), min);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Clamps the given value between the given minimum and maximum values. </summary>
        /// <param name="value"> Value to restrict inside the range defined by the minimum and maximum values. </param>
        /// <param name="min"> The minimum value to compare against. </param>
        /// <param name="max"> The maximum value to compare against. </param>
        /// <returns> The minimum value if the given value is less than the minimum; Maximum value if the given value is greater than the maximum value; Value if the given value is between minimum and maximum. </returns>
        public static float Clamp(float value, float min, float max)
        {
            return Math.Max(Math.Min(value, max), min);
        }

        #endregion CLAMP

        #region IN RANGE

        //  --------------------------------------------------------------------------------
        /// <summary> Check if the given value is between the given minimum and maximum values. </summary>
        /// <param name="value"> Value to check if is inside the range defined by the minimum and maximum values. </param>
        /// <param name="min"> The minimum value to compare against. </param>
        /// <param name="max"> The maximum value to compare against. </param>
        /// <param name="greaterOrEqual"> Compare value to minimum value using greater or equal. </param>
        /// <param name="lessOrEqual"> Compare value to maximum value using less or equal. </param>
        /// <returns> True if the given value is between the given minimum and maximum values, False otherwise. </returns>
        public static bool IsInRange(byte value, byte min, byte max, bool greaterOrEqual = true, bool lessOrEqual = true)
        {
            return (greaterOrEqual ? min <= value : min < value)
                && (lessOrEqual ? max >= value : max > value);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Check if the given value is between the given minimum and maximum values. </summary>
        /// <param name="value"> Value to check if is inside the range defined by the minimum and maximum values. </param>
        /// <param name="min"> The minimum value to compare against. </param>
        /// <param name="max"> The maximum value to compare against. </param>
        /// <param name="greaterOrEqual"> Compare value to minimum value using greater or equal. </param>
        /// <param name="lessOrEqual"> Compare value to maximum value using less or equal. </param>
        /// <returns> True if the given value is between the given minimum and maximum values, False otherwise. </returns>
        public static bool IsInRange(int value, int min, int max, bool greaterOrEqual = true, bool lessOrEqual = true)
        {
            return (greaterOrEqual ? min <= value : min < value)
                && (lessOrEqual ? max >= value : max > value);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Check if the given value is between the given minimum and maximum values. </summary>
        /// <param name="value"> Value to check if is inside the range defined by the minimum and maximum values. </param>
        /// <param name="min"> The minimum value to compare against. </param>
        /// <param name="max"> The maximum value to compare against. </param>
        /// <param name="greaterOrEqual"> Compare value to minimum value using greater or equal. </param>
        /// <param name="lessOrEqual"> Compare value to maximum value using less or equal. </param>
        /// <returns> True if the given value is between the given minimum and maximum values, False otherwise. </returns>
        public static bool IsInRange(long value, long min, long max, bool greaterOrEqual = true, bool lessOrEqual = true)
        {
            return (greaterOrEqual ? min <= value : min < value)
                && (lessOrEqual ? max >= value : max > value);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Check if the given value is between the given minimum and maximum values. </summary>
        /// <param name="value"> Value to check if is inside the range defined by the minimum and maximum values. </param>
        /// <param name="min"> The minimum value to compare against. </param>
        /// <param name="max"> The maximum value to compare against. </param>
        /// <param name="greaterOrEqual"> Compare value to minimum value using greater or equal. </param>
        /// <param name="lessOrEqual"> Compare value to maximum value using less or equal. </param>
        /// <returns> True if the given value is between the given minimum and maximum values, False otherwise. </returns>
        public static bool IsInRange(double value, double min, double max, bool greaterOrEqual = true, bool lessOrEqual = true)
        {
            return (greaterOrEqual ? min <= value : min < value)
                && (lessOrEqual ? max >= value : max > value);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Check if the given value is between the given minimum and maximum values. </summary>
        /// <param name="value"> Value to check if is inside the range defined by the minimum and maximum values. </param>
        /// <param name="min"> The minimum value to compare against. </param>
        /// <param name="max"> The maximum value to compare against. </param>
        /// <param name="greaterOrEqual"> Compare value to minimum value using greater or equal. </param>
        /// <param name="lessOrEqual"> Compare value to maximum value using less or equal. </param>
        /// <returns> True if the given value is between the given minimum and maximum values, False otherwise. </returns>
        public static bool IsInRange(float value, float min, float max, bool greaterOrEqual = true, bool lessOrEqual = true)
        {
            return (greaterOrEqual ? min <= value : min < value)
                && (lessOrEqual ? max >= value : max > value);
        }

        #endregion IN RANGE

    }
}
