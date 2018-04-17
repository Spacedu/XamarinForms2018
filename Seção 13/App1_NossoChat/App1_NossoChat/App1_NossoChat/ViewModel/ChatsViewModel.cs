using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel;
using App1_NossoChat.Model;
using App1_NossoChat.Service;
using Xamarin.Forms;

namespace App1_NossoChat.ViewModel
{
    public class ChatsViewModel : INotifyPropertyChanged
    {
        private Chat _selectedItemChat;
        public Chat SelectedItemChat
        {
            get { return _selectedItemChat; }
            set
            {
                _selectedItemChat = value;
                OnPropertyChanged("SelectedItemChat");

                GoPaginaMensagem(value);
                
                
            }
        }

        private void GoPaginaMensagem(Chat chat)
        {
            if(chat != null)
            {
                SelectedItemChat = null;
                ((NavigationPage)App.Current.MainPage).Navigation.PushAsync(new View.Mensagem(chat));   
            }
            
        }



        private List<Chat> _chats;
        public List<Chat> Chats {
            get { return _chats; }
            set {
                _chats = value;
                OnPropertyChanged("Chats");
            }
        }

        public Command AdicionarCommand { get; set; }
        public Command OrdenarCommand { get; set; }
        public Command AtualizarCommand { get; set; }

        public ChatsViewModel()
        {
            Chats = ServiceWS.GetChats();

            AdicionarCommand = new Command(Adicionar);
            OrdenarCommand = new Command(Ordernar);
            AtualizarCommand = new Command(Atualizar);
        }

        private void Adicionar()
        {
            ((NavigationPage)App.Current.MainPage).Navigation.PushAsync(new View.CadastrarChat());
        }
        private void Ordernar()
        {
            Chats = Chats.OrderBy(a => a.nome).ToList();
        }
        private void Atualizar()
        {
            Chats = ServiceWS.GetChats();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }

    }
}
