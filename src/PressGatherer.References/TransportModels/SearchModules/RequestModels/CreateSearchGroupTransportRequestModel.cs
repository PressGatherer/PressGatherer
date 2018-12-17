using System;
using System.Collections.Generic;
using System.Text;
using PressGatherer.References.TransportModels.SearchModules;

namespace PressGatherer.References.TransportModels.SearchModules
{
    public class CreateSearchGroupTransportRequestModel
    {

        public string GroupName { get; set; }

        public CreateSearchGroupTransportRequestModel()
        {
            this.GroupName = "";
        }

        public CreateSearchGroupTransportRequestModel(string groupName)
        {
            this.GroupName = groupName;
        }
    }
}
