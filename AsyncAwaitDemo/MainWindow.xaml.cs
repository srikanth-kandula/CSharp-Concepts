using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AsyncAwaitDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //DemoSynchronousProgramming();
            DemoAsynchronousProgramming();
        }

        private async void DemoAsynchronousProgramming()
        {
            var html = await GetHtmlAsync(@"https://www.c-sharpcorner.com/UploadFile/b1df45/var-vs-dynamic-keywords-in-C-Sharp/");
            MessageBox.Show(html.Substring(0, 10));
        }

        private async Task<string> GetHtmlAsync(string url) //typical convention is to suffix function name with Async
        {
            WebClient webClient = new WebClient();
            return await webClient.DownloadStringTaskAsync(url); //async version provided by .net for .DownloadString() 
        }

        private void DemoSynchronousProgramming()
        {
            var html = GetHtml(@"https://www.c-sharpcorner.com/UploadFile/b1df45/var-vs-dynamic-keywords-in-C-Sharp/");
            MessageBox.Show(html.Substring(0, 10));
        }

        private string GetHtml(string url)
        {
            WebClient webClient = new WebClient();
            return webClient.DownloadString(url);
        }

    }
}
