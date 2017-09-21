using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Accordion;
using HzmApp.iOS.Renderer;
using Xamarin.Forms.Platform.iOS;
using System.ComponentModel;
using Accordion.Control;

[assembly: ExportRenderer(typeof(AccordionScrollView), typeof(AccordionScrollViewRenderer))]
namespace HzmApp.iOS.Renderer
{
    public class AccordionScrollViewRenderer : ScrollViewRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                e.OldElement.PropertyChanged -= OnElementPropertyChanged;
            }
            if (e.NewElement != null)
            {
                e.NewElement.PropertyChanged += OnElementPropertyChanged;
            }

        }

        private void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var element = sender as AccordionScrollView;

            if (element == null)
            {
                return;
            }

            if (e.PropertyName == nameof(element.ItemsSource))
            {
                element.Render();
            }
        }
    }
}