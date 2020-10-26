using MaterialDesignThemes.Wpf;
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

namespace LaGranAppUI.View.Snackbar
{
    /// <summary>
    /// Lógica de interacción para viewSnackBar.xaml
    /// </summary>
    /// 


   
    public partial class viewSnackBar : UserControl
    {
        public static readonly DependencyProperty BoundMessageQueueProperty = DependencyProperty.Register("BoundMessageQueue", typeof(SnackbarMessageQueue), typeof(viewSnackBar), new UIPropertyMetadata(null));

        public SnackbarMessageQueue BoundMessageQueue
        {
            get
            {
                return (SnackbarMessageQueue)GetValue(BoundMessageQueueProperty);
            }
            set
            {
                SetValue(BoundMessageQueueProperty, value);
            }
        }

        public viewSnackBar()
        {
            InitializeComponent();
        }
    }
}
