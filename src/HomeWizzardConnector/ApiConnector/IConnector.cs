using System;
using System.Net;

namespace HomeWizzardConnector.ApiConnector
{
    internal interface IConnector : IDisposable
    {
        string BaseUrl { get; set; }
        WebClient WebClient { get; set; }
    }
}
