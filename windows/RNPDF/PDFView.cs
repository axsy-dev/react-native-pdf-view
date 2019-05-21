using System;
using System.Collections.Generic;
using ReactNative.Bridge;
using ReactNative.Modules.Core;
using ReactNative.UIManager;
using ReactNative.UIManager.Annotations;
using Windows.Data.Pdf;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

// Extremely limited implementation of the react-native-fs native module for windows
// Needs completing with loads of other methods and constants

namespace ReactNative.Modules.PDFView
{

    public class PDFViewModule : ReactContextNativeModuleBase
    {
        public PDFViewModule(ReactContext reactContext) : base(reactContext)
        {

        }

        public override string Name
        {
            get
            {
                return "RNPDFView";
            }
        }

    }

   

    public class PDFViewPackage : IReactPackage
    {
        public IReadOnlyList<Type> CreateJavaScriptModulesConfig()
        {
            return new List<Type>(0);
        }

        public IReadOnlyList<INativeModule> CreateNativeModules(ReactContext reactContext)
        {
            return new List<INativeModule>(0);
        }

        public IReadOnlyList<UIManager.IViewManager> CreateViewManagers(ReactContext reactContext)
        {
            return new List<IViewManager>()
            {
                new PDFViewManager()
            };
        }

    }

    public class PDFViewManager : SimpleViewManager<Page>
    {
        PDF_Render renderer;

        public override string Name
        {
            get
            {
                return "RNPDFView";
            }
        }

        protected override Page CreateViewInstance(ThemedReactContext reactContext)
        {
                renderer = new PDF_Render();
                return renderer;
        }

        [ReactProp("source")]
        public void SetSource(Page view, String src)
        {
        
            renderer.LoadDocument(src);
        }

        [ReactProp("page")]
        public void SetPage(Page view, int pageNumber)
        {
        }

        [ReactProp("scale")]
        public void SetScale(Page view, double scale)
        {
        }

        [ReactProp("minScale")]
        public void SetMinScale(Page view, double minScale)
        {
        }

        [ReactProp("maxScale")]
        public void SetMaxScale(Page view, double maxScale)
        {
        }
    }
}
