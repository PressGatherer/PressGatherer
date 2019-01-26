using System;
using System.Collections.Generic;
using System.Text;

namespace PressGatherer.Services.ServiceEntities
{
    public class SearchPage
    {
        public string Content { get; set; }


        public SearchPage()
        {
            this.Content = "";
        }

        public SearchPage(string content)
        {
            this.Content = content;
        }
    }
}