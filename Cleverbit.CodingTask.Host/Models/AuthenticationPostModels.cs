using Newtonsoft.Json;

namespace Cleverbit.CodingTask.Host.Models
{
    public class AuthenticationPostRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class AuthenticationPostResponse
    {
        [JsonProperty("auth_token")]
        public string AuthToken { get; set; }
    }
}
