//*********************************************************
//
// Copyright (c) Microsoft. All rights reserved.
// This code is licensed under the MIT License (MIT).
// THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
// IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
// PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//*********************************************************

using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Data.Pdf;
using Windows.Foundation;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace RNPDFvnext
{
    internal sealed partial class PDF_Render : Page
    {
        private PdfDocument pdfDocument;

        public PDF_Render()
        {
            this.InitializeComponent();
        }

        public async void LoadDocument(String path)
        {
            pdfDocument = null;

            //RenderingPanel.Visibility = Visibility.Collapsed;

            StorageFile file = null;
            try
            {
                file = await StorageFile.GetFileFromPathAsync(path);
            }
            catch (Exception)
            {
                try
                {
                    file = await StorageFile.GetFileFromApplicationUriAsync(new Uri(path));
                }
                catch (Exception e)
                {
                    // ?
                }

            }
            if (file != null)
            {
                try
                {
                    pdfDocument = await PdfDocument.LoadFromFileAsync(file);
                }
                catch (Exception ex)
                {
                }

                if (pdfDocument != null)
                {
                    if (pdfDocument.IsPasswordProtected)
                    {

                    }
                    else
                    {
                        Load(pdfDocument);
                    }
                }
            }
        }

        async void Load(PdfDocument pdfDoc)
        {
            PdfPages.Clear();

            for (uint i = 0; i < pdfDoc.PageCount; i++)
            {
                BitmapImage image = new BitmapImage();

                var page = pdfDoc.GetPage(i);

                using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
                {
                    await page.RenderToStreamAsync(stream);
                    await image.SetSourceAsync(stream);
                }

                PdfPages.Add(image);
            }
        }


        public ObservableCollection<BitmapImage> PdfPages
        {
            get;
            set;
        } = new ObservableCollection<BitmapImage>();
    }
}