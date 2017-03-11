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
using WUAClient.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WUAClient.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AllQuestionAnswersView : Page
    {
        private AllQuestionAnswersVM _vm;
        private bool filtered = false;

        public AllQuestionAnswersView()
        {
            this.InitializeComponent();
            this.Loaded += AllQuestionAnswersView_Loaded;
        }

        private void AllQuestionAnswersView_Loaded(object sender, RoutedEventArgs e)
        {
            _vm = new AllQuestionAnswersVM();
            _vm.LoadAllQuestionAnswers();
            this.DataContext = _vm;
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            if (!filtered)
            {
                _vm.FilterByTitle(txbFilterTitle.Text);

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
    }
}
