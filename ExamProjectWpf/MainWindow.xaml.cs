using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExamProjectWpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Apple> apples;
        private string path;
        public MainWindow()
        {
            InitializeComponent();
            path = Directory.GetCurrentDirectory() + "/save.json";
            FileRead();
            mainDataGrid.ItemsSource = apples;
        }

        private void MainDataGridCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            foreach (Apple i in apples)
            {
                i.CalculateLoss();
                i.CalculateProfit();
            }
            Apple p = apples[0];
            FileWrite();
        }

        #region JsonFile
        private void FileRead()
        {
            using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                using (StreamReader stream = new StreamReader(fileStream))
                {
                    using (JsonTextReader reader = new JsonTextReader(stream))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        apples = serializer.Deserialize<ObservableCollection<Apple>>(reader);
                        if (apples == null) apples = new ObservableCollection<Apple>();
                    }
                }
            }
        }

        private void FileWrite()
        {
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                using (StreamWriter stream = new StreamWriter(fileStream))
                {
                    using (JsonTextWriter writer = new JsonTextWriter(stream))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Serialize(writer, apples);
                    }
                }
            }
        }
        #endregion
    }
}
