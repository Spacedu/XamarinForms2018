using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using App1_NossoChat.Model;
using App1_NossoChat.Util;
using App1_NossoChat.Service;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace App1_NossoChat.ViewModel
{
    public class MensagemViewModel : INotifyPropertyChanged
    {
        private bool _carregando;
        private Chat chat;
        private List<Mensagem> _mensagens;
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
        public bool Carregando
        {
            get { return _carregando; }
            set
            {
                _carregando = value;
                OnPropertyChanged("Carregando");
            }
        }

        public List<Mensagem> Mensagens
        {
            get { return _mensagens; }
            set
            {
                _mensagens = value;
                OnPropertyChanged("Mensagens");
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

        public MensagemViewModel(Chat chat)
        {
            this.chat = chat;
            Task.Run(()=>Atualizar());
            BtnEnviarCommand = new Command(BtnEnviar);
            AtualizarCommand = new Command(AtualizarSemAsync);

            Device.StartTimer(TimeSpan.FromSeconds(1), () => {
                Task.Run(()=>AtualizarSemTelaCarregando());
                return true;
            });
        }
        private void AtualizarSemAsync()
        {
            Task.Run(() => Atualizar());
        }
        private async Task Atualizar()
        {
            try {
                MensagemErro = false;
                Carregando = true;
                Mensagens = await ServiceWS.GetMensagensChat(chat);
                Carregando = false;
            }catch(Exception e)
            {
                Carregando = false;
                MensagemErro = true;
            }
        }


        private async Task AtualizarSemTelaCarregando()
        {
            Mensagens = await ServiceWS.GetMensagensChat(chat);
        }

        private void BtnEnviar()
        {
            var msg = new Mensagem() {
                id_usuario = UsuarioUtil.GetUsuarioLogado().id,
                mensagem = TxtMensagem,
                id_chat = chat.id
            };
            ServiceWS.InsertMensagem(msg);
            Task.Run(() => Atualizar());
            TxtMensagem = string.Empty;
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
