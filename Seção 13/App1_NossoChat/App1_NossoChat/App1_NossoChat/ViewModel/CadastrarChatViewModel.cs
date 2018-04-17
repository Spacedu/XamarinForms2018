using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using App1_NossoChat.Model;
using App1_NossoChat.Service;
using System.ComponentModel;

namespace App1_NossoChat.ViewModel
{
    public class CadastrarChatViewModel : INotifyPropertyChanged
    {
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
            CadastrarCommand = new Command(Cadastrar);
        }

        private void Cadastrar()
        {
            var chat = new Chat() { nome = nome };
            bool ok = ServiceWS.InsertChat(chat);
            if (ok == true)
            {
                ((NavigationPage)App.Current.MainPage).Navigation.PopAsync();

                var Nav = (NavigationPage)App.Current.MainPage;
                var Chats = (View.Chats) Nav.CurrentPage;
                var ViewModel = (ChatsViewModel)Chats.BindingContext;
                if( ViewModel.AtualizarCommand.CanExecute(null))
                {
                    ViewModel.AtualizarCommand.Execute(null);
                }
            }
            else
            {
                mensagem = "Ocorreu um erro no cadastro!";
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
