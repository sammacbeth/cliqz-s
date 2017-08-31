using ReactNative;
using ReactNative.Modules.Core;
using ReactNative.Shell;
using RNSqlite2;
using System.Collections.Generic;

namespace CliqzS
{
    class MainPage : ReactPage
    {
        public override string MainComponentName
        {
            get
            {
                return "CliqzS";
            }
        }

#if BUNDLE
        public override string JavaScriptBundleFile
        {
            get
            {
                return "ms-appx:///ReactAssets/index.windows.bundle";
            }
        }
#endif

        public override List<IReactPackage> Packages
        {
            get
            {
                return new List<IReactPackage>
                {
                    new MainReactPackage(),
                    new RNSqlite2Package(),
                    new CliqzPackage()
                };
            }
        }

        public override bool UseDeveloperSupport
        {
            get
            {
#if !BUNDLE || DEBUG
                return true;
#else
                return false;
#endif
            }
        }
    }

}
