using System;
using System.Collections.Generic;
using System.Text;

namespace PressGatherer.Services.ServiceEntities
{
    public class Rss
    {
        public string Content { get; set; }


        public Rss()
        {
            this.Content = "";
        }

        public Rss(string content)
        {
            this.Content = content;
        }
    }
}