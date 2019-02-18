using System;

namespace PressGatherer.References.Exceptions
{
    [Serializable]
    public class MissingLinkException : Exception
    {
        public MissingLinkException()
        {

        }

        public MissingLinkException(string link)
            : base(String.Format("Link is missing: {0}", link))
        {

        }

    }
}
