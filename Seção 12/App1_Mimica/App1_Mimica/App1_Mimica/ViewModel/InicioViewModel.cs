using System;
using System.Collections.Generic;
using System.Text;
using App1_Mimica.Model;
using System.ComponentModel;
using Xamarin.Forms;

namespace App1_Mimica.ViewModel
{
    public class InicioViewModel : INotifyPropertyChanged
    {
        public Jogo Jogo { get; set; }
        public Command IniciarCommand { get; set; }
        private string _MsgErro;
        public string MsgErro { get { return _MsgErro; } set { _MsgErro = value; OnPropertyChanged("MsgErro"); } }

        public InicioViewModel()
        {
            IniciarCommand = new Command(IniciarJogo);
            Jogo = new Jogo();
            Jogo.Grupo1 = new Grupo();
            Jogo.Grupo2 = new Grupo();

            Jogo.TempoPalavra = 120;
            Jogo.Rodadas = 7;
        }
        
        private void IniciarJogo()
        {
            string error = "";
            if (Jogo.TempoPalavra < 10)
            {
                error += "O tempo mínimo para o Tempo da palavra é 10 segundos.";
            }
            if(Jogo.Rodadas <= 0)
            {
                error += "\nO valor mínimo para a rodada é 1.";
            }

            if(error.Length > 0)
            {
                MsgErro = error;
            }

            else {
                Armazenamento.Armazenamento.Jogo = this.Jogo;
                Armazenamento.Armazenamento.RodadaAtual = 1;

                App.Current.MainPage = new View.Jogo(Jogo.Grupo1);
            }            
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string NameProperty)
        {
            if (PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(NameProperty));
            }
        }
    }
}
