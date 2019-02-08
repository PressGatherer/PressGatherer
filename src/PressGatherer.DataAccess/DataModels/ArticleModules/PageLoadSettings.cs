using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using PressGatherer.References.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace PressGatherer.DataAccess
{
    public class PageLoadSettings
    {
        [BsonElement("articleContentXPath")]
        public string ArticleContentXPath { get; set; }

        public PageLoadSettings(string articleContentXPath)
        {
            this.ArticleContentXPath = articleContentXPath;
        }
    }
}
