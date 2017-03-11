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
using WUAClient.Models;
using WUAClient.ViewModels;
using WUAClient.Views;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WUAClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private MainPageVM _vm;
        private bool filtered = false;

        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            this._vm = new MainPageVM();
            this._vm.LoadQuestions();
            this.DataContext = this._vm;
        }

        private void lvQuestions_ItemClick(object sender, ItemClickEventArgs e)
        {
            Question selected = e.ClickedItem as Question;

            if (selected != null)
                this.Frame.Navigate(typeof(AddEditQuestionView), selected);
        }

        private void btnAddQuestion_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddEditQuestionView));
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            if (!filtered)
            {
                if (txbFilterTitle.Text != string.Empty)
                    _vm.FindQuestionsByTitle(txbFilterTitle.Text);
                else
                    _vm.FindQuestionsByDescription(txbFilterDesc.Text);
                btnFilter.Visibility = Visibility.Collapsed;
                btnClearFilter.Visibility = Visibility.Visible;
            }
            else
            {
                _vm.ClearFilter();
                btnFilter.Visibility = Visibility.Visible;
                btnClearFilter.Visibility = Visibility.Collapsed;
            }
            filtered = !filtered;
        }

        private void btnAllQuestions_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AllQuestionAnswersView));
        }
    }
}
