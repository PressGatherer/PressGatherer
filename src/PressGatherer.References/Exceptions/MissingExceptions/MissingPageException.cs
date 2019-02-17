using System;

namespace PressGatherer.References.Exceptions
{
    [Serializable]
    public class MissingPageException : Exception
    {
        public MissingPageException()
        {

        }
        public MissingPageException(string page)
            : base(String.Format("PageId is missing: {0}", page))
        {

        }

    }
}
