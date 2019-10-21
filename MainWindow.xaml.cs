using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Media;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Winlight
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer = new DispatcherTimer();
        private string pathRaw = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\AppData\Local\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets";
        private string temp = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Desktop\WinSpotFetcherTemp\";
        private Properties.Settings settings = Properties.Settings.Default;

        public MainWindow()
        {
            InitializeComponent();

            UsernameLabel.Content = Environment.UserName + "!";

            // ez
            if (Debugger.IsAttached)
            {
                settings.Reset();
            }

            if (settings.Path == string.Empty)
            {
                OpenButton.Visibility = Visibility.Hidden;
                NotActualPathLabel.Visibility = Visibility.Visible;

            }
            else
            {
                OpenButton.Visibility = Visibility.Visible;
                NotActualPathLabel.Visibility = Visibility.Hidden;
            }

            if (settings.Path != "")
            {
                PathLabel.Content = settings.Path;
            }
            else
            {
                PathLabel.Content = "No direcotry selected";
            }
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                settings.Path = fbd.SelectedPath;
                settings.Save();
                PathLabel.Content = settings.Path;

                OpenButton.Visibility = Visibility.Visible;
                NotActualPathLabel.Visibility = Visibility.Hidden;
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (settings.Path != "")
            {
                // declaring & populating array with raw files
                string[] files = Directory.GetFiles(pathRaw);

                // creating temp dir
                Directory.CreateDirectory(temp);

                //STEP 2 create png from files
                foreach (string file in files)
                {
                    File.Copy(file, temp + System.IO.Path.GetFileNameWithoutExtension(file) + ".png");
                }

                string[] images = Directory.GetFiles(temp);
                string[] imagesPath = Directory.GetFiles(settings.Path, "*.*", SearchOption.AllDirectories);

                // checking for duplicates
                if ((imagesPath != null) || (imagesPath.Length != 0))
                {
                    for (int i = 0; i <= images.Length - 1; i++)
                    {
                        for (int j = 0; j <= imagesPath.Length - 1; j++)
                        {
                            if (System.IO.Path.GetFileName(images[i]) == System.IO.Path.GetFileName(imagesPath[j]))
                            {
                                try
                                {
                                    File.Delete(images[i]);
                                }
                                catch (Exception ex)
                                {
                                    System.Windows.MessageBox.Show(ex.ToString());
                                }
                            }
                        }
                    }
                }

                images = Directory.GetFiles(temp);

                if ((images.Length != 0) || (images != null))
                {
                    // put the images in a bitmap
                    foreach (string image in images)
                    {
                        BitmapImage bmi = new BitmapImage();
                        var stream = File.OpenRead(image);
                        bmi.BeginInit();
                        bmi.CacheOption = BitmapCacheOption.OnLoad;
                        bmi.StreamSource = stream;
                        bmi.EndInit();
                        stream.Close();
                        stream.Dispose();

                        // move all desktop images to Desktop folder
                        if (bmi.PixelWidth.ToString() == "1920")
                        {
                            Directory.CreateDirectory(settings.Path);
                            File.Move(image, settings.Path + "\\" + System.IO.Path.GetFileNameWithoutExtension(image) + ".png");
                        }
                        else
                        {
                            File.Delete(image);
                        }
                    }

                    Directory.Delete(temp);

                    if (images.Length != 0)
                    {
                        System.Windows.MessageBox.Show("Searching done, found " + images.Length + " images.", "Notice");
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("No new images available.", "Notice");
                    }
                }
            }
            else
            {
                System.Windows.MessageBox.Show("No direcotry selected", "Notice");
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void TitleLabel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            /*
            System.Windows.MessageBox.Show("sike");

            try
            {
                Process.Start(settings.Path);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Some error occured...\n\n" + ex.Message);
            }*/
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(settings.Path);
        }
    }
}
