using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace Dec
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string assemblyPath = @"C:\Users\HP\Documents\Visual Studio 2015\Projects\CarDBSQLApplication\
                                     CarDBSQLApplication\bin\Debug\CarDBSQLApplication.exe";
        public MainWindow()
        {
            InitializeComponent();

            tbxInput.Text = assemblyPath;

            Assembly asm = Assembly.LoadFrom(assemblyPath);

            Type[] types = asm.GetTypes();
            lbTypesList.ItemsSource = types;

            lbTypesList.SelectionChanged += LbTypesList_SelectionChanged;

        }

        private void LbTypesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Type t = (Type)lbTypesList.SelectedItem;

            MemberInfo[] mi = t.GetMethods();
            lbMethodsList.ItemsSource = mi;

            ConstructorInfo[] ci = t.GetConstructors();
            lbConstructorsList.ItemsSource = ci;

            FieldInfo[] fi = t.GetFields();
            lbFieldsList.ItemsSource = fi;

            PropertyInfo[] pi = t.GetProperties();
            lbPropertiesList.ItemsSource = pi;

        }
    }
}
