namespace HomeWizzardConnector.ApiConnector.Exceptions
{
    internal class ConnectorException : System.Exception
    {
        internal ConnectorException(string message) : base(message)
        {
        }

        internal ConnectorException(string message, System.Exception exception) : base(message, exception)
        {
        }

    }
}
