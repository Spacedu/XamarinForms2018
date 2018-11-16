using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using App1_NossoChat.Model;
using App1_NossoChat.Service;
using Newtonsoft.Json;
using App1_NossoChat.Util;
namespace App1_NossoChat.ViewModel
{
    public class PaginaInicialViewModel : INotifyPropertyChanged
    {
        private bool _carregando;
        private bool _mensagemErro;
        
        private string _nome;
        private string _senha;
        private string _mensagem;

        public bool Carregando
        {
            get { return _carregando; }
            set
            {
                _carregando = value;
                OnPropertyChanged("Carregando");
            }
        }
        public bool MensagemErro
        {
            get { return _mensagemErro; }
            set
            {
                _mensagemErro = value;
                OnPropertyChanged("MensagemErro");
            }
        }
        
        public string Nome {
            get { return _nome; }
            set {
                _nome = value;
                OnPropertyChanged("Nome");
            }
        }
        public string Senha
        {
            get { return _senha; }
            set
            {
                _senha = value;
                OnPropertyChanged("Senha");
            }
        }
        public string Mensagem
        {
            get { return _mensagem; }
            set
            {
                _mensagem = value;
                OnPropertyChanged("Mensagem");
            }
        }

        public Command AcessarCommand { get; set; }

        public PaginaInicialViewModel()
        {
            AcessarCommand = new Command(Acessar);
        }

        private async void Acessar()
        {
            try {
                MensagemErro = false;
                Carregando = true;
                var user = new Usuario();
                user.nome = Nome;
                user.password = Senha;

                var usuarioLogado = await ServiceWS.GetUsuario(user);
                if (usuarioLogado == null)
                {
                    Mensagem = "Senha incorreta.";
                    Carregando = false;
                }
                else
                {
                    UsuarioUtil.SetUsuarioLogado(usuarioLogado);
                    App.Current.MainPage = new NavigationPage(new View.Chats()) { BarBackgroundColor = Color.FromHex("#5ED055"), BarTextColor = Color.White };
                }
            } catch (Exception e) {
                MensagemErro = true;
            } finally {
                Carregando = false;
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }

    }
}
