
namespace DiceShow.Storage
{
    using System;
    using System.Linq;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using Flurl.Http;
    using Flurl;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Encodings.Web;
    using DiceShow.Storage.Models;

    public static class FlurlExtensions
    {
        public static Task<T> GetAnonymousAsync<T>(this FlurlClient client, T template)
        {
            return client.GetJsonAsync<T>();
        }


    }

}