using System;

namespace PressGatherer.References.Exceptions
{
    [Serializable]
    public class DuplicateWordException : Exception
    {
        public DuplicateWordException()
        {

        }

        public DuplicateWordException(string word)
            : base(String.Format("Duplicated word: {0}", word))
        {

        }

    }
}
