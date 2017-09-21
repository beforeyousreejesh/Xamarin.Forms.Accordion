using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Linq;

namespace Accordion.Control
{
    public class AccordionScrollView : ScrollView
    {
        private List<HeaderViewCell> _headercells = new List<HeaderViewCell>();

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create("ItemsSource", typeof(IEnumerable), typeof(AccordionScrollView), default(IEnumerable));


        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly BindableProperty ItemTemplateProperty =
                        BindableProperty.Create("ItemTemplate", typeof(DataTemplate), typeof(AccordionScrollView), default(DataTemplate));

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        public static readonly BindableProperty HeaderTemplateProperty =
                BindableProperty.Create("HeaderTemplate", typeof(DataTemplate), typeof(AccordionScrollView), default(DataTemplate));

        public DataTemplate HeaderTemplate
        {
            get { return (DataTemplate)GetValue(HeaderTemplateProperty); }
            set { SetValue(HeaderTemplateProperty, value); }
        }

        public static readonly BindableProperty HeaderSpacingProperty =
                   BindableProperty.Create("HeaderSpacing", typeof(double), typeof(AccordionScrollView), 6.0);

        public double HeaderSpacing
        {
            get { return (double)GetValue(HeaderSpacingProperty); }
            set { SetValue(HeaderSpacingProperty, value); }
        }

        public static readonly BindableProperty ItemSpacingProperty =
                   BindableProperty.Create("ItemSpacing", typeof(double), typeof(AccordionScrollView), 6.0);

        public double ItemSpacing
        {
            get { return (double)GetValue(ItemSpacingProperty); }
            set { SetValue(ItemSpacingProperty, value); }
        }
        public void Render()
        {
            if (this.ItemTemplate == null || this.ItemsSource == null || HeaderTemplate == null)
                return;

            var coll = this.ItemsSource as ICollection;

            if (coll?.Count <= 0)
            {
                return;
            }

            var mainLayout = new StackLayout { Spacing = HeaderSpacing, Orientation = StackOrientation.Vertical, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };

            foreach (var source in this.ItemsSource)
            {
                var stackLayout = new StackLayout { Orientation = StackOrientation.Vertical, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };

                var viewCellHeader = HeaderTemplate.CreateContent() as ViewCell;

                if (viewCellHeader != null)
                {
                    viewCellHeader.View.BindingContext = source;
                    stackLayout.Children.Add(viewCellHeader.View);
                }


                if (source != null)
                {
                    var childitems = new StackLayout() { Spacing = ItemSpacing, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };


                    foreach (var item in (IEnumerable)source)
                    {
                        var itemsStackLayout = new StackLayout() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };

                        var viewCellItem = ItemTemplate.CreateContent() as Accordion;

                        var headercell = viewCellItem.HeaderTemplate.CreateContent() as HeaderViewCell;

                        if (headercell != null)
                        {
                            headercell.View.BindingContext = item;
                            itemsStackLayout.Children.Add(headercell.View);

                            var acrrodionSection = viewCellItem.ItemTemplate.CreateContent() as AccordionSection;

                            if (acrrodionSection != null)
                            {
                                acrrodionSection.BindingContext = item;
                                headercell.UpdateExpandCommand(acrrodionSection, ExpandCallBack);
                                acrrodionSection.IsVisible = false;
                                itemsStackLayout.Children.Add(acrrodionSection);
                                _headercells.Add(headercell);
                            }
                        }

                        childitems.Children.Add(itemsStackLayout);
                    }

                    stackLayout.Children.Add(childitems);
                }

                mainLayout.Children.Add(stackLayout);
            }

            Content = mainLayout;
        }

        private void ExpandCallBack()
        {
            foreach (var headerItem in _headercells)
            {
                if (headerItem.Section != null)
                {
                    headerItem.Section.IsVisible = false;
                }
            }
        }
    }
}
