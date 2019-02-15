using System;

namespace PressGatherer.References.Exceptions
{
    [Serializable]
    public class MissingWordException : Exception
    {
        public MissingWordException()
        {

        }

        public MissingWordException(string searchWord)
            : base(String.Format("Search word does not exist: {0}", searchWord))
        {

        }

    }
}
