using chkam05.Tools.ControlsEx.Data;
using chkam05.Tools.ControlsEx.Example.Windows;
using chkam05.Tools.ControlsEx.Resources;
using chkam05.Tools.ControlsEx.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace chkam05.Tools.ControlsEx.Example
{
    public partial class App : Application
    {

        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> App class constructor. </summary>
        public App() : base()
        {
            //
        }

        #endregion CONSTRUCTORS

        #region APPLICATION

        //  --------------------------------------------------------------------------------
        /// <summary> Main application method. </summary>
        [System.STAThreadAttribute()]
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public static void Main()
        {
            App app = new App();
            app.Run();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Application startup method invoked during startup. </summary>
        /// <param name="e"> Startup event arguments. </param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow = new MainWindow(e.Args);
            MainWindow.Show();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Application exit method invoked during closing. </summary>
        /// <param name="e"> Exit event arguments. </param>
        protected override void OnExit(ExitEventArgs e)
        {
            //
        }

        #endregion APPLICATION

    }
}
