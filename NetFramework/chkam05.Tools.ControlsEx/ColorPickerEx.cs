﻿using chkam05.Tools.ControlsEx.Data;
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
        private bool lockUpdate = false;


        //  GETTERS & SETTERS

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

        #region COLOR UPDATE

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

        //  --------------------------------------------------------------------------------
        /// <summary> Updates the selected color based on the handler's position on the canvas. </summary>
        /// <param name="relativePosition"> The handler's relative position on the canvas, normalized to [0, 1]. </param>
        private void UpdateSelectedColor(Point relativePosition)
        {
            double height = canvasSelector.ActualHeight;
            double width = canvasSelector.ActualWidth;
            double middleHeight = canvasSelector.ActualHeight / 2;

            double xPixel = relativePosition.X * width;
            double yPixel = relativePosition.Y * height;

            var renderTargetcolorBorder = RenderBrushToBitmap(colorBorder.Background, width, height);
            var hueColor = GetPixelColor(renderTargetcolorBorder, (int)xPixel, (int)(height / 2));
            var ahslColor = AHSLColor.FromColor(hueColor);
            
            double lightnessFactor = 1.0 - (yPixel / canvasSelector.ActualHeight);

            ahslColor.S = (int)saturationSlider.Value;
            ahslColor.L = MathUtilities.Clamp((int)(lightnessFactor * 100), 0, 100);

            bool isUserModified = !lockUpdate;

            InvokeInLockUpdateMode(() =>
            {
                SelectedColor = ahslColor.ToColor();
                InvokeSelectionChanged(isUserModified);
            });
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Updates the interface controls based on the selected color. </summary>
        /// <param name="selectedColor"> Selected color. </param>
        private void UpdateInterface(Color selectedColor)
        {
            var ahslColor = AHSLColor.FromColor(selectedColor);
            InvokeInLockUpdateMode(() =>
            {
                UpdateHandlerPosition(ahslColor);
                UpdateBrightnessSliderValue(ahslColor);
                UpdateSaturationSliderValue(ahslColor);
                UpdateHandlerColor();
            });
            
            InvokeSelectionChanged(false);
        }

        #endregion COLOR UPDATE

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

        #region SELECTOR

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked while moving the cursor over the canvas selector. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Mouse event args. </param>
        private void OnCanvasSelectorMouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                MoveHandlerAndUpdateColor(e.GetPosition(canvasSelector));
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked after pressing the left mouse button while cursor is over the canvas selector. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Mouse button event args. </param>
        private void OnCanvasSelectorMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDragging = true;
            MoveHandlerAndUpdateColor(e.GetPosition(canvasSelector));
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
        /// <summary> Get handler position on canvas selector. </summary>
        /// <returns> Handler position on canvas selector. </returns>
        private Point GetHandlerPosition()
        {
            double x = Canvas.GetLeft(handler) + (handler.Width / 2);
            double y = Canvas.GetTop(handler) + (handler.Width / 2);

            return new Point(x, y);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Moves handler to defined position. </summary>
        /// <param name="position"> Position (as Point) where handler will be placed. </param>
        private void MoveHandler(Point position)
        {
            double x = Math.Max(0, Math.Min(position.X, canvasSelector.ActualWidth));
            double y = Math.Max(0, Math.Min(position.Y, canvasSelector.ActualHeight));

            Canvas.SetLeft(handler, x - handler.Width / 2);
            Canvas.SetTop(handler, y - handler.Height / 2);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Moves handler to defined position and updates the color based on the handler position. </summary>
        /// <param name="position"> Position (as Point) where handler will be placed. </param>
        private void MoveHandlerAndUpdateColor(Point position)
        {
            double x = Math.Max(0, Math.Min(position.X, canvasSelector.ActualWidth));
            double y = Math.Max(0, Math.Min(position.Y, canvasSelector.ActualHeight));

            MoveHandler(position);
            InvokeInLockUpdateMode(() => saturationSlider.Value = 100);
            UpdateSelectedColor(new Point(x / canvasSelector.ActualWidth, y / canvasSelector.ActualHeight));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Calculates the new position of the handle on the color picker and moves the handle. </summary>
        /// <param name="newSelectedColor"> New color. </param>
        private void UpdateHandlerPosition(AHSLColor newSelectedColor)
        {
            if (canvasSelector == null)
                return;

            var posX = (canvasSelector.ActualWidth * newSelectedColor.H) / AHSLColor.HUE_MAX;
            var posY = (canvasSelector.ActualWidth * (100 - newSelectedColor.L)) / AHSLColor.LIGHTNESS_MAX;
            MoveHandler(new Point(posX, posY));
        }

        #endregion SELECTOR

        #region SLIDERS

        //  --------------------------------------------------------------------------------
        /// <summary> Occurs when the range value changes in brightness slider. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Routed property changed event arguments. </param>
        private void OnBrightnessSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (lockUpdate)
                return;

            var x = GetHandlerPosition().X;
            var y = (canvasSelector.ActualHeight * (100 - e.NewValue)) / AHSLColor.LIGHTNESS_MAX;

            MoveHandler(new Point(x, y));
            UpdateSelectedColor(new Point(x / canvasSelector.ActualWidth, y / canvasSelector.ActualHeight));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Occurs when the range value changes in saturation slider. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Routed property changed event arguments. </param>
        private void OnSaturationSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (lockUpdate)
                return;

            var hPos = GetHandlerPosition();

            UpdateSelectedColor(new Point(hPos.X / canvasSelector.ActualWidth, hPos.Y / canvasSelector.ActualHeight));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Updates brightness slider value. </summary>
        /// <param name="newSelectedColor"> New selected ahsl color. </param>
        private void UpdateBrightnessSliderValue(AHSLColor newSelectedColor)
        {
            if (brightnessSlider != null)
                brightnessSlider.Value = newSelectedColor.L;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Updates saturation slider value. </summary>
        /// <param name="newSelectedColor"> New selected ahsl color. </param>
        private void UpdateSaturationSliderValue(AHSLColor newSelectedColor)
        {
            if (saturationSlider != null)
                saturationSlider.Value = newSelectedColor.S;
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

        #region UTILITIES

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

        //  --------------------------------------------------------------------------------
        /// <summary> Performs actions in update lock mode. </summary>
        /// <param name="action"> The action that will be performed. </param>
        private void InvokeInLockUpdateMode(Action action)
        {
            lockUpdate = true;
            action?.Invoke();
            lockUpdate = false;
        }

        #endregion UTILITIES

    }
}
