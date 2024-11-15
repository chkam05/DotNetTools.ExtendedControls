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

        private Color appearanceColor = ColorsResources.DefaultAccentColor;
        private Brush accentBackground;
        private Brush accentBorderBrush;
        private Brush accentForeground;
        private Brush accentMouseOverBackground;
        private Brush accentMouseOverBorderBrush;
        private Brush accentMouseOverForeground;
        private Brush accentPressedBackground;
        private Brush accentPressedBorderBrush;
        private Brush accentPressedForeground;
        private Brush accentSelectedBackground;
        private Brush accentSelectedBorderBrush;
        private Brush accentSelectedForeground;

        private int accentMouseOverColorFactor = -15;
        private int accentPressedColorFactor = 10;
        private int accentSelectedColorFactor = 5;

        private bool enableIndependentAccentConfig = false;
        private bool enableIndependentThemeConfig = false;

        private Brush inactiveBackground;
        private Brush inactiveBorderBrush;
        private Brush inactiveForeground;
        private double inactiveOpacity = 0.56;

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

        public Brush InactiveBackground
        {
            get => inactiveBackground;
            set => UpdateProperty(ref inactiveBackground, value);
        }

        public Brush InactiveBorderBrush
        {
            get => inactiveBorderBrush;
            set => UpdateProperty(ref inactiveBorderBrush, value);
        }

        public Brush InactiveForeground
        {
            get => inactiveForeground;
            set => UpdateProperty(ref inactiveForeground, value);
        }

        public double InactiveOpacity
        {
            get => inactiveOpacity;
            set => UpdateProperty(ref inactiveOpacity, MathUtilities.Clamp(value, 0d, 1d));
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

            var mouseOver = ColorsUtilities.UpdateColor(ahslColor, l: ahslColor.L - accentMouseOverColorFactor).ToColor();
            var pressed = ColorsUtilities.UpdateColor(ahslColor, l: ahslColor.L - accentPressedColorFactor).ToColor();
            var selected = ColorsUtilities.UpdateColor(ahslColor, l: ahslColor.L - accentSelectedColorFactor).ToColor();

            AccentBackground = new SolidColorBrush(color);
            AccentBorderBrush = new SolidColorBrush(color);
            AccentForeground = new SolidColorBrush(foreground);
            AccentMouseOverBackground = new SolidColorBrush(mouseOver);
            AccentMouseOverBorderBrush = new SolidColorBrush(mouseOver);
            AccentMouseOverForeground = new SolidColorBrush(foreground);
            
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

            InactiveBackground = new SolidColorBrush(inactive);
            InactiveBorderBrush = new SolidColorBrush(inactive);
            InactiveForeground = new SolidColorBrush(inactiveForeground);

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

    }
}
