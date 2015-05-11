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
using System.Diagnostics;
using System.IO;

namespace Mod12_Homework
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

        private void btnWriteFile_Click(object sender, RoutedEventArgs e)
        {
           WriteFile();
        }

        private void btnReadFile_Click(object sender, RoutedEventArgs e)
        {
            ReadFile();
        }

        public void WriteFile()
        {
            string filePath = @"SampleFile.txt";
            string text = txtContents.Text;

            Task.Run(()=> WriteTextAsync(filePath, text));
        }

        private async Task WriteTextAsync(string filePath, string text)
        {
            byte[] encodedText = Encoding.Unicode.GetBytes(text);

            using (FileStream sourceStream = new FileStream(filePath,
                FileMode.Append, FileAccess.Write, FileShare.None,
                bufferSize: 4096, useAsync:true))
            {
                await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
            };
        }

        public async void ReadFile()
        {
            string filePath = @"SampleFile.txt";

            if (File.Exists(filePath) == false)
            {
                MessageBox.Show(filePath + " not found", "File Error", MessageBoxButton.OK);
            }
            else
            {
                try
                {
                    txtContents.Text = await ReadTextAsync(filePath);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
        }

        private async Task<string> ReadTextAsync(string filePath)
        {
            return await Task.Run<string>(() =>
            {
                using (FileStream sourceStream = new FileStream(filePath,
                    FileMode.Open, FileAccess.Read, FileShare.Read,
                    bufferSize: 4096, useAsync: true))
                {
                    StringBuilder sb = new StringBuilder();

                    byte[] buffer = new byte[0x1000];
                    int numRead;
                    while ((numRead = sourceStream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        string text = Encoding.Unicode.GetString(buffer, 0, numRead);
                        sb.Append(text);
                    }

                    System.Threading.Thread.Sleep(3000);

                    return sb.ToString();
                }
            });
        }
    }
}
