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

namespace LaGranAppUI.View.CRUDButtons
{
    /// <summary>
    /// Lógica de interacción para viewCRUDButtons.xaml
    /// </summary>
    public partial class viewCRUDButtons : UserControl
    {
        public static readonly DependencyProperty CRUDCommandProperty = DependencyProperty.Register("CRUDCommand", typeof(ICommand), typeof(viewCRUDButtons), new UIPropertyMetadata(null));
        public ICommand CRUDCommand
        {
            get { return (ICommand)GetValue(CRUDCommandProperty); }
            set { SetValue(CRUDCommandProperty, value); }
        }
        public viewCRUDButtons()
        {
            InitializeComponent();
        }
    }
}
