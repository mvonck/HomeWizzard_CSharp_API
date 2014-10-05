namespace HomeWizzardConnector.ApiConnector
{
    internal interface IRetriever
    {
        string RetrieveResultWithRetry(string apiActionUrl, int? numRetries);
    }
}
