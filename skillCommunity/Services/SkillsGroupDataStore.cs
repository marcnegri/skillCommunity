using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using skillCommunity.Models;
using YouWeesh.Mobile.Services;

namespace skillCommunity.Services
{
    public class SkillsGroupDataStore : IDataStore<SkillsGroup>
    {
        List<SkillsGroup> items;

        public SkillsGroupDataStore()
        {
        }

        public async Task<bool> AddItemAsync(SkillsGroup item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(SkillsGroup item)
        {
            var oldItem = items.Where((SkillsGroup arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = items.Where((SkillsGroup arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<SkillsGroup> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<SkillsGroup>> GetItemsAsync()
        {
            ObservableCollection<SkillsGroup> lst = new ObservableCollection<SkillsGroup>();
            try
            {
                var response = await HttpRequester.Instance.GetAsync("skillsgroups/");
                ObservableCollection<SkillsGroup> events = new ObservableCollection<SkillsGroup>();
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    lst = JsonConvert.DeserializeObject<ObservableCollection<SkillsGroup>>(content);
                }
                
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return lst;
        }
    }
}