using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Accordion.Control;
using Accordion.Droid.Renderer;
using Xamarin.Forms;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(AccordionScrollView), typeof(AccordionScrollViewRenderer))]
namespace Accordion.Droid.Renderer
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