using System.Text.Json.Serialization;

namespace Monster_Builder_Web_API.Models
{
    public class ActionEffect
    {
        public string Description { get; set; }
        
        [JsonConstructor]
        public ActionEffect() 
        {
        }
        public ActionEffect(string description)
        {
            Description = description;
        }
    }
}
