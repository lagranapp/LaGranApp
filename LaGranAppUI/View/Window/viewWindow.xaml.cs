using ControlzEx.Theming;
using MahApps.Metro.Controls;
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
using System.Windows.Shapes;

namespace LaGranAppUI.View.Window
{
    /// <summary>
    /// Lógica de interacción para viewWindow.xaml
    /// </summary>
    public partial class viewWindow : MetroWindow
    {
        public viewWindow()
        {
            InitializeComponent();
            ThemeManager.Current.ChangeTheme(this, "Light.Amber");
        }
    }
}
