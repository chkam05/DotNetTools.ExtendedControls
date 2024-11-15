using chkam05.Tools.ControlsEx.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace chkam05.Tools.ControlsEx.Resources
{
    public static class ColorsResources
    {
        //  BASE ACCENT COLORS

        public static readonly Color DefaultAccentColor = Color.FromArgb(255, 0, 120, 215);
        public static readonly Color DefaultAccentColorForeground = Color.FromArgb(255, 255, 255, 255);
        public static readonly Color DefaultAccentColorMouseOver = Color.FromArgb(255, 35, 157, 254);
        public static readonly Color DefaultAccentColorPressed = Color.FromArgb(255, 0, 90, 163);
        public static readonly Color DefaultAccentColorSelected = Color.FromArgb(255, 0, 105, 188);

        //  BASE THEME COLORS

        public static readonly Color DarkBackground = Colors.Black;
        public static readonly Color DarkForeground = Colors.White;
        public static readonly Color DarkInactive = Color.FromArgb(255, 94, 94, 94);
        public static readonly Color DarkMouseOver = Color.FromArgb(255, 127, 127, 127);
        public static readonly Color DarkPressed = Color.FromArgb(255, 43, 43, 43);
        public static readonly Color DarkSelected = Color.FromArgb(255, 86, 86, 86);
        public static readonly Color DarkShadeBackground = Color.FromArgb(255, 36, 36, 36);

        public static readonly Color LightBackground = Colors.White;
        public static readonly Color LightForeground = Colors.Black;
        public static readonly Color LighInactive = Color.FromArgb(255, 160, 160, 160);
        public static readonly Color LighMouseOver = Color.FromArgb(255, 127, 127, 127);
        public static readonly Color LighPressed = Color.FromArgb(255, 211, 211, 211);
        public static readonly Color LighSelected = Color.FromArgb(255, 168, 168, 168);
        public static readonly Color LightShadeBackground = Color.FromArgb(255, 219, 219, 219);

        //  PALETTE COLORS

        public static readonly ColorEx GoldYellow = ColorEx.CreateFromHexCode("#FFB900", "Gold Yellow");
        public static readonly ColorEx Gold = ColorEx.CreateFromHexCode("#FF8C00", "Gold");
        public static readonly ColorEx BrightOrange = ColorEx.CreateFromHexCode("#F7630C", "Bright Orange");
        public static readonly ColorEx DarkOrange = ColorEx.CreateFromHexCode("#C24D0F", "Dark Orange");
        public static readonly ColorEx Rusty = ColorEx.CreateFromHexCode("#D53A01", "Rusty");
        public static readonly ColorEx PaleRusty = ColorEx.CreateFromHexCode("#EF6950", "Pale Rusty");
        public static readonly ColorEx BrickRed = ColorEx.CreateFromHexCode("#CF3438", "Brick Red");
        public static readonly ColorEx ModerateRed = ColorEx.CreateFromHexCode("#F94141", "Moderate Red");

        public static readonly ColorEx PaleRed = ColorEx.CreateFromHexCode("#E74856", "Pale Red");
        public static readonly ColorEx Red = ColorEx.CreateFromHexCode("#E81123", "Red");
        public static readonly ColorEx LightPink = ColorEx.CreateFromHexCode("#EA005E", "Light Pink");
        public static readonly ColorEx Rose = ColorEx.CreateFromHexCode("#BA004E", "Rose");
        public static readonly ColorEx LightPlum = ColorEx.CreateFromHexCode("#DF0089", "Light Plum");
        public static readonly ColorEx Plum = ColorEx.CreateFromHexCode("#BA0074", "Plum");
        public static readonly ColorEx LightlyOrchid = ColorEx.CreateFromHexCode("#C239B3", "Lightly Orchid");
        public static readonly ColorEx Orchid = ColorEx.CreateFromHexCode("#950084", "Orchid");

        public static readonly ColorEx Blue = ColorEx.CreateFromHexCode("#0078D7", "Blue");
        public static readonly ColorEx Navy = ColorEx.CreateFromHexCode("#0063B1", "Navy");
        public static readonly ColorEx PurpleShade = ColorEx.CreateFromHexCode("#8785CE", "Purple Shade");
        public static readonly ColorEx DarkPurpleShade = ColorEx.CreateFromHexCode("#6B69D6", "Dark Purple Shade");
        public static readonly ColorEx PastelIris = ColorEx.CreateFromHexCode("#8562B5", "Pastel Iris");
        public static readonly ColorEx BrightlyIridescent = ColorEx.CreateFromHexCode("#704BA4", "Brightly Iridescent");
        public static readonly ColorEx LightPurpleRed = ColorEx.CreateFromHexCode("#AD44BD", "Light Purple Red");
        public static readonly ColorEx PurpleRed = ColorEx.CreateFromHexCode("#881798", "Purple Red");

        public static readonly ColorEx BrightBlue = ColorEx.CreateFromHexCode("#0099BC", "Bright Blue");
        public static readonly ColorEx LightBlue = ColorEx.CreateFromHexCode("#2D7D9A", "Light Blue");
        public static readonly ColorEx SeaFoam = ColorEx.CreateFromHexCode("#00B7C3", "Sea Foam");
        public static readonly ColorEx Greeny = ColorEx.CreateFromHexCode("#038387", "Greeny");
        public static readonly ColorEx LightMint = ColorEx.CreateFromHexCode("#00B294", "Light Mint");
        public static readonly ColorEx DarkMint = ColorEx.CreateFromHexCode("#018170", "Dark Mint");
        public static readonly ColorEx Peaty = ColorEx.CreateFromHexCode("#00CC6A", "Peaty");
        public static readonly ColorEx BrightGreen = ColorEx.CreateFromHexCode("#10893E", "Bright Green");

        public static readonly ColorEx Gray = ColorEx.CreateFromHexCode("#746F6E", "Gray");
        public static readonly ColorEx GrayBrown = ColorEx.CreateFromHexCode("#5D5A58", "Gray Brown");
        public static readonly ColorEx SteelBlue = ColorEx.CreateFromHexCode("#68768A", "Steel Blue");
        public static readonly ColorEx MetalicBlue = ColorEx.CreateFromHexCode("#515C6B", "Metalic Blue");
        public static readonly ColorEx PaleDarkGreen = ColorEx.CreateFromHexCode("#567C73", "Pale Dark Green");
        public static readonly ColorEx DarkGreen = ColorEx.CreateFromHexCode("#47675F", "Dark Green");
        public static readonly ColorEx LightGreen = ColorEx.CreateFromHexCode("#498205", "Light Green");
        public static readonly ColorEx Green = ColorEx.CreateFromHexCode("#107C10", "Green");

        public static readonly ColorEx Cloudy = ColorEx.CreateFromHexCode("#6B6B6B", "Cloudy");
        public static readonly ColorEx Storm = ColorEx.CreateFromHexCode("#4A4846", "Storm");
        public static readonly ColorEx BlueGray = ColorEx.CreateFromHexCode("#69797E", "Blue Gray");
        public static readonly ColorEx DarkGray = ColorEx.CreateFromHexCode("#464F54", "Dark Gray");
        public static readonly ColorEx ShadedGreen = ColorEx.CreateFromHexCode("#637B63", "Shaded Green");
        public static readonly ColorEx Sage = ColorEx.CreateFromHexCode("#525E54", "Sage");
        public static readonly ColorEx Desert = ColorEx.CreateFromHexCode("#847545", "Desert");
        public static readonly ColorEx Moro = ColorEx.CreateFromHexCode("#766B59", "Moro");

        //  PALETTE BRUSHES

        public static readonly Brush GoldYellowBrush = new SolidColorBrush(GoldYellow.Color);
        public static readonly Brush GoldBrush = new SolidColorBrush(Gold.Color);
        public static readonly Brush BrightOrangeBrush = new SolidColorBrush(BrightOrange.Color);
        public static readonly Brush DarkOrangeBrush = new SolidColorBrush(DarkOrange.Color);
        public static readonly Brush RustyBrush = new SolidColorBrush(Rusty.Color);
        public static readonly Brush PaleRustyBrush = new SolidColorBrush(PaleRusty.Color);
        public static readonly Brush BrickRedBrush = new SolidColorBrush(BrickRed.Color);
        public static readonly Brush ModerateRedBrush = new SolidColorBrush(ModerateRed.Color);

        public static readonly Brush PaleRedBrush = new SolidColorBrush(PaleRed.Color);
        public static readonly Brush RedBrush = new SolidColorBrush(Red.Color);
        public static readonly Brush LightPinkBrush = new SolidColorBrush(LightPink.Color);
        public static readonly Brush RoseBrush = new SolidColorBrush(Rose.Color);
        public static readonly Brush LightPlumBrush = new SolidColorBrush(LightPlum.Color);
        public static readonly Brush PlumBrush = new SolidColorBrush(Plum.Color);
        public static readonly Brush LightlyOrchidBrush = new SolidColorBrush(LightlyOrchid.Color);
        public static readonly Brush OrchidBrush = new SolidColorBrush(Orchid.Color);

        public static readonly Brush BlueBrush = new SolidColorBrush(Blue.Color);
        public static readonly Brush NavyBrush = new SolidColorBrush(Navy.Color);
        public static readonly Brush PurpleShadeBrush = new SolidColorBrush(PurpleShade.Color);
        public static readonly Brush DarkPurpleShadeBrush = new SolidColorBrush(DarkPurpleShade.Color);
        public static readonly Brush PastelIrisBrush = new SolidColorBrush(PastelIris.Color);
        public static readonly Brush BrightlyIridescentBrush = new SolidColorBrush(BrightlyIridescent.Color);
        public static readonly Brush LightPurpleRedBrush = new SolidColorBrush(LightPurpleRed.Color);
        public static readonly Brush PurpleRedBrush = new SolidColorBrush(PurpleRed.Color);

        public static readonly Brush BrightBlueBrush = new SolidColorBrush(BrightBlue.Color);
        public static readonly Brush LightBlueBrush = new SolidColorBrush(LightBlue.Color);
        public static readonly Brush SeaFoamBrush = new SolidColorBrush(SeaFoam.Color);
        public static readonly Brush GreenyBrush = new SolidColorBrush(Greeny.Color);
        public static readonly Brush LightMintBrush = new SolidColorBrush(LightMint.Color);
        public static readonly Brush DarkMintBrush = new SolidColorBrush(DarkMint.Color);
        public static readonly Brush PeatyBrush = new SolidColorBrush(Peaty.Color);
        public static readonly Brush BrightGreenBrush = new SolidColorBrush(BrightGreen.Color);

        public static readonly Brush GrayBrush = new SolidColorBrush(Gray.Color);
        public static readonly Brush GrayBrownBrush = new SolidColorBrush(GrayBrown.Color);
        public static readonly Brush SteelBlueBrush = new SolidColorBrush(SteelBlue.Color);
        public static readonly Brush MetalicBlueBrush = new SolidColorBrush(MetalicBlue.Color);
        public static readonly Brush PaleDarkGreenBrush = new SolidColorBrush(PaleDarkGreen.Color);
        public static readonly Brush DarkGreenBrush = new SolidColorBrush(DarkGreen.Color);
        public static readonly Brush LightGreenBrush = new SolidColorBrush(LightGreen.Color);
        public static readonly Brush GreenBrush = new SolidColorBrush(Green.Color);

        public static readonly Brush CloudyBrush = new SolidColorBrush(Cloudy.Color);
        public static readonly Brush StormBrush = new SolidColorBrush(Storm.Color);
        public static readonly Brush BlueGrayBrush = new SolidColorBrush(BlueGray.Color);
        public static readonly Brush DarkGrayBrush = new SolidColorBrush(DarkGray.Color);
        public static readonly Brush ShadedGreenBrush = new SolidColorBrush(ShadedGreen.Color);
        public static readonly Brush SageBrush = new SolidColorBrush(Sage.Color);
        public static readonly Brush DesertBrush = new SolidColorBrush(Desert.Color);
        public static readonly Brush MoroBrush = new SolidColorBrush(Moro.Color);
    }
}
