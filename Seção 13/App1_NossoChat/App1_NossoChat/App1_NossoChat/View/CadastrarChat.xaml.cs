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
	public partial class CadastrarChat : ContentPage
	{
		public CadastrarChat ()
		{
			InitializeComponent ();

            BindingContext = new ViewModel.CadastrarChatViewModel();
		}
	}
}