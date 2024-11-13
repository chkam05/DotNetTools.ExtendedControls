using chkam05.Tools.ControlsEx.Data;
using chkam05.Tools.ControlsEx.Events;
using chkam05.Tools.ControlsEx.Static;
using chkam05.Tools.ControlsEx.Utilities;
using System;
using System.Windows;
using System.Windows.Media;


namespace chkam05.Tools.ControlsEx.InternalMessages
{
    public class BaseProgressInternalMessageEx : BaseInternalMessageEx<InternalMessageCloseEventArgs>
    {

        //  CONST

        internal readonly static double PROGRESS_MAX = 100d;
        internal readonly static double PROGRESS_MIN = 0d;


        //  DEPENDENCY PROPERTIES

        #region Appearance Properties

        public static readonly DependencyProperty ProgressBarBackgroundProperty = DependencyProperty.Register(
            nameof(ProgressBarBackground),
            typeof(Brush),
            typeof(BaseProgressInternalMessageEx),
            new PropertyMetadata(new SolidColorBrush(System.Windows.Media.Colors.Transparent)));

        public static readonly DependencyProperty ProgressBarBorderBrushProperty = DependencyProperty.Register(
            nameof(ProgressBarBorderBrush),
            typeof(Brush),
            typeof(BaseProgressInternalMessageEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        public static readonly DependencyProperty ProgressBarProgressBrushProperty = DependencyProperty.Register(
            nameof(ProgressBarProgressBrush),
            typeof(Brush),
            typeof(BaseProgressInternalMessageEx),
            new PropertyMetadata(new SolidColorBrush(StaticResources.ACCENT_COLOR)));

        #endregion Appearance Properties

        #region ProgressBar Properties

        public static readonly DependencyProperty ProgressMarginProperty = DependencyProperty.Register(
            nameof(ProgressMargin),
            typeof(Thickness),
            typeof(BaseProgressInternalMessageEx),
            new PropertyMetadata(new Thickness(8,0,8,8)));

        public static readonly DependencyProperty ProgressMaxProperty = DependencyProperty.Register(
            nameof(ProgressMax),
            typeof(double),
            typeof(BaseProgressInternalMessageEx),
            new PropertyMetadata(PROGRESS_MAX));

        public static readonly DependencyProperty ProgressMinProperty = DependencyProperty.Register(
            nameof(ProgressMin),
            typeof(double),
            typeof(BaseProgressInternalMessageEx),
            new PropertyMetadata(PROGRESS_MIN));

        public static readonly DependencyProperty ProgressProperty = DependencyProperty.Register(
            nameof(Progress),
            typeof(double),
            typeof(BaseProgressInternalMessageEx),
            new PropertyMetadata(PROGRESS_MIN));

        #endregion ProgressBar Properties


        //  VARIABLES

        private bool _allowCancel = false;
        private bool _keepFinishedOpen = false;


        //  GETTERS & SETTERS

        #region Appearance

        public Brush ProgressBarBackground
        {
            get => (Brush)GetValue(ProgressBarBackgroundProperty);
            set
            {
                SetValue(ProgressBarBackgroundProperty, value);
                OnPropertyChanged(nameof(ProgressBarBackground));
            }
        }

        public Brush ProgressBarBorderBrush
        {
            get => (Brush)GetValue(ProgressBarBorderBrushProperty);
            set
            {
                SetValue(ProgressBarBorderBrushProperty, value);
                OnPropertyChanged(nameof(ProgressBarBorderBrush));
            }
        }

        public Brush ProgressBarProgressBrush
        {
            get => (Brush)GetValue(ProgressBarProgressBrushProperty);
            set
            {
                SetValue(ProgressBarProgressBrushProperty, value);
                OnPropertyChanged(nameof(ProgressBarProgressBrush));
            }
        }

        #endregion Appearance

        #region ProgressBar

        public Thickness ProgressMargin
        {
            get => (Thickness)GetValue(ProgressMarginProperty);
            set
            {
                SetValue(ProgressMarginProperty, value);
                OnPropertyChanged(nameof(ProgressMargin));
            }
        }

        public double ProgressMax
        {
            get => (double)GetValue(ProgressMaxProperty);
            set
            {
                SetValue(ProgressMaxProperty, value);
                OnPropertyChanged(nameof(ProgressMax));
            }
        }

        public double ProgressMin
        {
            get => (double)GetValue(ProgressMinProperty);
            set
            {
                SetValue(ProgressMinProperty, value);
                OnPropertyChanged(nameof(ProgressMin));
            }
        }

        public double Progress
        {
            get => (double)GetValue(ProgressProperty);
            set
            {
                SetValue(ProgressProperty, Math.Max(Math.Min(value, ProgressMax), ProgressMin));
                OnPropertyChanged(nameof(Progress));
            }
        }

        #endregion ProgressBar

        public bool AllowCancel
        {
            get => _allowCancel;
            set
            {
                _allowCancel = value;
                OnPropertyChanged(nameof(AllowCancel));

                if (IsLoadingComplete)
                    OnAllowCancelUpdate(value);
            }
        }

        public bool KeepFinishedOpen
        {
            get => _keepFinishedOpen;
            set
            {
                _keepFinishedOpen = value;
                OnPropertyChanged(nameof(KeepFinishedOpen));
            }
        }

        public DispatcherInvokerEx DispatcherInvoker { get; private set; }


        //  METHODS

        #region CLASS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> BaseProgressInternalMessageEx class constructor. </summary>
        /// <param name="parentContainer"> Parent InternalMessagesEx container. </param>
        public BaseProgressInternalMessageEx(InternalMessagesExContainer parentContainer) : base(parentContainer)
        {
            DispatcherInvoker = new DispatcherInvokerEx(this.Dispatcher);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Static BaseProgressInternalMessageEx class constructor. </summary>
        static BaseProgressInternalMessageEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BaseProgressInternalMessageEx),
                new FrameworkPropertyMetadata(typeof(BaseProgressInternalMessageEx)));
        }

        #endregion CLASS METHODS

        #region BUTTONS METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Ok Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected virtual void OnOkClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Yes Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected virtual void OnCancelClick(object sender, RoutedEventArgs e)
        {
            OnProgressCanceled();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after clicking Hide Button. </summary>
        /// <param name="sender"> Object that invoked method. </param>
        /// <param name="e"> Routed Event Arguments. </param>
        protected virtual void OnHideClick(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        #endregion BUTTONS METHODS

        #region INTERACTION METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Invoke finish work of progressbar. </summary>
        /// <param name="finishedProperly"> True - progress finished properly; False - otherwise. </param>
        public void InvokeFinsh(bool finishedProperly = true)
        {
            DispatcherInvoker.TryInvoke(() =>
            {
                Result = finishedProperly ? InternalMessageResult.Ok : InternalMessageResult.Cancel;
                OnProgressFinish();
            });
        }

        #endregion INTERACTION METHODS

        #region TEMPLATE METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> When overridden in a derived class,cis invoked whenever 
        /// application code or internal processes call ApplyTemplate. </summary>
        public override void OnApplyTemplate()
        {
            //  Apply Template
            base.OnApplyTemplate();

            ApplyButtonExClickMethod(GetButtonEx("hideButton"), OnHideClick);
            ApplyButtonExClickMethod(GetButtonEx("cancelButton"), OnCancelClick);
            ApplyButtonExClickMethod(GetButtonEx("okButton"), OnOkClick);
            OnAllowCancelUpdate(AllowCancel);
            OnAllowHideUpdate(AllowHide);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after changing AllowHide property. </summary>
        /// <param name="showHide"> True - allow hide; False - otherwise. </param>
        protected override void OnAllowHideUpdate(bool showHide = false)
        {
            var buttonHide = GetButtonEx("hideButton");
            buttonHide.Visibility = showHide ? Visibility.Visible : Visibility.Collapsed;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after changing AllowCancel property. </summary>
        /// <param name="allowCancel"> True - allow cancel; False - otherwise. </param>
        protected virtual void OnAllowCancelUpdate(bool allowCancel = false)
        {
            var buttonCancel = GetButtonEx("cancelButton");
            buttonCancel.IsEnabled = allowCancel;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Message invoked after canceling progress. </summary>
        protected virtual void OnProgressCanceled()
        {
            Result = InternalMessageResult.Cancel;

            if (KeepFinishedOpen)
            {
                var buttonCancel = GetButtonEx("cancelButton");
                buttonCancel.Visibility = Visibility.Collapsed;

                var buttonOk = GetButtonEx("okButton");
                buttonOk.Visibility = Visibility.Visible;

                if (IsHidden)
                    Show();

                InvokeClose(new InternalMessageCloseEventArgs(Result));
            }
            else
            {
                Close();
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Method invoked after finishing progress. </summary>
        protected virtual void OnProgressFinish()
        {
            if (KeepFinishedOpen)
            {
                var buttonCancel = GetButtonEx("cancelButton");
                buttonCancel.Visibility = Visibility.Collapsed;

                var buttonOk = GetButtonEx("okButton");
                buttonOk.Visibility = Visibility.Visible;

                if (IsHidden)
                    Show();
            }
            else
            {
                Close();
            }
        }

        #endregion TEMPLATE METHODS

    }
}
