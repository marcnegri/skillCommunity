using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using skillCommunity.Models;
using skillCommunity.Views;
using skillCommunity.ViewModels;

namespace skillCommunity.Views
{
    public partial class SkillsGroupPage : ContentPage
    {
        SkillsGroupViewModel viewModel;


        public SkillsGroupPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new SkillsGroupViewModel();
        }

        void AddItem_Clicked(object sender, SelectedItemChangedEventArgs args)
        {
            Console.WriteLine("ok");
        }

        async void OnItemSelected(object sender, SelectionChangedEventArgs args)
        {
            var item = args.CurrentSelection;

            if (item == null)
                return;

            await Navigation.PushAsync(new SkillsPage());//new ItemDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.SkillsGrp.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}