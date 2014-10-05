namespace HomeWizzardConnector.ApiConnector.Exceptions
{
    internal class RetrieverException : System.Exception
    {
        internal RetrieverException(string message, System.Exception exception)
            : base(message, exception)
        {
        }

    }
}
