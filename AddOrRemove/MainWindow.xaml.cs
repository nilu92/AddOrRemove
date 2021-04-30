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
using System.Threading;
namespace AddOrRemove
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Brush CustomColor;
        Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void addOrRemoveItems(object sender, MouseButtonEventArgs e)
        {
            if(e.OriginalSource is Rectangle)
            {
                Rectangle activeRectangle = (Rectangle)e.OriginalSource;

                MyCanvas.Children.Remove(activeRectangle);
            }
            else
            {
                CustomColor = new SolidColorBrush(Color.FromRgb((byte)random.Next(1,255), (byte)random.Next(1, 255), (byte)random.Next(1, 255)));
                Rectangle newRectangle = new Rectangle
                {
                    Width = 50,
                    Height = 50,
                    Fill = CustomColor,
                    StrokeThickness = 3,
                    Stroke = Brushes.Black
                };

                Canvas.SetLeft(newRectangle, Mouse.GetPosition(MyCanvas).X);
                Canvas.SetTop(newRectangle, Mouse.GetPosition(MyCanvas).Y);

                MyCanvas.Children.Add(newRectangle);
            }
        }
    }
}
