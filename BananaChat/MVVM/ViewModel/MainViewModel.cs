using BananaChat.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BananaChat.Core;

namespace BananaChat.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public ObservableCollection<MessageModel> Messages { get; set; }
        public ObservableCollection<ContactModel> Contacts { get; set; }

        /* Commands */
        public RelayCommand SendCommand { get; set; }

        private ContactModel _selectedContact;

        public ContactModel SelectedContact
        {
            get { return _selectedContact; }
            set
            {
                _selectedContact = value;
                OnPropertyChanged();
            }
        }


        private string _message;

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel()
        {
            Messages = new ObservableCollection<MessageModel>();
            Contacts = new ObservableCollection<ContactModel>();

            SendCommand = new RelayCommand(o =>
            {
                Messages.Add(new MessageModel()
                {
                    Message = Message,
                    FirstMessage = false
                });
                Message = "";
            });

            Messages.Add(new MessageModel
            {
                UserName = "WildBanana",
                UserNameColor = "#409AFF",
                ImageSource = "https://i.kym-cdn.com/entries/icons/facebook/000/003/117/banana.jpg",
                Message = "Hello World",
                Time = DateTime.Now,
                IsNativeOrigin = false,
                FirstMessage = true

            });

            for (int i = 0; i < 3; i++)
            {
                Messages.Add(new MessageModel
                {
                    UserName = "WildBanana",
                    UserNameColor = "#409AFF",
                    ImageSource = "",
                    Message = "Test",
                    Time = DateTime.Now,
                    IsNativeOrigin = false,
                    FirstMessage = false

                });
            }

            Messages.Add(new MessageModel
            {
                UserName = "SmeatMan",
                UserNameColor = "#409AFF",
                ImageSource = "https://i.imgur.com/i2szTsp.png",
                Message = "Last",
                Time = DateTime.Now,
                IsNativeOrigin = true
            });

            for (int i = 0; i < 5; i++)
            {
                Contacts.Add(new ContactModel
                {
                    UserName = $"WildBanana {i}",
                    ImageSource = "https://i.kym-cdn.com/entries/icons/facebook/000/003/117/banana.jpg",
                    Messages = Messages
                });
            }
        }
    }
}
