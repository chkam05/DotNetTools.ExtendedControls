using chkam05.Tools.ControlsEx.Data.Appearance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace chkam05.Tools.ControlsEx.Data.Events
{
    public class SystemThemeChangedEventArgs
    {

        //  VARIABLES

        private Color accentColor;
        private ThemeType themeType;


        //  GETTERS & SETTERS

        public Color AccentColor
        {
            get => accentColor;
        }

        public ThemeType ThemeType
        {
            get => themeType;
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> SystemThemeChangedEventArgs class constructor. </summary>
        /// <param name="accentColor"> System RGB accent color model. </param>
        /// <param name="themeType"> System theme type. </param>
        public SystemThemeChangedEventArgs(Color accentColor, ThemeType themeType)
        {
            this.accentColor = accentColor;
            this.themeType = themeType;
        }

        #endregion CONSTRUCTORS

    }
}
