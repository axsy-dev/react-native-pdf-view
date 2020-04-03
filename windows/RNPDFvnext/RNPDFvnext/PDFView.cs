using System;
using Microsoft.ReactNative.Managed;
using Windows.UI.Xaml.Controls;



namespace RNPDFvnext
{ 

    internal class PDFViewManager : AttributedViewManager<PDF_Render>
    {

        [ViewManagerProperty("src")]
        public void SetSource(PDF_Render view, String src)
        {
            view.LoadDocument(src);
        }

        [ViewManagerProperty("path")]
        public void SetPath(Page view, String path)
        {
        }

        [ViewManagerProperty("pageNumber")]
        public void SetPageNumber(Page view, int pageNumber)
        {
        }

        [ViewManagerProperty("zoom")]
        public void SetPath(Page view, float zoom)
        {
        }
    }
}
