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
	public partial class Chats : ContentPage
	{
		public Chats ()
		{
			InitializeComponent ();

            BindingContext = new ViewModel.ChatsViewModel();
		}
	}
}