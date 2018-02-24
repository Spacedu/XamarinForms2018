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
	public partial class ImagePage : ContentPage
	{
		public ImagePage ()
		{
			InitializeComponent ();
            //ImageOne.IsLoading

            Image imgUSB = new Image();
            if(Device.RuntimePlatform == Device.UWP)
            {
                imgUSB.Source = ImageSource.FromFile("Imagem/usb.jpg");
            }
            else
            {
                imgUSB.Source = ImageSource.FromFile("usb.jpg");
            }

            Container.Children.Add(imgUSB);
        }
	}
}