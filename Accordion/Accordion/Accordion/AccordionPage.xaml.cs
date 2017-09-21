using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Accordion
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AccordionPage : ContentPage
	{
		public AccordionPage ()
		{
            try
            {
                InitializeComponent();
            }
            catch (Exception exe)
            {

                throw;
            }
		}
	}
}
