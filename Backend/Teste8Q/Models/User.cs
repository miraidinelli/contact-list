using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Teste8Q.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public List<string>? Email { get; set; }
        public string PersonalNumber { get; set; } = string.Empty;
        public string BusinessNumber { get; set; } = string.Empty;
    }
}
