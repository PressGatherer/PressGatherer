using System;
using System.Collections.Generic;
using System.Text;

namespace PressGatherer.References.TransportModels.SearchModules
{
    public class AddSearchWordToSearchGroupTransportResponseModel
    {
        public bool IsSuccesful { get; set; }
        public AddSearchWordToSearchGroupTransportResponseModel(bool isSuccesful)
        {
            this.IsSuccesful = isSuccesful;
        }
    }
}
