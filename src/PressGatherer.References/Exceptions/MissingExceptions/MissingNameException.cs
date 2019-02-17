using System;

namespace PressGatherer.References.Exceptions
{
    [Serializable]
    public class MissingNameAtCreatingPageException : Exception
    {
        public MissingNameAtCreatingPageException()
        {

        }

        public MissingNameAtCreatingPageException(string name)
            : base(String.Format("Page name is missing: {0}", name))
        {

        }

    }
}
