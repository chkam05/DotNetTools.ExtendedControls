using chkam05.Tools.ControlsEx.Resources;
using chkam05.Tools.ControlsEx.Utilities;
using chkam05.Tools.ControlsEx.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace chkam05.Tools.ControlsEx.Data.Theme
{
    public class ThemeDataModel : BaseViewModel
    {

        //  VARIABLES

        private Color appearanceColor = ColorsResources.DefaultAccentColor;
        private Brush accentBackground;
        private Brush accentBorderBrush;
        private Brush accentForeground;
        private Brush accentBackgroundMouseOver;
        private Brush accentBackgroundPressed;
        private Brush accentBackgroundSelected;
        private Brush accentBorderBrushMouseOver;
        private Brush accentBorderBrushPressed;
        private Brush accentBorderBrushSelected;
        private Brush accentForegroundMouseOver;
        private Brush accentForegroundPressed;
        private Brush accentForegroundSelected;

        private int accentMouseOverColorFactor = -15;
        private int accentPressedColorFactor = 10;
        private int accentSelectedColorFactor = 5;

        private Brush backgroundInactive;
        private Brush borderBrushInactive;
        private Brush foregroundInactive;

        private bool enableIndependentAccentConfig = false;
        private bool enableIndependentThemeConfig = false;
        
        private double opacityInactive = 0.56;

        private ThemeType themeType = ThemeType.Dark;
        private Brush themeBackground;
        private Brush themeBackgroundMouseOver;
        private Brush themeBackgroundPressed;
        private Brush themeBackgroundSelected;
        private Brush themeBackgroundShade;
        private Brush themeForeground;
        private Brush themeForegroundMouseOver;
        private Brush themeForegroundPressed;
        private Brush themeForegroundSelected;

        private int themeInactiveColorFactor = 37;
        private int themeMouseOverColorFactor = 50;
        private int themePressedColorFactor = 17;
        private int themeSelectedColorFactor = 34;

        private bool useSystemColorInsteadOfApplication = false;


        //  GETTERS & SETTERS

        public Color AppearanceColor
        {
            get => appearanceColor;
            set
            {
                UpdateProperty(ref appearanceColor, value);
                UpdateAppearanceBrushes(value);
            }
        }

        public Brush AccentBackground
        {
            get => accentBackground;
            set => UpdateProperty(ref accentBackground, value);
        }

        public Brush AccentBackgroundMouseOver
        {
            get => accentBackgroundMouseOver;
            set => UpdateProperty(ref accentBackgroundMouseOver, value);
        }

        public Brush AccentBackgroundPressed
        {
            get => accentBackgroundPressed;
            set => UpdateProperty(ref accentBackgroundPressed, value);
        }

        public Brush AccentBackgroundSelected
        {
            get => accentBackgroundSelected;
            set => UpdateProperty(ref accentBackgroundSelected, value);
        }

        public Brush AccentBorderBrush
        {
            get => accentBorderBrush;
            set => UpdateProperty(ref accentBorderBrush, value);
        }

        public Brush AccentBorderBrushMouseOver
        {
            get => accentBorderBrushMouseOver;
            set => UpdateProperty(ref accentBorderBrushMouseOver, value);
        }

        public Brush AccentBorderBrushPressed
        {
            get => accentBorderBrushPressed;
            set => UpdateProperty(ref accentBorderBrushPressed, value);
        }

        public Brush AccentBorderBrushSelected
        {
            get => accentBorderBrushSelected;
            set => UpdateProperty(ref accentBorderBrushSelected, value);
        }

        public Brush AccentForeground
        {
            get => accentForeground;
            set => UpdateProperty(ref accentForeground, value);
        }

        public Brush AccentForegroundMouseOver
        {
            get => accentForegroundMouseOver;
            set => UpdateProperty(ref accentForegroundMouseOver, value);
        }

        public Brush AccentForegroundPressed
        {
            get => accentForegroundPressed;
            set => UpdateProperty(ref accentForegroundPressed, value);
        }

        public Brush AccentForegroundSelected
        {
            get => accentForegroundSelected;
            set => UpdateProperty(ref accentForegroundSelected, value);
        }

        public int AccentMouseOverColorFactor
        {
            get => accentMouseOverColorFactor;
            set
            {
                UpdateProperty(ref accentMouseOverColorFactor, value);
                UpdateAppearanceBrushes(appearanceColor);
            }
        }

        public int AccentPressedColorFactor
        {
            get => accentPressedColorFactor;
            set
            {
                UpdateProperty(ref accentPressedColorFactor, value);
                UpdateAppearanceBrushes(appearanceColor);
            }
        }

        public int AccentSelectedColorFactor
        {
            get => accentSelectedColorFactor;
            set
            {
                UpdateProperty(ref accentSelectedColorFactor, value);
                UpdateAppearanceBrushes(appearanceColor);
            }
        }

        public Brush BackgroundInactive
        {
            get => backgroundInactive;
            set => UpdateProperty(ref backgroundInactive, value);
        }

        public Brush BorderBrushInactive
        {
            get => borderBrushInactive;
            set => UpdateProperty(ref borderBrushInactive, value);
        }

        public Brush ForegroundInactive
        {
            get => foregroundInactive;
            set => UpdateProperty(ref foregroundInactive, value);
        }

        public bool EnableIndependentAccentConfig
        {
            get => enableIndependentAccentConfig;
            set => UpdateProperty(ref enableIndependentAccentConfig, value);
        }

        public bool EnableIndependentThemeConfig
        {
            get => enableIndependentThemeConfig;
            set => UpdateProperty(ref enableIndependentThemeConfig, value);
        }

        public int InactiveColorFactor
        {
            get => themeInactiveColorFactor;
            set
            {
                UpdateProperty(ref themeInactiveColorFactor, value);
                UpdateAppearanceBrushes(appearanceColor);
                UpdateThemeBrushes(themeType);
            }
        }

        public double OpacityInactive
        {
            get => opacityInactive;
            set => UpdateProperty(ref opacityInactive, MathUtilities.Clamp(value, 0d, 1d));
        }

        public ThemeType ThemeType
        {
            get => themeType;
            set
            {
                UpdateProperty(ref themeType, value);
                UpdateThemeBrushes(value);
            }
        }

        public Brush ThemeBackground
        {
            get => themeBackground;
            set => UpdateProperty(ref themeBackground, value);
        }

        public Brush ThemeBackgroundMouseOver
        {
            get => themeBackgroundMouseOver;
            set => UpdateProperty(ref themeBackgroundMouseOver, value);
        }

        public Brush ThemeBackgroundPressed
        {
            get => themeBackgroundPressed;
            set => UpdateProperty(ref themeBackgroundPressed, value);
        }

        public Brush ThemeBackgroundSelected
        {
            get => themeBackgroundSelected;
            set => UpdateProperty(ref themeBackgroundSelected, value);
        }

        public Brush ThemeBackgroundShade
        {
            get => themeBackgroundShade;
            set => UpdateProperty(ref themeBackgroundShade, value);
        }

        public Brush ThemeForeground
        {
            get => themeForeground;
            set => UpdateProperty(ref themeForeground, value);
        }

        public Brush ThemeForegroundMouseOver
        {
            get => themeForegroundMouseOver;
            set => UpdateProperty(ref themeForegroundMouseOver, value);
        }

        public Brush ThemeForegroundPressed
        {
            get => themeForegroundPressed;
            set => UpdateProperty(ref themeForegroundPressed, value);
        }

        public Brush ThemeForegroundSelected
        {
            get => themeForegroundSelected;
            set => UpdateProperty(ref themeForegroundSelected, value);
        }

        public int ThemeInactiveColorFactor
        {
            get => themeInactiveColorFactor;
            set
            {
                UpdateProperty(ref themeInactiveColorFactor, MathUtilities.Clamp(value, -100, 100));
                UpdateThemeBrushes(themeType);
            }
        }

        public int ThemeMouseOverColorFactor
        {
            get => themeMouseOverColorFactor;
            set
            {
                UpdateProperty(ref themeMouseOverColorFactor, MathUtilities.Clamp(value, -100, 100));
                UpdateThemeBrushes(themeType);
            }
        }

        public int ThemePressedColorFactor
        {
            get => themePressedColorFactor;
            set
            {
                UpdateProperty(ref themePressedColorFactor, MathUtilities.Clamp(value, -100, 100));
                UpdateThemeBrushes(themeType);
            }
        }

        public int ThemeSelectedColorFactor
        {
            get => themeSelectedColorFactor;
            set
            {
                UpdateProperty(ref themeSelectedColorFactor, MathUtilities.Clamp(value, -100, 100));
                UpdateThemeBrushes(themeType);
            }
        }

        public bool UseSystemColorInsteadOfApplication
        {
            get => useSystemColorInsteadOfApplication;
            set
            {
                UpdateProperty(ref useSystemColorInsteadOfApplication, value);
                UpdateThemeBrushes(themeType);
            }
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> Appearance data model class constructor. </summary>
        public ThemeDataModel()
        {
            Refresh();
        }

        #endregion CONSTRUCTORS

        #region CONFIGURATION UPDATE

        //  --------------------------------------------------------------------------------
        /// <summary> Manual refresh appearance and theme brushes. </summary>
        public void Refresh()
        {
            UpdateAppearanceBrushes(appearanceColor);
            UpdateThemeBrushes(themeType);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Update appearance brushes. </summary>
        /// <param name="color"> Appearance RGB color model. </param>
        private void UpdateAppearanceBrushes(Color color)
        {
            if (enableIndependentAccentConfig)
                return;

            var ahslColor = AHSLColor.FromColor(color);
            var foreground = ColorsUtilities.GetForegroundColorDependingOnBackground(color);

            var mouseOver = ColorsUtilities.UpdateColor(ahslColor, l: ahslColor.L - accentMouseOverColorFactor).ToColor();
            var pressed = ColorsUtilities.UpdateColor(ahslColor, l: ahslColor.L - accentPressedColorFactor).ToColor();
            var selected = ColorsUtilities.UpdateColor(ahslColor, l: ahslColor.L - accentSelectedColorFactor).ToColor();

            AccentBackground = new SolidColorBrush(color);
            AccentBackgroundMouseOver = new SolidColorBrush(mouseOver);
            AccentBackgroundPressed = new SolidColorBrush(pressed);
            AccentBackgroundSelected = new SolidColorBrush(selected);

            AccentBorderBrush = new SolidColorBrush(color);
            AccentBorderBrushMouseOver = new SolidColorBrush(mouseOver);
            AccentBorderBrushPressed = new SolidColorBrush(pressed);
            AccentBorderBrushSelected = new SolidColorBrush(selected);

            AccentForeground = new SolidColorBrush(foreground);
            AccentForegroundMouseOver = new SolidColorBrush(foreground);
            AccentForegroundPressed = new SolidColorBrush(foreground);
            AccentForegroundSelected = new SolidColorBrush(foreground);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Update theme brushes. </summary>
        /// <param name="themeType"> Theme type. </param>
        private void UpdateThemeBrushes(ThemeType themeType)
        {
            if (enableIndependentThemeConfig)
                return;

            Color background;
            Color foreground;
            Color shade;

            ThemeType localThemeType = themeType == ThemeType.System
                ? SystemThemeManager.GetTheme(UseSystemColorInsteadOfApplication)
                : themeType;

            switch (localThemeType)
            {
                case ThemeType.Dark:
                    background = Colors.Black;
                    foreground = Colors.White;
                    shade = ColorsResources.DarkShadeBackground;
                    break;

                case ThemeType.Light:
                default:
                    background = Colors.White;
                    foreground = Colors.Black;
                    shade = ColorsResources.LightShadeBackground;
                    break;
            }

            var ahslColor = AHSLColor.FromColor(background);

            var inactive = ColorsUtilities.UpdateColor(ahslColor,
                l: ahslColor.S > 50
                    ? ahslColor.S - themeInactiveColorFactor
                    : ahslColor.L + themeInactiveColorFactor,
                s: 0).ToColor();

            var inactiveForeground = ColorsUtilities.GetForegroundColorDependingOnBackground(inactive);

            var mouseOver = ColorsUtilities.UpdateColor(ahslColor,
                l: ahslColor.S > 50
                    ? ahslColor.S - themeMouseOverColorFactor
                    : ahslColor.L + themeMouseOverColorFactor,
                s: 0).ToColor();

            var pressed = ColorsUtilities.UpdateColor(ahslColor,
                l: ahslColor.S > 50
                    ? ahslColor.S - themePressedColorFactor
                    : ahslColor.L + themePressedColorFactor,
                s: 0).ToColor();

            var selected = ColorsUtilities.UpdateColor(ahslColor,
                l: ahslColor.S > 50
                    ? ahslColor.S - themeSelectedColorFactor
                    : ahslColor.L + themeSelectedColorFactor,
                s: 0).ToColor();

            BackgroundInactive = new SolidColorBrush(inactive);
            BorderBrushInactive = new SolidColorBrush(inactive);
            ForegroundInactive = new SolidColorBrush(inactiveForeground);

            ThemeBackground = new SolidColorBrush(background);
            ThemeBackgroundMouseOver = new SolidColorBrush(mouseOver);
            ThemeBackgroundPressed = new SolidColorBrush(pressed);
            ThemeBackgroundSelected = new SolidColorBrush(selected);
            ThemeBackgroundShade = new SolidColorBrush(shade);

            ThemeForeground = new SolidColorBrush(foreground);
            ThemeForegroundMouseOver = new SolidColorBrush(foreground);
            ThemeForegroundPressed = new SolidColorBrush(foreground);
            ThemeForegroundSelected = new SolidColorBrush(foreground);
        }

        #endregion CONFIGURATION UPDATE

    }
}
