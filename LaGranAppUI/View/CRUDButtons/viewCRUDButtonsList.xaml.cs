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
    /// Lógica de interacción para viewCRUDButtonsList.xaml
    /// </summary>
    public partial class viewCRUDButtonsList : UserControl
    {
        public viewCRUDButtonsList()
        {
            InitializeComponent();
        }
    

    #region "CRUD COMMAND"

    public static readonly DependencyProperty CRUDListCommandProperty = DependencyProperty.Register("CRUDListCommand", typeof(ICommand), typeof(viewCRUDButtonsList), new UIPropertyMetadata(null));
    public ICommand CRUDListCommand
    {
        get { return (ICommand)GetValue(CRUDListCommandProperty); }
        set
        {
            SetValue(CRUDListCommandProperty, value);
        }
    }

    #endregion

    #region "FILTROS"

    public static readonly DependencyProperty FiltrosProperty = DependencyProperty.Register("Filtros", typeof(List<string>), typeof(viewCRUDButtonsList), new UIPropertyMetadata(null));
    public List<string> Filtros
    {
        get { return (List<string>)GetValue(FiltrosProperty); }
        set
        {
            SetValue(FiltrosProperty, value);
        }
    }



    public static readonly DependencyProperty sFiltroProperty = DependencyProperty.Register("sFiltro", typeof(string), typeof(viewCRUDButtonsList), new UIPropertyMetadata(null));
    public string sFiltro
    {
        get { return (string)GetValue(sFiltroProperty); }
        set
        {
            SetValue(sFiltroProperty, value);
        }
    }


    #endregion

    public bool Filtro_Visible
    {
        get
        {
            return stkFiltro.IsVisible;
        }
        set
        {
            stkFiltro.Visibility = value ? Visibility.Visible : Visibility.Hidden;

        }
    }
    }
}
