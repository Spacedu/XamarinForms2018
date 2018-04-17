using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using App1_NossoChat.Model;
using App1_NossoChat.Util;
using App1_NossoChat.Service;
using Xamarin.Forms;

namespace App1_NossoChat.ViewModel
{
    public class MensagemViewModel : INotifyPropertyChanged
    {
        private StackLayout SL;
        private Chat chat;
        private List<Mensagem> _mensagens;
        public List<Mensagem> Mensagens
        {
            get { return _mensagens; }
            set
            {
                _mensagens = value;
                OnPropertyChanged("Mensagens");
                if(value != null) { 
                    ShowOnScreen();
                }
            }
        }

        private string _txtMensagem;
        public string TxtMensagem
        {
            get { return _txtMensagem; }
            set
            {
                _txtMensagem = value;
                OnPropertyChanged("TxtMensagem");
            }
        }

        public Command BtnEnviarCommand { get; set; }
        public Command AtualizarCommand { get; set; }

        public MensagemViewModel(Chat chat, StackLayout SLMensagemContainer)
        {
            this.chat = chat;
            SL = SLMensagemContainer;
            Atualizar();
            BtnEnviarCommand = new Command(BtnEnviar);
            AtualizarCommand = new Command(Atualizar);

            Device.StartTimer(TimeSpan.FromSeconds(1), () => {
                Atualizar();
                return true;
            });
        }
        private void Atualizar()
        {
            Mensagens = ServiceWS.GetMensagensChat(chat);
        }
        private void BtnEnviar()
        {
            var msg = new Mensagem() {
                id_usuario = UsuarioUtil.GetUsuarioLogado().id,
                mensagem = TxtMensagem,
                id_chat = chat.id
            };
            ServiceWS.InsertMensagem(msg);
            Atualizar();
            TxtMensagem = string.Empty;
        }

        private void ShowOnScreen()
        {
            var usuario = UsuarioUtil.GetUsuarioLogado();
            SL.Children.Clear();
            foreach (var msg in Mensagens)
            {
                if(msg.usuario.id == usuario.id)
                {
                    SL.Children.Add(CriarMensagemPropria(msg));
                }
                else
                {
                    SL.Children.Add(CriarMensagemOutrosUsuarios(msg));
                }                
            }
        }

        
                    

        private Xamarin.Forms.View CriarMensagemPropria(Mensagem mensagem)
        {
            var layout = new StackLayout() { Padding = 5, BackgroundColor = Color.FromHex("#5ED055"), HorizontalOptions = LayoutOptions.End };
            var label = new Label() { TextColor = Color.White, Text = mensagem.mensagem };

            layout.Children.Add(label);
            return layout;
        }
        private Xamarin.Forms.View CriarMensagemOutrosUsuarios(Mensagem mensagem)
        {
            var labelNome = new Label() { Text = mensagem.usuario.nome, FontSize = 10, TextColor = Color.FromHex("#5ED055") } ;
            var labelMensagem = new Label() { Text = mensagem.mensagem, TextColor = Color.FromHex("#5ED055") };

            var SL = new StackLayout();
            SL.Children.Add(labelNome);
            SL.Children.Add(labelMensagem);
            var frame = new Frame() { OutlineColor = Color.FromHex("#5ED055"), CornerRadius = 0, HorizontalOptions = LayoutOptions.Start };
            frame.Content = SL;

            return frame;
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
