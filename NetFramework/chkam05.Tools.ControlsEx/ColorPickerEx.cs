using chkam05.Tools.ControlsEx.Data;
using chkam05.Tools.ControlsEx.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace chkam05.Tools.ControlsEx
{
    public class ColorPickerEx : Control
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(ColorPickerEx),
            new PropertyMetadata(new CornerRadius(4)));

        public static readonly DependencyProperty SelectedColorProperty = DependencyProperty.Register(
            nameof(SelectedColor),
            typeof(Color),
            typeof(ColorPickerEx),
            new PropertyMetadata(Colors.Red, SelectedColorPropertyChangedCallback));


        //  VARIABLES

        private Border bsBorder;
        private Border colorBorder;
        private Canvas canvasSelector;
        private Ellipse handler;
        private bool isDragging = false;


        //  GETTERS & SETTERS

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public Color SelectedColor
        {
            get => (Color)GetValue(SelectedColorProperty);
            set => SetValue(SelectedColorProperty, value);
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> ColorPickerEx class constructor. </summary>
        static ColorPickerEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorPickerEx),
                new FrameworkPropertyMetadata(typeof(ColorPickerEx)));
        }

        #endregion CONSTRUCTORS

        #region COLOR UPDATE

        //  --------------------------------------------------------------------------------
        /// <summary> Updates handler color to selected color. </summary>
        private void UpdateHandlerColor()
        {
            if (handler != null)
                handler.Fill = new SolidColorBrush(SelectedColor);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Updates the selected color based on the handler's position on the canvas. </summary>
        /// <param name="relativePosition"> The handler's relative position on the canvas, normalized to [0, 1]. </param>
        private void UpdateSelectedColor(Point relativePosition)
        {
            double width = canvasSelector.ActualWidth;
            double height = canvasSelector.ActualHeight;

            double xPixel = relativePosition.X * width;
            double yPixel = relativePosition.Y * height;

            var renderTargetcolorBorder = RenderBrushToBitmap(colorBorder.Background, width, height);

            var hueColor = GetPixelColor(renderTargetcolorBorder, (int)xPixel, (int)(height / 2));
            var ahslColor = AHSLColor.FromColor(hueColor);

            double middleHeight = height / 2;

            double lightnessFactor = yPixel > middleHeight
                ? (1.0 - (yPixel / middleHeight))
                : ahslColor.L;

            double saturationFactor = 0;

            SelectedColor = AdjustColorForSaturationAndBrightness(hueColor, yPixel);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Adjusts the hue color by modifying its saturation and brightness. </summary>
        /// <param name="hueColor"> The base hue color to adjust. </param>
        /// <param name="yPos"> Current handler y position. </param>
        /// <returns> A Color object representing the adjusted color. </returns>
        private Color AdjustColorForSaturationAndBrightness(Color hueColor, double yPos)
        {
            var ahslColor = AHSLColor.FromColor(hueColor);
            double middleHeight = canvasSelector.ActualHeight / 2;

            double lightnessFactor = 1.0 - (yPos / canvasSelector.ActualHeight);

            ahslColor.S = 100;
            ahslColor.L = MathUtilities.Clamp((int)(lightnessFactor * 100), 0, 100);

            // Convert back to RGB and return the color
            return ahslColor.ToColor();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Reads the color of a specific pixel from a RenderTargetBitmap. </summary>
        /// <param name="bitmap"> The bitmap from which to read the pixel color. </param>
        /// <param name="x"> The X-coordinate of the pixel to read (in pixels). </param>
        /// <param name="y"> The Y-coordinate of the pixel to read (in pixels). </param>
        /// <returns> A Color object representing the RGBA value of the specified pixel, or transparent if the coordinates are out of bounds. </returns>
        private Color GetPixelColor(RenderTargetBitmap bitmap, int x, int y)
        {
            if (bitmap.PixelWidth == 0 || bitmap.PixelHeight == 0)
                return Colors.Transparent;

            byte[] pixels = new byte[4]; // R, G, B, A
            var rect = new Int32Rect(
                MathUtilities.Clamp(x, 0, bitmap.PixelWidth - 1),
                MathUtilities.Clamp(y, 0, bitmap.PixelHeight - 1),
                1, 1);

            bitmap.CopyPixels(rect, pixels, 4, 0);

            return Color.FromArgb(pixels[3], pixels[2], pixels[1], pixels[0]);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Renders a given Brush (e.g., a gradient) onto a bitmap with specified dimensions. </summary>
        /// <param name="brush"> The brush to render onto the bitmap. </param>
        /// <param name="width"> The width of the rendered bitmap in pixels. </param>
        /// <param name="height"> The height of the rendered bitmap in pixels. </param>
        /// <returns> A RenderTargetBitmap containing the rendered brush. </returns>
        private RenderTargetBitmap RenderBrushToBitmap(Brush brush, double width, double height)
        {
            var renderTarget = new RenderTargetBitmap((int)width, (int)height, 96, 96, PixelFormats.Pbgra32);
            var visual = new DrawingVisual();

            using (var context = visual.RenderOpen())
            {
                context.DrawRectangle(brush, null, new Rect(0, 0, width, height));
            }

            renderTarget.Render(visual);
            return renderTarget;
        }

        #endregion COLOR UPDATE

        #region PROPERTIES CHANGED CALLBACKS

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when SelectedColor property changes. </summary>
        /// <param name="d"> Dependency object from which event has been invoked. </param>
        /// <param name="e"> Dependency property changed event arguments. </param>
        private static void SelectedColorPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var colorPickerEx = d as ColorPickerEx;

            if (colorPickerEx != null)
                colorPickerEx.UpdateHandlerColor();
        }

        #endregion PROPERTIES CHANGED CALLBACKS

        #region SELECTOR

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked while moving the cursor over the canvas selector. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Mouse event args. </param>
        private void OnCanvasSelectorMouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                MoveHandler(e.GetPosition(canvasSelector));
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked after pressing the left mouse button while cursor is over the canvas selector. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Mouse button event args. </param>
        private void OnCanvasSelectorMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDragging = true;
            MoveHandler(e.GetPosition(canvasSelector));
            canvasSelector.CaptureMouse();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked after releasing the left mouse button while cursor is over the canvas selector. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Mouse button event args. </param>
        private void OnCanvasSelectorMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
            canvasSelector.ReleaseMouseCapture();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Moves handler to defined position. </summary>
        /// <param name="position"> Position (as Point) where handler will be placed. </param>
        private void MoveHandler(Point position)
        {
            if (canvasSelector == null || handler == null)
                return;

            // Ograniczenie ruchu "handler" do granic Canvas
            double x = Math.Max(0, Math.Min(position.X, canvasSelector.ActualWidth));
            double y = Math.Max(0, Math.Min(position.Y, canvasSelector.ActualHeight));

            Canvas.SetLeft(handler, x - handler.Width / 2);
            Canvas.SetTop(handler, y - handler.Height / 2);

            // Wyliczenie koloru na podstawie pozycji
            UpdateSelectedColor(new Point(x / canvasSelector.ActualWidth, y / canvasSelector.ActualHeight));
        }

        #endregion SELECTOR

        #region TEMPLATE

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked whenever application code or internal processes call ApplyTemplate. </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            bsBorder = GetTemplateChild("bsBorder") as Border;
            colorBorder = GetTemplateChild("colorBorder") as Border;
            canvasSelector = GetTemplateChild("canvasSelector") as Canvas;
            handler = GetTemplateChild("handler") as Ellipse;

            if (canvasSelector != null && handler != null)
            {
                canvasSelector.MouseMove += OnCanvasSelectorMouseMove;
                canvasSelector.MouseLeftButtonDown += OnCanvasSelectorMouseLeftButtonDown;
                canvasSelector.MouseLeftButtonUp += OnCanvasSelectorMouseLeftButtonUp;
            }
        }

        #endregion TEMPLATE

    }
}
