namespace Reportrello.Infrastructure.Http
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IHttpClient
    {
        Task<TResponseData> GetAsync<TResponseData>(string resource, IEnumerable<KeyValuePair<string, string>> segments);
    }
}