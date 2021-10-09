using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace KR
{
    /// <summary>
    /// Логика взаимодействия для WindowAdd.xaml
    /// </summary>
    public partial class WindowAdd : Window
    {
        PR10ROMEntities context;
        public WindowAdd(PR10ROMEntities context, Order currentRegistration)
        {
            InitializeComponent();
            this.context = context;
            CmbCustomer.ItemsSource = context.Customer.ToList();
            CmbAngle.ItemsSource = context.Angle.ToList();
            CmbColour.ItemsSource = context.Colour.ToList();
            CmbSize.ItemsSource = context.Size.ToList();
            this.DataContext = currentRegistration;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveImage();
            context.SaveChanges();
            this.Close();
        }
        private void SaveImage()
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image files: *.jpg, *.png|*.jpg, *.png";
            openFile.ShowDialog();
            if (openFile.FileName.Length != 0)
            {
                string nameFile = openFile.FileName;
                byte[] image = File.ReadAllBytes(nameFile);
                var reg = (Order)this.DataContext;
                reg.photo = image;
                photos.Source = new BitmapImage(new Uri(nameFile));

            }
        }
    }
}
