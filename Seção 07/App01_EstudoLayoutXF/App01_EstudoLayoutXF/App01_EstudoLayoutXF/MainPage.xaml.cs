using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App01_EstudoLayoutXF
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}
        private void GoPaginaStack(object sender, EventArgs args)
        {
            Navigation.PushAsync(new TipoLayout.Stack.StackPage());
        }

        private void GoPaginaGrid(object sender, EventArgs args)
        {
            Navigation.PushAsync(new TipoLayout.Grid.GridPage());
        }

        private void GoPaginaRelative(object sender, EventArgs args)
        {
            Navigation.PushAsync(new TipoLayout.Relative.RelativePage());
        }

        private void GoPaginaAbsolute(object sender, EventArgs args)
        {
            Navigation.PushAsync(new TipoLayout.Absolute.AbsolutePage());
        }
        private void GoPaginaScroll(object sender, EventArgs args)
        {
            Navigation.PushAsync(new TipoLayout.Scroll.ScrollPage());
        }
    }
}
