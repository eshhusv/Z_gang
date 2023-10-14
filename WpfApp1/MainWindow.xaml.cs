using System;
using System.Collections;
using System.Collections.Generic;
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

namespace WpfApp1
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GetBook(url.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void GetBook(string url)
        {
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += (s, eArgs) =>
            {
                string theBook = eArgs.Result;
                Dispatcher?.Invoke(() => this.text.Text = theBook);
            };
            wc.DownloadStringAsync(new Uri(url));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                string theBook = text.Text;
                string[] sentences = theBook.Split('\n').Distinct().ToArray();
                char[] sentenceInChars = sentences[int.Parse(this.text1.Text)].ToCharArray();
                this.text1.Text = "";
                for (int i = 0; i < sentenceInChars.Length - 2; i++) { this.text1.Text += sentenceInChars[i].ToString(); };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                string theBook = text.Text;
                string[] sentences = theBook.Split('\n').Distinct().ToArray();
                this.text2.Text = sentences[int.Parse(this.text2.Text)].Replace(" ", "  ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}