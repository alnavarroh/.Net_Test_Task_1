using System.ComponentModel.DataAnnotations;

namespace REST_API.Model
{
    public class User
    {
        [Key]
        public string Login { get; set; }

        public string Password { get; set; }

        public string Role{ get; set; }
        
        public float USD_Balance { get; set; }

    }
}
