using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App2_SOAPClient
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        public void EnviarSOAP(object sender, EventArgs args)
        {
            var Num1T = int.Parse( Num1.Text );
            var Num2T = int.Parse( Num2.Text );

            TxtResultado.Text = DependencyService.Get<IServiceSOAP>().Somar(Num1T, Num2T);

        }

    }
}
