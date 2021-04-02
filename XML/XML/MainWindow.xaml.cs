using System;
using System.Collections.Generic;
using System.Linq;
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
using System.IO;
using System.Net;


namespace WpfApp8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_click1(object sender, RoutedEventArgs e)
        {
            Item it = new Item();
            textbox1.Text = ($"{it.Title = " habr"}\n {it.Description = "Новости 34"}\n {it.PubDate = DateTime.Now.ToString()}");
        }
        private void SerializeNode()
        {
                // Create the http request
                const string Url = "https://habr.com/ru/rss/interesting/";
                var webRequest = WebRequest.Create(Url);

                // Send the http request and wait for the response
                var responseStream = webRequest.GetResponse().GetResponseStream();

                // Displays the response stream text
                if (responseStream != null)
                {
                    using (var streamReader = new StreamReader(responseStream))
                    {
                        // Return next available character or -1 if there are no characters to be read
                        while (streamReader.Peek() > -1)
                        {
                           textbox1.Text = (streamReader.ReadToEnd()); 
                        }
                    }
                }
        }


        private void button_Click2(object sender, RoutedEventArgs e)
        {
            SerializeNode();
        }

        private void textbox1_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void textbox2_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
    }
}
