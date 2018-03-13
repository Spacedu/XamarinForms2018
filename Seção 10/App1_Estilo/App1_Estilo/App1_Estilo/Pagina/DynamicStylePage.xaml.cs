using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_Estilo.Pagina
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DynamicStylePage : ContentPage
	{
		public DynamicStylePage ()
		{
			InitializeComponent ();
		}

        private void MudarCor(object sender, EventArgs args) {
            this.Resources["LblColor"] = Color.Orange;
            this.Resources["Lbl"] = this.Resources["NewLbl"];
        }

    }
}