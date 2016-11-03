namespace DiceShow.Storage
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public static class HttpContentExtensions
    {

        public static async Task<T> ReadAsJsonAsync<T>(this HttpContent content)
        {
            var json = await content.ReadAsStringAsync();
            return await Task.Run(() => JsonConvert.DeserializeObject<T>(json));
        }


        public static async Task<T> ReadAsAnonymousAsync<T>(this HttpContent content, T template)
        {
            return await ReadAsJsonAsync<T>(content);
        }

    }

}