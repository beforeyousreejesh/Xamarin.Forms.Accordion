using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Accordion.Control
{
    public class HeaderViewCell : ViewCell
    {
        public AccordionSection Section { get; set; }

        private Action _expandCallBack;

        public void UpdateExpandCommand(AccordionSection child, Action expandCallBack)
        {
            Section = child;
            Section.FadeTo(0, 300, Easing.SpringOut);

            _expandCallBack = expandCallBack;

            if (View != null)
            {
                var tapExpandGesture = new TapGestureRecognizer();
                tapExpandGesture.Command = new Command(Expand);
                View.GestureRecognizers.Add(tapExpandGesture);
            }
        }

        private async void Expand(object obj)
        {
            if (Section != null)
            {
                if (!Section.IsVisible)
                {
                    _expandCallBack?.Invoke();

                    Section.IsVisible = true;
                    await Section.FadeTo(1, 300, Easing.SpringIn);
                }
                else
                {
                    await Section.FadeTo(0, 300, Easing.SpringOut);
                    Section.IsVisible = false;
                }
            }
        }
    }
}
