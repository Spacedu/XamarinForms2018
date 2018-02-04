using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Servico;
using App01_ConsultarCEP.Servico.Modelo;

namespace App01_ConsultarCEP
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            Botao.Clicked += BuscarCEP;
		}

        private void BuscarCEP(object sender, EventArgs args)
        {
            
            string cep = CEP.Text.Trim();

            if (isValidoCEP(cep)) {
                try
                {
                    Endereco end = ViaCEP.BuscarEnderecoViaCEP(cep);

                    if(end == null)
                    {
                        DisplayAlert("ERRO", "Endereço não existe para o CEP informado: " + cep, "OK");
                    }
                    else {
                        Resultado.Text =
                            string.Format("CEP: {0}, Endereço: {1}, Bairro: {2}, Cidade: {3}, Estado: {4}",
                                end.cep, end.logradouro, end.bairro, end.localidade, end.uf
                            );
                    }
                }
                catch(Exception e)
                {
                    DisplayAlert("ERRO CRÍTICO", e.Message, "OK");
                }
            }
        }

        private bool isValidoCEP(string cep)
        {
            bool valido = true;
            if( cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP é inválido, favor digitar apenas 8 caracteres", "OK");
                valido = false;
            }

            int NovoCEP = 0;
            if( !int.TryParse(cep, out NovoCEP) )
            {
                DisplayAlert("ERRO", "CEP inválido, favor digitar apenas os números", "OK");
                valido = false;
            }

            return valido;
        }
	}
}
