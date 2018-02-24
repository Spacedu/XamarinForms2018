using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App01_ControleXF.Menu
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Master : MasterDetailPage
	{
		public Master ()
		{
			InitializeComponent ();
		}
        private void GoActivityIndicatorPage(object sender, EventArgs args)
        {
            Detail = new Controles.ActivityIndicatorPage();
        }
        private void GoProgressBarPage(object sender, EventArgs args)
        {
            Detail = new Controles.ProgressBarPage();
        }
        private void GoBoxViewPage(object sender, EventArgs args)
        {
            Detail = new Controles.BoxViewPage();
        }
        private void GoLabelPage(object sender, EventArgs args)
        {
            Detail = new Controles.LabelPage();
        }
        private void GoButtonPage(object sender, EventArgs args)
        {
            Detail = new Controles.ButtonPage();
        }
        private void GoEntryEditorPage(object sender, EventArgs args)
        {
            Detail = new Controles.EntryEditorPage();
        }
        private void GoDatePickerPage(object sender, EventArgs args)
        {
            Detail = new Controles.DatePickerPage();
        }
        private void GoTimePickerPage(object sender, EventArgs args)
        {
            Detail = new Controles.TimePickerPage();
        }
        private void GoPickerPage(object sender, EventArgs args)
        {
            Detail = new Controles.PickerPage();
        }
        private void GoSearchBarPage(object sender, EventArgs args)
        {
            Detail = new Controles.SearchBarPage();
        }
        private void GoSliderStepperBarPage(object sender, EventArgs args)
        {
            Detail = new Controles.SliderStepperPage();
        }
        private void GoSwitchPage(object sender, EventArgs args)
        {
            Detail = new Controles.SwitchPage();
        }
        private void GoImagePage(object sender, EventArgs args)
        {
            Detail = new Controles.ImagePage();
        }
        private void GoListViewPage(object sender, EventArgs args)
        {
            Detail = new Controles.ListViewPage();
        }
        private void GoTableViewPage(object sender, EventArgs args)
        {
            Detail = new Controles.TableViewPage();
        }
        private void GoWebViewPage(object sender, EventArgs args)
        {
            Detail = new Controles.WebViewPage();
        }

    }
}