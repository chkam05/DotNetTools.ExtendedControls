using chkam05.Tools.ControlsEx.Data;
using chkam05.Tools.ControlsEx.Data.Events;
using chkam05.Tools.ControlsEx.Resources;
using chkam05.Tools.ControlsEx.Utilities;
using MaterialDesignThemes.Wpf;
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

        public static readonly DependencyProperty BackgroundInactiveProperty = DependencyProperty.Register(
            nameof(BackgroundInactive),
            typeof(Brush),
            typeof(ColorPickerEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightInactive)));

        public static readonly DependencyProperty BorderBrushInactiveProperty = DependencyProperty.Register(
            nameof(BorderBrushInactive),
            typeof(Brush),
            typeof(ColorPickerEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightInactive)));

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(ColorPickerEx),
            new PropertyMetadata(new CornerRadius(4)));

        public static readonly DependencyProperty HandlerHeightProperty = DependencyProperty.Register(
            nameof(HandlerHeight),
            typeof(double),
            typeof(ColorPickerEx),
            new PropertyMetadata(24d));

        public static readonly DependencyProperty HandlerWidthProperty = DependencyProperty.Register(
            nameof(HandlerWidth),
            typeof(double),
            typeof(ColorPickerEx),
            new PropertyMetadata(24d));

        public static readonly DependencyProperty ShowColorCodeProperty = DependencyProperty.Register(
            nameof(ShowColorCode),
            typeof(bool),
            typeof(ColorPickerEx),
            new PropertyMetadata(true));

        public static readonly DependencyProperty SelectedColorProperty = DependencyProperty.Register(
            nameof(SelectedColor),
            typeof(Color),
            typeof(ColorPickerEx),
            new PropertyMetadata(ColorsResources.DefaultAccentColor, SelectedColorPropertyChangedCallback));

        public static readonly DependencyProperty SliderBrightnessLabelProperty = DependencyProperty.Register(
            nameof(SliderBrightnessLabel),
            typeof(string),
            typeof(ColorPickerEx),
            new PropertyMetadata("Brightness"));

        public static readonly DependencyProperty SliderSaturationLabelProperty = DependencyProperty.Register(
            nameof(SliderSaturationLabel),
            typeof(string),
            typeof(ColorPickerEx),
            new PropertyMetadata("Saturation"));

        public static readonly DependencyProperty SliderStyleProperty = DependencyProperty.Register(
            nameof(SliderStyle),
            typeof(Style),
            typeof(ColorPickerEx),
            new PropertyMetadata(GetGenericSliderExStyle()));


        //  DELEGATES

        public delegate void SelectionChangedEventHandler(object sender, ColorPickerExSelectionChangedEventArgs e);


        //  EVENTS

        public event SelectionChangedEventHandler SelectionChanged;


        //  VARIABLES

        private Border bsBorder;
        private Border colorBorder;
        private Canvas canvasSelector;
        private ThumbEx handler;
        private SliderEx brightnessSlider;
        private SliderEx saturationSlider;

        private bool isDragging = false;
        private bool isUpdating = false;


        //  GETTERS & SETTERS

        public Brush BackgroundInactive
        {
            get => (Brush)GetValue(BackgroundInactiveProperty);
            set => SetValue(BackgroundInactiveProperty, value);
        }

        public Brush BorderBrushInactive
        {
            get => (Brush)GetValue(BorderBrushInactiveProperty);
            set => SetValue(BorderBrushInactiveProperty, value);
        }

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public double HandlerHeight
        {
            get => (double)GetValue(HandlerHeightProperty);
            set => SetValue(HandlerHeightProperty, value);
        }

        public double HandlerWidth
        {
            get => (double)GetValue(HandlerWidthProperty);
            set => SetValue(HandlerWidthProperty, value);
        }

        public Color SelectedColor
        {
            get => (Color)GetValue(SelectedColorProperty);
            set => SetValue(SelectedColorProperty, value);
        }

        public bool ShowColorCode
        {
            get => (bool)GetValue(ShowColorCodeProperty);
            set => SetValue(ShowColorCodeProperty, value);
        }

        public string SliderBrightnessLabel
        {
            get => (string)GetValue(SliderBrightnessLabelProperty);
            set => SetValue(SliderBrightnessLabelProperty, value);
        }

        public string SliderSaturationLabel
        {
            get => (string)GetValue(SliderSaturationLabelProperty);
            set => SetValue(SliderSaturationLabelProperty, value);
        }

        public Style SliderStyle
        {
            get => (Style)GetValue(SliderStyleProperty);
            set => SetValue(SliderStyleProperty, value);
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> ColorPickerEx class constructor. </summary>
        public ColorPickerEx()
        {
            Loaded += OnLoaded;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> ColorPickerEx class constructor. </summary>
        static ColorPickerEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorPickerEx),
                new FrameworkPropertyMetadata(typeof(ColorPickerEx)));
        }

        #endregion CONSTRUCTORS

        #region CONTROL

        //  --------------------------------------------------------------------------------
        /// <summary> Ivoked after loading component. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Routed event arguments. </param>
        protected virtual void OnLoaded(object sender, RoutedEventArgs e)
        {
            UpdateInterface(SelectedColor);
        }

        #endregion CONTROL

        #region EVENTS

        //  --------------------------------------------------------------------------------
        /// <summary> Invokes selection changed event. </summary>
        /// <param name="isUserModified"> If user input caused an event to be triggered. </param>
        private void InvokeSelectionChanged(bool isUserModified)
        {
            SelectionChanged?.Invoke(this, new ColorPickerExSelectionChangedEventArgs(SelectedColor, isUserModified));
        }

        #endregion EVENTS

        #region HANDLER

        //  --------------------------------------------------------------------------------
        /// <summary> Get handler position on canvas selector. </summary>
        /// <returns> Handler position on canvas selector. </returns>
        private Point GetHandlerPosition()
        {
            double x = Canvas.GetLeft(handler) + (handler.Width / 2);
            double y = Canvas.GetTop(handler) + (handler.Width / 2);

            return new Point(x, y);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked after pressing the left mouse button while cursor is over the canvas selector. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Mouse button event args. </param>
        private void OnCanvasSelectorMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDragging = true;
            UpdateColorFromSelector(e.GetPosition(canvasSelector));
            canvasSelector.CaptureMouse();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked while moving the cursor over the canvas selector. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Mouse event args. </param>
        private void OnCanvasSelectorMouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                UpdateColorFromSelector(e.GetPosition(canvasSelector));
            }
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
        /// <summary> Set handler to defined position. </summary>
        /// <param name="position"> Position (as Point) where handler will be placed. </param>
        private void SetHandlerPosition(Point position)
        {
            double x = Math.Max(0, Math.Min(position.X, canvasSelector.ActualWidth));
            double y = Math.Max(0, Math.Min(position.Y, canvasSelector.ActualHeight));

            Canvas.SetLeft(handler, x - handler.Width / 2);
            Canvas.SetTop(handler, y - handler.Height / 2);
        }

        #endregion HANDLER

        #region PROPERTIES CHANGED CALLBACKS

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when SelectedColor property changes. </summary>
        /// <param name="d"> Dependency object from which event has been invoked. </param>
        /// <param name="e"> Dependency property changed event arguments. </param>
        private static void SelectedColorPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var colorPickerEx = d as ColorPickerEx;

            if (colorPickerEx != null && e.NewValue is Color selectedColor)
                colorPickerEx.UpdateInterface(selectedColor);
        }

        #endregion PROPERTIES CHANGED CALLBACKS

        #region SLIDERS

        //  --------------------------------------------------------------------------------
        /// <summary> Occurs when the range value changes in brightness slider. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Routed property changed event arguments. </param>
        private void OnBrightnessSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (isDragging || isUpdating)
                return;

            var x = GetHandlerPosition().X;
            var y = (canvasSelector.ActualHeight * (100 - e.NewValue)) / AHSLColor.LIGHTNESS_MAX;

            var handlerPosition = new Point(x, y);
            var color = GetColorFromHandlerPosition(handlerPosition);

            isUpdating = true;

            SetHandlerPosition(handlerPosition);
            SelectedColor = color.ToColor();
            InvokeSelectionChanged(true);

            isUpdating = false;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Occurs when the range value changes in saturation slider. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Routed property changed event arguments. </param>
        private void OnSaturationSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (isDragging || isUpdating)
                return;

            var handlerPosition = GetHandlerPosition();
            var color = GetColorFromHandlerPosition(handlerPosition);

            isUpdating = true;

            SelectedColor = color.ToColor();
            InvokeSelectionChanged(true);

            isUpdating = false;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set brightness slider TrackBar background. </summary>
        /// <param name="ahslColor"> Selected AHSL color. </param>
        private void SetBrightnessSliderTrackBarBackground(AHSLColor ahslColor)
        {
            if (brightnessSlider == null)
                return;

            brightnessSlider.TrackBarBackground = new LinearGradientBrush(
                new GradientStopCollection()
                {
                    new GradientStop(Colors.White, 0d),
                    new GradientStop(new AHSLColor(ahslColor.A, ahslColor.H, ahslColor.S, 50).ToColor(), 0.5),
                    new GradientStop(Colors.Black, 1d)
                })
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(0, 1)
            };
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Set saturation slider TrackBar background. </summary>
        /// <param name="ahslColor"> Selected AHSL color. </param>
        private void SetSaturationSliderTrackBarBackground(AHSLColor ahslColor)
        {
            if (saturationSlider == null)
                return;

            saturationSlider.TrackBarBackground = new LinearGradientBrush(
                new GradientStopCollection()
                {
                    new GradientStop(new AHSLColor(ahslColor.A, ahslColor.H, 0, ahslColor.L).ToColor(), 0),
                    new GradientStop(new AHSLColor(ahslColor.A, ahslColor.H, 100, ahslColor.L).ToColor(), 1)
                })
            {
                StartPoint = new Point(0, 0.5),
                EndPoint = new Point(1, 0.5)
            };
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Updates brightness slider value. </summary>
        /// <param name="value"> New brightness value (L). </param>
        private void UpdateBrightnessSliderValue(double value)
        {
            if (brightnessSlider != null)
                brightnessSlider.Value = value;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Updates saturation slider value. </summary>
        /// <param name="value"> New saturation value (S). </param>
        private void UpdateSaturationSliderValue(double value)
        {
            if (saturationSlider != null)
                saturationSlider.Value = value;
        }

        #endregion SLIDERS

        #region STYLES

        //  --------------------------------------------------------------------------------
        /// <summary> Get generic SliderEx style from resources. </summary>
        /// <returns> SliderEx style. </returns>
        protected static Style GetGenericSliderExStyle()
        {
            var uri = new Uri("pack://application:,,,/chkam05.Tools.ControlsEx;component/Themes/ColorPickerEx.xaml", UriKind.Absolute);
            var resourceDictionary = new ResourceDictionary { Source = uri };
            return resourceDictionary["ColorPickerEx.SliderExStyle"] as Style;
        }

        #endregion STYLES

        #region TEMPLATE

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked whenever application code or internal processes call ApplyTemplate. </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            bsBorder = GetTemplateChild("bsBorder") as Border;
            colorBorder = GetTemplateChild("colorBorder") as Border;
            canvasSelector = GetTemplateChild("canvasSelector") as Canvas;
            handler = GetTemplateChild("handler") as ThumbEx;
            brightnessSlider = GetTemplateChild("brightnessSlider") as SliderEx;
            saturationSlider = GetTemplateChild("saturationSlider") as SliderEx;

            if (canvasSelector != null && handler != null)
            {
                canvasSelector.MouseMove += OnCanvasSelectorMouseMove;
                canvasSelector.MouseLeftButtonDown += OnCanvasSelectorMouseLeftButtonDown;
                handler.PreviewMouseLeftButtonDown += OnCanvasSelectorMouseLeftButtonDown;
                canvasSelector.MouseLeftButtonUp += OnCanvasSelectorMouseLeftButtonUp;
            }

            if (brightnessSlider != null)
                brightnessSlider.ValueChanged += OnBrightnessSliderValueChanged;

            if (saturationSlider != null)
                saturationSlider.ValueChanged += OnSaturationSliderValueChanged;
        }

        #endregion TEMPLATE

        #region UPDATE

        //  --------------------------------------------------------------------------------
        /// <summary> Calculates and updates color based on handler position. </summary>
        /// <param name="handlerPosition"> Handler position. </param>
        private void UpdateColorFromSelector(Point handlerPosition)
        {
            double x = Math.Max(0, Math.Min(handlerPosition.X, canvasSelector.ActualWidth));
            double y = Math.Max(0, Math.Min(handlerPosition.Y, canvasSelector.ActualHeight));

            SetHandlerPosition(handlerPosition);

            var color = GetColorFromHandlerPosition(handlerPosition);

            SelectedColor = color.ToColor();

            if (!isUpdating)
            {
                UpdateBrightnessSliderValue(color.L);
                UpdateSaturationSliderValue(color.S);
            }

            InvokeSelectionChanged(isDragging);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Updates the interface controls based on the selected color. </summary>
        /// <param name="selectedColor"> Selected color. </param>
        private void UpdateInterface(Color selectedColor)
        {
            var ahslColor = AHSLColor.FromColor(selectedColor);

            if (!isDragging && !isUpdating)
            {
                isUpdating = true;

                var handlerPosition = CalculateHandlerPosition(ahslColor);

                if (handlerPosition.HasValue)
                    SetHandlerPosition(handlerPosition.Value);

                UpdateBrightnessSliderValue(ahslColor.L);
                UpdateSaturationSliderValue(ahslColor.S);
                InvokeSelectionChanged(false);

                isUpdating = false;
            }

            SetBrightnessSliderTrackBarBackground(ahslColor);
            SetSaturationSliderTrackBarBackground(ahslColor);
            UpdateHandlerColor();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Updates handler color to selected color. </summary>
        private void UpdateHandlerColor()
        {
            if (handler != null)
            {
                handler.Background = new SolidColorBrush(SelectedColor);
                handler.BackgroundDragging = new SolidColorBrush(SelectedColor);
                handler.BackgroundMouseOver = new SolidColorBrush(SelectedColor);
            }
        }

        #endregion UPDATE

        #region UTILITIES

        //  --------------------------------------------------------------------------------
        /// <summary> Calculates handler position based on selected color. </summary>
        /// <param name="selectedColor"> Selected color. </param>
        /// <returns> Calculated handler position. </returns>
        private Point? CalculateHandlerPosition(AHSLColor selectedColor)
        {
            if (canvasSelector == null)
                return null;

            var posX = (canvasSelector.ActualWidth * selectedColor.H) / AHSLColor.HUE_MAX;
            var posY = (canvasSelector.ActualWidth * (100 - selectedColor.L)) / AHSLColor.LIGHTNESS_MAX;

            return new Point(posX, posY);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Calculates color based on the handler's position on the canvas. </summary>
        /// <param name="handlerPosition"> The handler's position on the canvas. </param>
        /// <returns> Calculated AHSL color. </returns>
        private AHSLColor GetColorFromHandlerPosition(Point handlerPosition)
        {
            double height = canvasSelector.ActualHeight;
            double width = canvasSelector.ActualWidth;
            double middleHeight = canvasSelector.ActualHeight / 2;

            var relativePosition = new Point(
                handlerPosition.X / canvasSelector.ActualWidth,
                handlerPosition.Y / canvasSelector.ActualHeight);

            double xPixel = relativePosition.X * width;
            double yPixel = relativePosition.Y * height;

            var renderTargetcolorBorder = RenderBrushToBitmap(colorBorder.Background, width, height);
            var hueColor = GetPixelColor(renderTargetcolorBorder, (int)xPixel, (int)(height / 2));
            var ahslColor = AHSLColor.FromColor(hueColor);

            double lightnessFactor = 1.0 - (yPixel / canvasSelector.ActualHeight);

            ahslColor.L = MathUtilities.Clamp((int)(lightnessFactor * 100), 0, 100);
            ahslColor.S = (int)saturationSlider.Value;

            return ahslColor;
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

        #endregion UTILITIES

    }
}
