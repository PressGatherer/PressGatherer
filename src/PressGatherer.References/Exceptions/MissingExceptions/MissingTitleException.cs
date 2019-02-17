using System;

namespace PressGatherer.References.Exceptions
{
    [Serializable]
    public class MissingTitleException : Exception
    {
        public MissingTitleException()
        {

        }

        public MissingTitleException(string title)
            : base(String.Format("Title is missing: {0}", title))
        {

        }

    }
}
