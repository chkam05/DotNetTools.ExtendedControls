using chkam05.Tools.ControlsEx.Resources;
using chkam05.Tools.ControlsEx.Utilities;
using chkam05.Tools.ControlsEx.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace chkam05.Tools.ControlsEx.Data.Appearance
{
    public class AppearanceDataModel : BaseViewModel
    {

        //  VARIABLES

        private Color appearanceColor = ColorsResources.BaseAccentColor;
        private Brush accentBackground;
        private Brush accentBorderBrush;
        private Brush accentForeground;
        private Brush accentMouseOverBackground;
        private Brush accentMouseOverBorderBrush;
        private Brush accentMouseOverForeground;
        private Brush accentInactiveBackground;
        private Brush accentInactiveBorderBrush;
        private Brush accentInactiveForeground;
        private Brush accentPressedBackground;
        private Brush accentPressedBorderBrush;
        private Brush accentPressedForeground;
        private Brush accentSelectedBackground;
        private Brush accentSelectedBorderBrush;
        private Brush accentSelectedForeground;

        private bool enableIndependentAccentConfig = false;
        private bool enableIndependentThemeConfig = false;

        private int inactiveColorFactor = 15;
        private int mouseOverColorFactor = 15;
        private int pressedColorFactor = 10;
        private int selectedColorFactor = 5;

        private ThemeType themeType = ThemeType.Light;
        private Brush themeBackground;
        private Brush themeForeground;
        private Brush themeShadeBackground;
        private Brush themeMouseOverBackground;
        private Brush themeMouseOverForeground;
        private Brush themePressedBackground;
        private Brush themePressedForeground;
        private Brush themeSelectedBackground;
        private Brush themeSelectedForeground;

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

        public Brush AccentBorderBrush
        {
            get => accentBorderBrush;
            set => UpdateProperty(ref accentBorderBrush, value);
        }

        public Brush AccentForeground
        {
            get => accentForeground;
            set => UpdateProperty(ref accentForeground, value);
        }

        public Brush AccentMouseOverBackground
        {
            get => accentMouseOverBackground;
            set => UpdateProperty(ref accentMouseOverBackground, value);
        }

        public Brush AccentMouseOverBorderBrush
        {
            get => accentMouseOverBorderBrush;
            set => UpdateProperty(ref accentMouseOverBorderBrush, value);
        }

        public Brush AccentMouseOverForeground
        {
            get => accentMouseOverForeground;
            set => UpdateProperty(ref accentMouseOverForeground, value);
        }

        public Brush AccentInactiveBackground
        {
            get => accentInactiveBackground;
            set => UpdateProperty(ref accentInactiveBackground, value);
        }

        public Brush AccentInactiveBorderBrush
        {
            get => accentInactiveBorderBrush;
            set => UpdateProperty(ref accentInactiveBorderBrush, value);
        }

        public Brush AccentInactiveForeground
        {
            get => accentInactiveForeground;
            set => UpdateProperty(ref accentInactiveForeground, value);
        }

        public Brush AccentPressedBackground
        {
            get => accentPressedBackground;
            set => UpdateProperty(ref accentPressedBackground, value);
        }

        public Brush AccentPressedBorderBrush
        {
            get => accentPressedBorderBrush;
            set => UpdateProperty(ref accentPressedBorderBrush, value);
        }

        public Brush AccentPressedForeground
        {
            get => accentPressedForeground;
            set => UpdateProperty(ref accentPressedForeground, value);
        }

        public Brush AccentSelectedBackground
        {
            get => accentSelectedBackground;
            set => UpdateProperty(ref accentSelectedBackground, value);
        }

        public Brush AccentSelectedBorderBrush
        {
            get => accentSelectedBorderBrush;
            set => UpdateProperty(ref accentSelectedBorderBrush, value);
        }

        public Brush AccentSelectedForeground
        {
            get => accentSelectedForeground;
            set => UpdateProperty(ref accentSelectedForeground, value);
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
            get => inactiveColorFactor;
            set
            {
                UpdateProperty(ref inactiveColorFactor, value);
                UpdateAppearanceBrushes(appearanceColor);
                UpdateThemeBrushes(themeType);
            }
        }

        public int MouseOverColorFactor
        {
            get => mouseOverColorFactor;
            set
            {
                UpdateProperty(ref mouseOverColorFactor, value);
                UpdateAppearanceBrushes(appearanceColor);
                UpdateThemeBrushes(themeType);
            }
        }

        public int PressedColorFactor
        {
            get => pressedColorFactor;
            set
            {
                UpdateProperty(ref pressedColorFactor, value);
                UpdateAppearanceBrushes(appearanceColor);
                UpdateThemeBrushes(themeType);
            }
        }

        public int SelectedColorFactor
        {
            get => selectedColorFactor;
            set
            {
                UpdateProperty(ref selectedColorFactor, value);
                UpdateAppearanceBrushes(appearanceColor);
                UpdateThemeBrushes(themeType);
            }
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

        public Brush ThemeForeground
        {
            get => themeForeground;
            set => UpdateProperty(ref themeForeground, value);
        }

        public Brush ThemeShadeBackground
        {
            get => themeShadeBackground;
            set => UpdateProperty(ref themeShadeBackground, value);
        }

        public Brush ThemeMouseOverBackground
        {
            get => themeMouseOverBackground;
            set => UpdateProperty(ref themeMouseOverBackground, value);
        }

        public Brush ThemeMouseOverForeground
        {
            get => themeMouseOverForeground;
            set => UpdateProperty(ref themeMouseOverForeground, value);
        }

        public Brush ThemePressedBackground
        {
            get => themePressedBackground;
            set => UpdateProperty(ref themePressedBackground, value);
        }

        public Brush ThemePressedForeground
        {
            get => themePressedForeground;
            set => UpdateProperty(ref themePressedForeground, value);
        }

        public Brush ThemeSelectedBackground
        {
            get => themeSelectedBackground;
            set => UpdateProperty(ref themeSelectedBackground, value);
        }

        public Brush ThemeSelectedForeground
        {
            get => themeSelectedForeground;
            set => UpdateProperty(ref themeSelectedForeground, value);
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
        public AppearanceDataModel()
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

            var mouseOver = UpdateColor(ahslColor, l: ahslColor.L + mouseOverColorFactor).ToColor();
            var inactive = UpdateColor(ahslColor, l: ahslColor.L - inactiveColorFactor).ToColor();
            var pressed = UpdateColor(ahslColor, l: ahslColor.L - pressedColorFactor).ToColor();
            var selected = UpdateColor(ahslColor, l: ahslColor.L - selectedColorFactor).ToColor();

            AccentBackground = new SolidColorBrush(color);
            AccentBorderBrush = new SolidColorBrush(color);
            AccentForeground = new SolidColorBrush(foreground);
            AccentMouseOverBackground = new SolidColorBrush(mouseOver);
            AccentMouseOverBorderBrush = new SolidColorBrush(mouseOver);
            AccentMouseOverForeground = new SolidColorBrush(foreground);
            AccentInactiveBackground = new SolidColorBrush(inactive);
            AccentInactiveBorderBrush = new SolidColorBrush(inactive);
            AccentInactiveForeground = new SolidColorBrush(foreground);
            AccentPressedBackground = new SolidColorBrush(pressed);
            AccentPressedBorderBrush = new SolidColorBrush(pressed);
            AccentPressedForeground = new SolidColorBrush(foreground);
            AccentSelectedBackground = new SolidColorBrush(selected);
            AccentSelectedBorderBrush = new SolidColorBrush(selected);
            AccentSelectedForeground = new SolidColorBrush(foreground);
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

            var mouseOver = UpdateColor(ahslColor,
                l: ahslColor.S > 50
                    ? ahslColor.S + mouseOverColorFactor
                    : ahslColor.L - mouseOverColorFactor,
                s: 0).ToColor();

            var pressed = UpdateColor(ahslColor,
                l: ahslColor.S > 50
                    ? ahslColor.S - pressedColorFactor
                    : ahslColor.L + pressedColorFactor,
                s: 0).ToColor();

            var selected = UpdateColor(ahslColor,
                l: ahslColor.S > 50
                    ? ahslColor.S - selectedColorFactor
                    : ahslColor.L + selectedColorFactor,
                s: 0).ToColor();

            ThemeBackground = new SolidColorBrush(background);
            ThemeForeground = new SolidColorBrush(foreground);
            ThemeShadeBackground = new SolidColorBrush(shade);
            ThemeMouseOverBackground = new SolidColorBrush(mouseOver);
            ThemeMouseOverForeground = new SolidColorBrush(foreground);
            ThemePressedBackground = new SolidColorBrush(pressed);
            ThemePressedForeground = new SolidColorBrush(foreground);
            ThemeSelectedBackground = new SolidColorBrush(selected);
            ThemeSelectedForeground = new SolidColorBrush(foreground);
        }

        #endregion CONFIGURATION UPDATE

        #region UTILITIES

        //  --------------------------------------------------------------------------------
        /// <summary> Update AHSL color model with new component values. </summary>
        /// <param name="color"> AHSL color model. </param>
        /// <param name="a"> Alpha. </param>
        /// <param name="h"> Hue. </param>
        /// <param name="s"> Saturation. </param>
        /// <param name="l"> Lightness. </param>
        /// <returns> Updated AHSL color model. </returns>
        private AHSLColor UpdateColor(AHSLColor color, byte? a = null, int? h = null, int? s = null, int? l = null)
        {
            return new AHSLColor(
                a.HasValue ? a.Value : color.A,
                h.HasValue ? h.Value : color.H,
                s.HasValue ? s.Value : color.S,
                l.HasValue ? l.Value : color.L);
        }

        #endregion UTILITIES

    }
}
