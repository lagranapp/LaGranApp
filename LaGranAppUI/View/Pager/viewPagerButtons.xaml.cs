using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LaGranAppUI.View.Pager
{
    /// <summary>
    /// Lógica de interacción para viewPagerButtons.xaml
    /// </summary>
    public partial class viewPagerButtons : UserControl
    {
        public viewPagerButtons()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty PagerCommandProperty = DependencyProperty.Register("PagerCommand", typeof(ICommand), typeof(viewPagerButtons));
        public ICommand PagerCommand
        {
            get { return (ICommand)GetValue(PagerCommandProperty); }
            set { SetValue(PagerCommandProperty, value); }
        }        
    }
}
