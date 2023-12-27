using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace Monster_Builder_Web_API.Models
{
    public class ActionEffect
    {
        private string description { get; set; }
        public string Description { get { return description; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Description must not be empty");
                description = value;
            }
        }
        
        [JsonConstructor]
        public ActionEffect() 
        {
        }
        public ActionEffect(string description)
        {
            description = Description;

        }

    }
}
