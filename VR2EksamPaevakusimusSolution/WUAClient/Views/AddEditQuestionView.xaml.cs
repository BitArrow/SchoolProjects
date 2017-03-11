using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WUAClient.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddEditQuestionView : Page
    {
        private AddEditQuestionVM _vm;
        private bool isNew = false;

        public AddEditQuestionView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _vm = new AddEditQuestionVM();
            if (e.Parameter == null)
            {
                isNew = true;
            }
            else
            {
                _vm.Question = e.Parameter as Question;
                _vm.LoadQuestionAnswers();
            }
            this.DataContext = _vm;

            base.OnNavigatedTo(e);
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (isNew)
                _vm.Add();
            else
                _vm.SaveChanges();

            await DelayNavigation();
            //this.Frame.Navigate(typeof(MainPage));
            this.Frame.GoBack();
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            _vm.Delete();

            await DelayNavigation();
            //this.Frame.Navigate(typeof(MainPage));
            this.Frame.GoBack();
        }

        private void addAnswer_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddEditQuestionAnswerView), _vm.Question);
        }

        private void lvQuestionAnswers_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Frame.Navigate(typeof(AddEditQuestionAnswerView), e.ClickedItem as QuestionAnswer);
        }

        private async Task DelayNavigation()
        {
            await Task.Delay(750);
        }
    }
}
