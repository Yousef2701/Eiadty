using System.Text.Json.Serialization;

namespace Medical.EF
{
    public class AuthModel
    {
        public string Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public string? Phone { get; set; }
        public string? Role { get; set; }
        public string? Token { get; set; }
        //public DateTime? Expiration { get; set; }

        //this annotatin will ignore this field in jason output
        [JsonIgnore]
        public string? RefreshToken { get; set; }

        public DateTime RefreshTokenExpiration { get; set; }
    }
}
