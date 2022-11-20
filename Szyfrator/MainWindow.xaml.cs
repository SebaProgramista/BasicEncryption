using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.IO;
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

namespace Szyfrator
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

        private void Btn_Encrypt(object sender, RoutedEventArgs e)
        {
            string text_to_encrypt;
            string alf = "abcdefghijklmnoprstuwxyz";
            string encrypted_text = "";
            if (txtbox_text_to_encrypt.Text == "")
            {
                txtbox_text_to_encrypt.Text = "Proszę podać tekst do zaszyfrowania!";
            }
            else
            {
                text_to_encrypt = txtbox_text_to_encrypt.Text;
                stack_encrypt.Children[0].Visibility = Visibility.Collapsed;
                for(int i = 0; i < text_to_encrypt.Length; i++)
                {
                    encrypted_text += alf[(alf.IndexOf(text_to_encrypt[i]) + 5) % alf.Length];
                }
                lbl_decrypted_text.Content = encrypted_text;
                stack_encrypt.Children[1].Visibility = Visibility.Visible;
            }
        }

        private void Encrypt_Btn_Save(object sender, RoutedEventArgs e)
        {
            SaveFileDialog savefiledialog = new SaveFileDialog();
            savefiledialog.FileName = "Decrypted Text";
            savefiledialog.DefaultExt = ".txt";
            savefiledialog.Filter = "Text documents (.txt)|*.txt";
            if(savefiledialog.ShowDialog() == true)
            {
                File.WriteAllText(savefiledialog.FileName, lbl_decrypted_text.Content.ToString());
            }
            stack_encrypt.Children[0].Visibility = Visibility.Visible;
            stack_encrypt.Children[1].Visibility = Visibility.Collapsed;
            txtbox_text_to_encrypt.Text = "";
        }

        private void Encrypt_Btn_Back(object sender, RoutedEventArgs e)
        {
            stack_encrypt.Children[0].Visibility = Visibility.Visible;
            stack_encrypt.Children[1].Visibility = Visibility.Collapsed;
        }

        private void Btn_Decrypt(object sender, RoutedEventArgs e)
        {
            string text_to_decrypt = decrypt_lbl_text_to_decrypt.Text;
            string alf = "abcdefghijklmnoprstuwxyz";
            string decrypted_text = "";
            stack_decrypt.Children[0].Visibility = Visibility.Collapsed;
            stack_decrypt.Children[1].Visibility = Visibility.Visible;
            for(int i = 0; i < text_to_decrypt.Length; i++)
            {
                decrypted_text += alf[(alf.Length + (alf.IndexOf(text_to_decrypt[i]) - 5)) % alf.Length];
            }
            lbl_encrypted_text.Content = decrypted_text;
        }
    }
}
