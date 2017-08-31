using Newtonsoft.Json.Linq;
using ReactNative.Views.Web;
using ReactNative.UIManager;
using ReactNative.UIManager.Annotations;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Windows.Web;
using Windows.Web.Http;
using static System.FormattableString;
using Map = System.Collections.Generic.Dictionary<string, object>;


namespace CliqzS
{
    /// <summary>
    /// A view manager responsible for rendering webview.
    /// </summary>
    public class CliqzWebViewManager : ReactWebViewManager
    {
        /// <summary>
        /// The name of the view manager.
        /// </summary>
        public override string Name
        {
            get
            {
                return "CliqzWebView";
            }
        }

        public override IReadOnlyDictionary<string, object> ExportedCustomDirectEventTypeConstants
        {
            get
            {
                return new Map
                {
                    {
                        "newWindowRequested",
                        new Map
                        {
                            { "registrationName", "onNewWindowRequested" },
                        }
                    }
                };
            }
        }

        /// <summary>
        /// Subclasses can override this method to install custom event 
        /// emitters on the given view.
        /// </summary>
        /// <param name="reactContext">The React context.</param>
        /// <param name="view">The view instance.</param>
        protected override void AddEventEmitters(ThemedReactContext reactContext, WebView view)
        {
            base.AddEventEmitters(reactContext, view);
            view.NewWindowRequested += OnNewWindowRequested;
        }

        private void OnNewWindowRequested (WebView webView, WebViewNewWindowRequestedEventArgs e) 
        {
            webView.GetReactContext().GetNativeModule<UIManagerModule>()
                   .EventDispatcher
                   .DispatchEvent(
                        new WebViewNewWindowRequestedEvent(
                           webView.GetTag(),
                           e.Uri.AbsoluteUri,
                           e.Referrer.AbsoluteUri));
            e.Handled = true;
        }
    }
}
