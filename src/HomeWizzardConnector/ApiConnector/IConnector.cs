using System;
using System.Net;

namespace HomeWizzardConnector.ApiConnector
{
    internal interface IConnector : IDisposable
    {
        Uri BaseUri { get; }
        WebClient WebClient { get; }
    }
}
