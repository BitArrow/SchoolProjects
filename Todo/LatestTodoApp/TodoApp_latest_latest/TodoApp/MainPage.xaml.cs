using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TodoApp.Views;
using ToDoApp.Models;
using ToDoApp.ViewModels;
using ToDoApp.Views;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TodoApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private MainPageVM _vm;

        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
            this._vm = new MainPageVM();
            this._vm.LoadData();
            this.DataContext = this._vm;
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            //Inversiooni kasutamine aitab siin vältida pikka if else jada kirjutamist
            TodoAppNavigation.IsPaneOpen = !TodoAppNavigation.IsPaneOpen;
        }

        private void btnCategoryNavigation_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            //btn.Comm
            //Button btn = (Button)sender;
            if (btn != null) {
                Category selectedCategory = btn.DataContext as Category;

                if (selectedCategory != null)
                {
                    _vm.FilterTodosByCategory(selectedCategory);
                }
        
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            _vm.RemoveFilters();
        }

        private void lvTodos_ItemClick(object sender, ItemClickEventArgs e)
        {
            ToDo selected = e.ClickedItem as ToDo;

            if (selected != null) { 
            this.Frame.Navigate(typeof(ItemView),selected);
            }
        }

        private void lvTodos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
