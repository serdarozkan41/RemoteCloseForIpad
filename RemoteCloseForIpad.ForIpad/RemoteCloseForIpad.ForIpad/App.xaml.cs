using Sockets.Plugin;
using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RemoteCloseForIpad.ForIpad
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected async override void OnStart()
        {
            try
            {

          
            var address = "192.168.200.200";
            var port = 13000;
            var r = new Random();

            var client = new TcpSocketClient();
            await client.ConnectAsync(address, port);

            // we're connected!
            
                var msg = "Kapat";
                var msgBytes = Encoding.UTF8.GetBytes(msg);

                await client.WriteStream.WriteAsync(msgBytes, 0, msgBytes.Length);

                await client.WriteStream.FlushAsync();
               
           

            await client.DisconnectAsync();
            }
            catch
            {
                Debug.WriteLine("Olmadı");
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
