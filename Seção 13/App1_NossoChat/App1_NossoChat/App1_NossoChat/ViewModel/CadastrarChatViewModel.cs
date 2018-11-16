using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using App1_NossoChat.Model;
using App1_NossoChat.Service;
using System.ComponentModel;
using System.Threading.Tasks;

namespace App1_NossoChat.ViewModel
{
    public class CadastrarChatViewModel : INotifyPropertyChanged
    {
        private bool _carregando;
        public bool Carregando
        {
            get { return _carregando; }
            set
            {
                _carregando = value;
                OnPropertyChanged("Carregando");
            }
        }

        private bool _mensagemErro;
        public bool MensagemErro
        {
            get { return _mensagemErro; }
            set
            {
                _mensagemErro = value;
                OnPropertyChanged("MensagemErro");
            }
        }

        public string nome { get; set; }
        private string _mensagem { get; set; }
        public string mensagem {
            get { return _mensagem; }
            set {
                _mensagem = value;
                OnPropertyChanged("mensagem");
            }
        }

        public Command CadastrarCommand { get; set; }

        public CadastrarChatViewModel()
        {
            CadastrarCommand = new Command(CadastrarButton);
        }
        private void CadastrarButton()
        {
            bool Resultado = Task.Run(()=>Cadastrar()).GetAwaiter().GetResult();

            if( Resultado == true)
            {
                var PaginaAtual = ((NavigationPage)App.Current.MainPage);
                PaginaAtual.PopAsync();
            }
            
        }
        private async Task<bool> Cadastrar()
        {
            Carregando = true;
            MensagemErro = false;
            try
            {

                var chat = new Chat() { nome = nome };
                bool ok = await ServiceWS.InsertChat(chat);
                if (ok == true)
                {
                    var PaginaAtual = ((NavigationPage)App.Current.MainPage);

                    var Chats = (View.Chats)PaginaAtual.RootPage;
                    var ViewModel = (ChatsViewModel)Chats.BindingContext;
                    if (ViewModel.AtualizarCommand.CanExecute(null))
                    {
                        ViewModel.AtualizarCommand.Execute(null);
                    }

                    return true;
                }
                else
                {
                    mensagem = "Ocorreu um erro no cadastro!";
                    Carregando = false;
                    return false;
                }
            }catch(Exception e)
            {
                MensagemErro = true;
                mensagem = e.Message;
                Carregando = false;
                return false;
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
