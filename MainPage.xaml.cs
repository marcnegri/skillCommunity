using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MetadataScraper.Services;

namespace MetadataScraper
{
    public partial class MainPage : ContentPage
    {
        private bool hasFirstUrl = false;
        public MainPage()
        {
            InitializeComponent();
        }

        async void BtnScrape_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(etyURL.Text))
                {
                    lblText.Text = etyURL.Text;

                    foreach (string word in etyURL.Text.Split(' '))
                    {
                        if (word.StartsWith("http".ToLower()))
                        {

                        }else if(word.StartsWith("www".ToLower()))
                        {
                            var result = await MetaScraper.GetMetaDataFromUrl(string.Format("{0}"+word, "https://"));
                            imgUrl.Source = result.ImageUrl;
                            lblTitle.Text = result.Title;
                            lblDescription.Text = result.Description;
                        }
                    }
                }
            }catch(Exception ex)
            {
                DisplayAlert("Error", "Not a valid URI", "OK");
            }
        }

        async void EtyURL_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            if (etyURL.Text.EndsWith(" ", StringComparison.Ordinal) && !hasFirstUrl)
            {
                var url = (DetectURLInString(etyURL.Text));
                if (!String.IsNullOrEmpty(url))
                {
                    var result = await MetaScraper.GetMetaDataFromUrl(url);
                    imgUrl.Source = result.ImageUrl;
                    lblTitle.Text = result.Title;
                    lblDescription.Text = result.Description;
                }
            }
        }


        private string DetectURLInString(string _url)
        {
            string resultUrl = null;
            try
            {
                if (!String.IsNullOrEmpty(_url))
                {
                    foreach (string word in _url.Split(' '))
                    {
                        if (word.StartsWith("http".ToLower()))
                        {
                            resultUrl = word;
                            hasFirstUrl = true;
                        }
                        else if (word.StartsWith("www".ToLower()))
                        {
                            resultUrl = "https://"+word;
                            hasFirstUrl = true;
                        }
                    }
                }
                return resultUrl;
            }catch(Exception ex)
            {
                return resultUrl;
            }
        }
    }
}
