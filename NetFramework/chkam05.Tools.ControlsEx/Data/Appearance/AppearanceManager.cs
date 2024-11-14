using chkam05.Tools.ControlsEx.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chkam05.Tools.ControlsEx.Data.Appearance
{
    public class AppearanceManager
    {

        //  VARIABLES

        private AppearanceManager instance;
        private object instanceLock = new object();


        //  GETTERS & SETTERS

        public AppearanceManager Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new AppearanceManager();

                    return instance;
                }
            }
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> AppearanceManager private class constructor. </summary>
        private AppearanceManager()
        {
            //
        }

        #endregion CONSTRUCTORS

    }
}
