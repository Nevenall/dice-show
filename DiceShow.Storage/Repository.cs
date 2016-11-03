namespace DiceShow.Storage
{
    using DiceShow.Model;
    using Flurl.Http;
    using System;
    using System.Linq;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using Flurl.Http;
    using Flurl;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net;
    using System.Text.Encodings.Web;
    using DiceShow.Storage.Models;
    public class Repository : IRepository
    {

        private string _endpoint;
        private string _key;
        private byte[] _keyBytes;
        private string _databaseId;

        const string ApiVersion = "2015-12-16";
        const string Databases = "dbs";
        const string Collections = "colls";


        static Repository()
        {

            FlurlHttp.Configure(c =>
                  {
                      c.AllowedHttpStatusRange = "*";
                      //c.BeforeCall = call => Console.WriteLine(JsonConvert.SerializeObject(call.Request.Headers), ConsoleColor.Yellow);
                  });
        }

        public Repository(string connection, string database)
        {
            _endpoint = connection.Split(';')[0].Split('=')[1];
            _key = connection.Split(';')[1].Split(new char[] { '=' }, count: 2)[1];
            _keyBytes = Convert.FromBase64String(_key);
            _databaseId = database;

            if (!DoesDatabaseExist(_databaseId).Result)
            {
                CreateDatabase(_databaseId).RunSynchronously();
            }
        }

        public async Task<bool> DoesDatabaseExist(string id)
        {
            var date = DateTime.UtcNow.ToString("r");
            var ret = await _endpoint.AppendPathSegments(Databases, id)
                      .WithHeader("x-ms-version", ApiVersion)
                      .WithHeader("x-ms-date", date)
                      .WithHeader("authorization", MakeAuth(HttpMethod.Get, Databases, date, id))
                      .GetAsync();

            if (ret.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }
            else if (ret.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                ret.EnsureSuccessStatusCode();
                return false;
            }
        }


        public async Task<bool> DoesCollectionExist(string id)
        {
            var date = DateTime.UtcNow.ToString("r");
            var ret = await _endpoint.AppendPathSegments(Databases, _databaseId, Collections, id)
                      .WithHeader("x-ms-version", ApiVersion)
                      .WithHeader("x-ms-date", date)
                      .WithHeader("authorization", MakeAuth(HttpMethod.Get, Collections, date, id))
                      .GetAsync();

            if (ret.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }
            else if (ret.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                ret.EnsureSuccessStatusCode();
                return false;
            }
        }

        public async Task<Database> CreateDatabase(string id)
        {
            var date = DateTime.UtcNow.ToString("r");
            var ret = await _endpoint.AppendPathSegments(Databases)
                      .WithHeader("x-ms-version", ApiVersion)
                      .WithHeader("x-ms-date", date)
                      .WithHeader("authorization", MakeAuth(HttpMethod.Get, Databases, date, id))
                     .PostJsonAsync(new { id = id });

            ret.EnsureSuccessStatusCode();

            return await ret.Content.ReadAsJsonAsync<Database>();
        }

        public async Task<Collection> CreateCollection(string id)
        {
            var date = DateTime.UtcNow.ToString("r");
            var ret = await _endpoint.AppendPathSegments(Databases, _databaseId, Collections)
                      .WithHeader("x-ms-version", ApiVersion)
                      .WithHeader("x-ms-date", date)
							 .WithHeader("x-ms-offer-throughput", 400)
                      .WithHeader("authorization", MakeAuth(HttpMethod.Get, Collections, date, id))
                     .PostJsonAsync(new { id = id });

            ret.EnsureSuccessStatusCode();

				return await ret.Content.ReadAsJsonAsync<Collection>();
        }


        private string MakeAuth(HttpMethod verb, string resource, string date, string id)
        {
            var hmacSha256 = new System.Security.Cryptography.HMACSHA256 { Key = _keyBytes };
            var payload = $"{verb.Method.ToLowerInvariant()}\n{resource.ToLowerInvariant()}\n{id}\n{date.ToLowerInvariant()}\n{string.Empty}\n";
            byte[] hash = hmacSha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(payload));
            string signature = Convert.ToBase64String(hash);
            return UrlEncoder.Default.Encode($"type=master&ver=1.0&sig={signature}");
        }


    }

}