using System;
using System.Collections.Generic;
using skillCommunity.Models;
using Xamarin.Forms;

namespace skillCommunity.Views
{
    public partial class SkillsPage : ContentPage
    {
        public SkillsPage()
        {
            InitializeComponent();
            List<SkillsGroup> lstGroup = new List<SkillsGroup>
            {
                new SkillsGroup {Label = "Test", Description = "ijdqoijoijoij dqwij" , ImageUrl="https://cdn-media.prettylittlething.com/wysiwyg/cms/beauty-school/refresh/r-glitter.jpg"},
                new SkillsGroup {Label = "Test", Description = "ijdqoijoijoij dqwij" , ImageUrl="https://www.zone-beauty.com/zone-kettering/assets/images/banner1.jpg"},
                new SkillsGroup {Label = "Test", Description = "ijdqoijoijoij dqwij" , ImageUrl="https://cdn-media.prettylittlething.com/wysiwyg/cms/beauty-school/refresh/r-glitter.jpg"},
                new SkillsGroup {Label = "Test", Description = "ijdqoijoijoij dqwij" , ImageUrl="https://cdn-media.prettylittlething.com/wysiwyg/cms/beauty-school/refresh/r-glitter.jpg"},
                new SkillsGroup {Label = "Test", Description = "ijdqoijoijoij dqwij" , ImageUrl="https://www.zone-beauty.com/zone-kettering/assets/images/banner1.jpg"},
                new SkillsGroup {Label = "Test", Description = "ijdqoijoijoij dqwij" , ImageUrl="https://cdn-media.prettylittlething.com/wysiwyg/cms/beauty-school/refresh/r-glitter.jpg"},
                new SkillsGroup {Label = "Test", Description = "ijdqoijoijoij dqwij" , ImageUrl="https://www.zone-beauty.com/zone-kettering/assets/images/banner1.jpg"}

            };
            cltSkills.ItemsSource = lstGroup;
        }
    }
}
