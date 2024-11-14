using chkam05.Tools.ControlsEx.Data.Appearance;
using chkam05.Tools.ControlsEx.Data.Events;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace chkam05.Tools.ControlsEx.Utilities
{
    public class SystemThemeManager : IDisposable
    {

        //  CONST

        private const string IMMERSIVE_COLOR_TYPE_NAME = "ImmersiveStartSelectionBackground";
        private static readonly UserPreferenceCategory[] USER_PREFERENCE_CHANGED_CATEGORIES = new UserPreferenceCategory[]
        {
            UserPreferenceCategory.Color,
            UserPreferenceCategory.General
        };


        //  DELEGATES

        public delegate void SystemThemeChangedEventHandler(object sender, SystemThemeChangedEventArgs e);


        //  EVENTS

        public event SystemThemeChangedEventHandler SystemThemeChanged;


        //  IMPORTS

        [DllImport("uxtheme.dll", EntryPoint = "#95")]
        public static extern uint GetImmersiveColorFromColorSetEx(uint dwImmersiveColorSet, uint dwImmersiveColorType, bool bIgnoreHighContrast, uint dwHighContrastCacheMode);

        [DllImport("uxtheme.dll", EntryPoint = "#96")]
        public static extern uint GetImmersiveColorTypeFromName(IntPtr pName);

        [DllImport("uxtheme.dll", EntryPoint = "#98")]
        public static extern int GetImmersiveUserColorSetPreference(bool bForceCheckRegistry, bool bSkipCheckOnFail);

        [DllImport("uxtheme.dll", EntryPoint = "#132")]
        private static extern int ShouldSystemUseDarkMode();

        [DllImport("uxtheme.dll", EntryPoint = "#135")]
        private static extern int ShouldAppsUseDarkMode();


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> System theme manager class constructor. </summary>
        public SystemThemeManager()
        {
            SystemEvents.UserPreferenceChanged += UserPreferenceChanged;
        }

        #endregion CONSTRUCTORS

        #region DISPOSABLE INTERFACE

        //  --------------------------------------------------------------------------------
        /// <summary> Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources. </summary>
        public void Dispose()
        {
            SystemEvents.UserPreferenceChanged -= UserPreferenceChanged;
        }

        #endregion DISPOSABLE INTERFACE

        #region GETTERS

        //  --------------------------------------------------------------------------------
        /// <summary> Get system accent theme color. </summary>
        /// <returns> RGB system accent theme color instance. </returns>
        public static Color GetAccentColor()
        {
            var colorSetPref = (uint)GetImmersiveUserColorSetPreference(false, false);
            var colorType = GetImmersiveColorTypeFromName(Marshal.StringToHGlobalUni(IMMERSIVE_COLOR_TYPE_NAME));
            var colorSetEx = GetImmersiveColorFromColorSetEx(colorSetPref, colorType, false, 0);

            var color = Color.FromArgb(
                (byte)((0xFF000000 & colorSetEx) >> 24),
                (byte)(0x000000FF & colorSetEx),
                (byte)((0x0000FF00 & colorSetEx) >> 8),
                (byte)((0x00FF0000 & colorSetEx) >> 16));

            return color;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get system or applications theme type. </summary>
        /// <param name="useSystemTheme"> Get system theme type instead of applications theme type. </param>
        /// <returns> System or applications theme type. </returns>
        public static ThemeType GetTheme(bool useSystemTheme = false)
        {
            if (useSystemTheme)
                return ShouldSystemUseDarkMode() == 0 ? ThemeType.Light : ThemeType.Dark;
            else
                return ShouldAppsUseDarkMode() == 0 ? ThemeType.Light : ThemeType.Dark;
        }

        #endregion GETTERS

        #region LISTENER

        //  --------------------------------------------------------------------------------
        /// <summary> System preference changed event listener method. </summary>
        /// <param name="sender"> Object that dispatched event. </param>
        /// <param name="e"> User preference changed event arguments. </param>
        private void UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
        {
            if (USER_PREFERENCE_CHANGED_CATEGORIES.Contains(e.Category))
            {
                var color = GetAccentColor();
                var theme = GetTheme();

                SystemThemeChanged?.Invoke(this, new SystemThemeChangedEventArgs(color, theme));
            }
        }

        #endregion LISTENER

    }
}
