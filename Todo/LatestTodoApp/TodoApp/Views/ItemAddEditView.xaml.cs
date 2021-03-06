﻿using System;
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
    public sealed partial class ItemAddEditView : Page
    {
        private ItemAddEditViewVm _vm;
        public ItemAddEditView()
        {
            this.InitializeComponent();
        }

        private void SaveTodo_Click(object sender, RoutedEventArgs e)
        {
            
            _vm.Save();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter == null)
            {
                _vm = new ItemAddEditViewVm(new Models.ToDo() { ToDoId = 0, Heading = "Teha WP10", Location = "EIK", Content = "This needs to be done", Done = false, DueDate = DateTime.Today, Priority = Priority.Normal });
            }else
            {
                _vm = new ItemAddEditViewVm(e.Parameter as ToDo);
            }
           
            _vm.Load();
            this.DataContext = _vm;
         
        }
    }
}
