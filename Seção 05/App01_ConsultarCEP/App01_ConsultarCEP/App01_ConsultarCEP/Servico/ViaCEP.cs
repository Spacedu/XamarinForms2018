using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net;

using App01_ConsultarCEP.Servico.Modelo;

namespace App01_ConsultarCEP.Servico
{
    public class ViaCEP
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string NovaURL = string.Format(EnderecoURL, cep);

            //TODO - Verificar se o conteúdo foi retornado.
            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(NovaURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);

            if(end.cep == null)
            {
                return null;
            }
            return end;
        }
    }
}
