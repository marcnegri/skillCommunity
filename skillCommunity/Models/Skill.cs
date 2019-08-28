using System;
using Newtonsoft.Json;

namespace skillCommunity.Models
{
    public class Skill
    {
        private readonly int id;
        private string label;
        private string description;
        private string imageUrl;
        private User author;
        private float globalReview;

        public Skill()
        {
        }

        public int Id => id;
        public string Label { get => label; set => label = value; }
        public string Description { get => description; set => description = value; }
        [JsonProperty("image_url")]
        public string ImageUrl { get => imageUrl; set => imageUrl = value; }
        public User Author { get => author; set => author = value; }
        [JsonProperty("global_review")]
        public float GlobalReview { get => globalReview; set => globalReview = value; }
    }
}
