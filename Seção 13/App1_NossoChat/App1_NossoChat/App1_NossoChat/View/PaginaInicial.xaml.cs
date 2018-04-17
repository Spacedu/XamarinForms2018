using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_NossoChat.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PaginaInicial : ContentPage
	{
		public PaginaInicial ()
		{
			InitializeComponent ();

            BindingContext = new ViewModel.PaginaInicialViewModel();
		}
	}
}