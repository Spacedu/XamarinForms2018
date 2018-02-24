using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App01_ControleXF.Controles
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DatePickerPage : ContentPage
	{
		public DatePickerPage ()
		{
			InitializeComponent ();
		}

        private void ActionDateSelected(object sender, DateChangedEventArgs args)
        {
            LblResultado.Text = args.OldDate.ToString("dd/MM/yyyy") + " > " +args.NewDate.ToString("dd/MM/yyyy");
        }

    }
}