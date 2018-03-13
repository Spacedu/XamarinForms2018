using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1_Cell.Modelo;

namespace App1_Cell.Pagina
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ImageCellPage : ContentPage
	{
		public ImageCellPage ()
		{
			InitializeComponent ();

            List<Funcionario> Lista = new List<Funcionario>();
            Lista.Add(new Funcionario() { Foto = "https://media.licdn.com/mpr/mpr/shrinknp_200_200/AAEAAQAAAAAAAAiMAAAAJGU3YmMyOTViLWJjMTUtNDlmZi1hZDc0LWIyMWFiYWMwMTE4NQ.jpg", Nome = "José", Cargo = "Presidente da Empresa" });
            Lista.Add(new Funcionario() { Foto = "https://media-exp2.licdn.com/mpr/mpr/shrinknp_200_200/p/1/000/0ed/3b4/2b2c84c.jpg", Nome = "Maria", Cargo = "Gerente de Vendas" });
            Lista.Add(new Funcionario() { Foto = "https://media.licdn.com/mpr/mpr/shrinknp_200_200/p/2/005/013/1bf/3db66d9.jpg", Nome = "Elaine", Cargo = "Gerente de Marketing" });
            Lista.Add(new Funcionario() { Foto = "https://media-exp1.licdn.com/mpr/mpr/shrinknp_200_200/p/3/000/1ca/226/0c47ec4.jpg", Nome = "Felipe", Cargo = "Entregador" });
            Lista.Add(new Funcionario() { Foto = "https://media.licdn.com/mpr/mpr/shrinknp_400_400/p/8/005/060/2ed/077ce5c.jpg", Nome = "João", Cargo = "Vendedor" });

            ListaFuncionario.ItemsSource = Lista;
        }
	}
}