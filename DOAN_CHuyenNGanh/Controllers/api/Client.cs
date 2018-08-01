using System.ComponentModel.DataAnnotations;

namespace DOAN_CHuyenNGanh.Controllers.api
{
    public class Client
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Secret { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public ApplicationTypes ApplicationType { get; set; }
        public bool Active { get; set; }
        public int RefreshTokenLifeTime { get; set; }
        [MaxLength(100)]
        public string AllowedOrigin { get; set; }

      
    }
    public class ParsedExternalAccessToken
    {
        public string user_id { get; set; }
        public string app_id { get; set; }
    }
    public enum ApplicationTypes
    {
        JavaScript = 0,
        NativeConfidential = 1
    }
}