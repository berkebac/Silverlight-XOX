using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace XOX
{
    public partial class MainPage : UserControl
    {
        int c = 0, r = 1;
        bool kontrol=true;
        public MainPage()
        {
            InitializeComponent();

            for (int i = 0; i < 9; i++)
            {
                System.Windows.Controls.Label lb = new System.Windows.Controls.Label();
                
                lb.FontSize = 60;
                lb.Background = new SolidColorBrush(Colors.Orange);
                Grid.SetColumn(lb, c);
                Grid.SetRow(lb, r);
                lb.Margin = new Thickness(5);
                lb.BorderThickness = new Thickness(8);
                lb.BorderBrush = new SolidColorBrush(Colors.Black);
                lb.HorizontalContentAlignment = HorizontalAlignment.Center;
                lb.HorizontalAlignment = HorizontalAlignment.Stretch;
                lb.VerticalAlignment = VerticalAlignment.Stretch;
                lb.MouseLeftButtonDown += Lb_MouseLeftButtonDown;
                c++;
                if (LayoutRoot.ColumnDefinitions.Count==c)
                {
                    r++;
                    c = 0;
                }
                LayoutRoot.Children.Add(lb);
            }

            
        }

        private void Lb_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            System.Windows.Controls.Label tıklanan = (System.Windows.Controls.Label)sender;
            tıklanan.Visibility = Visibility.Visible;
            if (tıklanan.Content == null)
            {
                if (kontrol == true)
                {
                    tıklanan.Content = "X";

                    kontrol = !kontrol;
                }
                else if (kontrol == false)
                {
                    tıklanan.Content = "O";
                    kontrol = !kontrol;
                }

                Kontrol((System.Windows.Controls.Label)LayoutRoot.Children[0], (System.Windows.Controls.Label)LayoutRoot.Children[1], (System.Windows.Controls.Label)LayoutRoot.Children[2]);
                Kontrol((System.Windows.Controls.Label)LayoutRoot.Children[3], (System.Windows.Controls.Label)LayoutRoot.Children[4], (System.Windows.Controls.Label)LayoutRoot.Children[5]);
                Kontrol((System.Windows.Controls.Label)LayoutRoot.Children[6], (System.Windows.Controls.Label)LayoutRoot.Children[7], (System.Windows.Controls.Label)LayoutRoot.Children[8]);
                Kontrol((System.Windows.Controls.Label)LayoutRoot.Children[2], (System.Windows.Controls.Label)LayoutRoot.Children[4], (System.Windows.Controls.Label)LayoutRoot.Children[6]);
                Kontrol((System.Windows.Controls.Label)LayoutRoot.Children[8], (System.Windows.Controls.Label)LayoutRoot.Children[4], (System.Windows.Controls.Label)LayoutRoot.Children[0]);
                Kontrol((System.Windows.Controls.Label)LayoutRoot.Children[8], (System.Windows.Controls.Label)LayoutRoot.Children[5], (System.Windows.Controls.Label)LayoutRoot.Children[2]);
                Kontrol((System.Windows.Controls.Label)LayoutRoot.Children[7], (System.Windows.Controls.Label)LayoutRoot.Children[4], (System.Windows.Controls.Label)LayoutRoot.Children[1]);
                Kontrol((System.Windows.Controls.Label)LayoutRoot.Children[6], (System.Windows.Controls.Label)LayoutRoot.Children[3], (System.Windows.Controls.Label)LayoutRoot.Children[0]);

            }
        }

        private void btnyeni_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in LayoutRoot.Children)
            {
                System.Windows.Controls.Label lbl = (System.Windows.Controls.Label)item;
                lbl.Content = null;
                tboyunbitti.Visibility = Visibility.Collapsed;
            }
        }

        private void Kontrol(System.Windows.Controls.Label l1, System.Windows.Controls.Label l2, System.Windows.Controls.Label l3)
        {
            if (l1.Content != null && object.Equals(l1.Content,l2.Content) && object.Equals(l2.Content,l3.Content) )
            {
                tboyunbitti.Visibility = Visibility.Visible;
            }
        }
    }
}
