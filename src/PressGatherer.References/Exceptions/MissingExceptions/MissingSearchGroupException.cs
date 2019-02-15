using System;

namespace PressGatherer.References.Exceptions
{
    [Serializable]
    public class MissingSearchGroupException : Exception
    {
        public MissingSearchGroupException()
        {

        }

        public MissingSearchGroupException(string searchGroup)
            : base(String.Format("Search group does not exist: {0}", searchGroup))
        {

        }



    }
}
