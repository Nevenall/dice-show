// {
//         "id": "iot2",
//         "_rid": "qicAAA==",
//         "_ts": 1446192371,
//         "_self": "dbs\/qicAAA==\/",
//         "_etag": "\"00001800-0000-0000-0000-563324f30000\"",
//         "_colls": "colls\/",
//         "_users": "users\/"
//     }

namespace DiceShow.Storage.Models
{

    using System;
    using Newtonsoft.Json;
    public class Database
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("_rid")]
        public string ResourceId { get; set; }

        [JsonProperty("_ts")]
        public string Timestamp { get; set; }




    }
}