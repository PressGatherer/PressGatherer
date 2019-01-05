using System;
using System.Collections.Generic;
using System.Text;

namespace PressGatherer.References.TransportModels.ArticleModules
{
    public class RemovePageTransportResponseModel
    {
        public bool Removed { get; set; }

        public RemovePageTransportResponseModel(bool removed)
        {
            this.Removed =removed;
        }
    }
}
