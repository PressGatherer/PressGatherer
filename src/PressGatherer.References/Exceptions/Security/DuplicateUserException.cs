using System;

namespace PressGatherer.References.Exceptions
{
    [Serializable]
    public class DuplicateUserException : Exception
    {
        public DuplicateUserException()
        {

        }

        public DuplicateUserException(string name)
            : base(String.Format("Duplicated username: {0}", name))
        {

        }

    }
}
