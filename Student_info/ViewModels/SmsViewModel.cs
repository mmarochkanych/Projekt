using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Student_info.ViewModels
{
    public class SmsViewModel : BaseViewModel
    {
        string recipent = string.Empty;
        public string Recipent
        {
            get { return recipent; }
            set { SetProperty(ref recipent, value); }
        }

        string message = string.Empty;
        public string Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }


        public SmsViewModel()
        {

        }

        public ICommand SendCommand => new Command(SendSms);

        public async void SendSms()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                if (string.IsNullOrEmpty(Recipent))
                {

                    await UserDialogs.Instance.AlertAsync("Podaj odbiorce");
                    return;
                }

                if (string.IsNullOrEmpty(Message))
                {

                    await UserDialogs.Instance.AlertAsync("Podaj treść wiadomości");
                    return;
                }

                var smsMessage = new SmsMessage(Message, new[] { Recipent });
                await Sms.ComposeAsync(smsMessage);
                Recipent = string.Empty;
                Message = string.Empty;
                UserDialogs.Instance.Toast("Wiadomośc wysłana", TimeSpan.FromSeconds(5));
            }
            catch (FeatureNotSupportedException ex)
            {
                await UserDialogs.Instance.AlertAsync("Sms is not supported on this device");
            }
            catch (Exception ex)
            {
                await UserDialogs.Instance.AlertAsync("Wystąpił bład");
            }
            finally
            {
                IsBusy = false;
            }
        }


    }
}

