using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Accordion.Control
{
    public class Accordion : StackLayout
    {
        public static readonly BindableProperty ItemsSourceProperty =
                    BindableProperty.Create("ItemsSource", typeof(IEnumerable), typeof(Accordion), default(IEnumerable));


        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly BindableProperty ItemTemplateProperty =
                        BindableProperty.Create("ItemTemplate", typeof(DataTemplate), typeof(Accordion), default(DataTemplate));

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        public static readonly BindableProperty HeaderTemplateProperty =
                BindableProperty.Create("HeaderTemplate", typeof(DataTemplate), typeof(Accordion), default(DataTemplate));

        public DataTemplate HeaderTemplate
        {
            get { return (DataTemplate)GetValue(HeaderTemplateProperty); }
            set { SetValue(HeaderTemplateProperty, value); }
        }
    }
}
