using System;
using Newtonsoft.Json;

namespace skillCommunity.Models
{
    public class SkillsGroup
    {
        private readonly int id;
        private string label;
        private string description;
        private string imageUrl;

        public SkillsGroup()
        {
        }

        public int Id => id;
        public string Label { get => label; set => label = value; }
        public string Description { get => description; set => description = value; }
        [JsonProperty("image_url")]
        public string ImageUrl { get => imageUrl; set => imageUrl = value; }
    }
}
