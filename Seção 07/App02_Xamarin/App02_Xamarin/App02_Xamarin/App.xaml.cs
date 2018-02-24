using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App02_Xamarin
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			MainPage = new App02_Xamarin.Master.Menu();
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
