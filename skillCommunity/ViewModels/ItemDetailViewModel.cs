using System;

using skillCommunity.Models;

namespace skillCommunity.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public SkillsGroup Item { get; set; }
        public ItemDetailViewModel(SkillsGroup item = null)
        {
            Title = item?.Label;
            Item = item;
        }
    }
}
