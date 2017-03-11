using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ToDoApp.Models;
using ToDoApp.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ToDoApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ItemView : Page
    {
        private ItemViewVM _vm;
        public ItemView()
        {
            this.InitializeComponent();

            //_vm = new ItemViewVM(new Models.ToDo() { ToDoId = 1, Heading="Teha WP10", Location="EIK", Category = new Category() {Name="Test"}, Content = "This needs to be done", Done = false, DueDate = DateTime.Today, Priority = Priority.Normal });
            //this.DataContext = _vm;
        }
        
        public void btnEdit_Click(object sender, RoutedEventHandler e)
        {
            this.Frame.Navigate(typeof(ItemAddEditView), _vm.SelectedTodo);
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _vm = new ItemViewVM(e.Parameter as ToDo);
            this.DataContext = _vm;
            base.OnNavigatedTo(e);
        }

       

        private void btnEditItem_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ItemAddEditView), _vm.SelectedTodo);
        }
    }
}
