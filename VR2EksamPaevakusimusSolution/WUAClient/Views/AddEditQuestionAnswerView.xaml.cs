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
    public sealed partial class AddEditQuestionAnswerView : Page
    {
        private AddEditQuestionAnswerVM _vm;
        private bool isNew = false;
        public AddEditQuestionAnswerView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _vm = new AddEditQuestionAnswerVM();
            if (e.Parameter == null)
            {
                this.Frame.Navigate(typeof(MainPage));
            }
            else if (e.Parameter is Question)
            {
                _vm.Question = e.Parameter as Question;
                isNew = true;
            }
            else if (e.Parameter is QuestionAnswer)
            {
                _vm.QuestionAnswer = e.Parameter as QuestionAnswer;
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
            //this.Frame.Navigate(typeof(AddEditQuestionView), _vm.Question);
            this.Frame.GoBack();
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            _vm.Delete();

            await DelayNavigation();
            //this.Frame.Navigate(typeof(AddEditQuestionView), _vm.Question);
            this.Frame.GoBack();
        }

        private async Task DelayNavigation()
        {
            await Task.Delay(750);
        }
    }
}
