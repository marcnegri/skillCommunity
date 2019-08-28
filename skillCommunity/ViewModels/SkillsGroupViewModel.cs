using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using skillCommunity.Models;
using skillCommunity.Views;
using skillCommunity.Services;

namespace skillCommunity.ViewModels
{
    public class SkillsGroupViewModel : BaseViewModel
    {
        public IDataStore<SkillsGroup> DataStore => DependencyService.Get<IDataStore<SkillsGroup>>() ?? new SkillsGroupDataStore();
        public ObservableCollection<SkillsGroup> SkillsGrp { get; set; }
        public Command LoadItemsCommand { get; set; }

        public SkillsGroupViewModel()
        {
            Title = "Browse";
            SkillsGrp = new ObservableCollection<SkillsGroup>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, SkillsGroup>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as SkillsGroup;
                SkillsGrp.Add(newItem);
                bool test = await DataStore.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                SkillsGrp.Clear();
                var items = await DataStore.GetItemsAsync();
                foreach (var item in items)
                {
                    SkillsGrp.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}