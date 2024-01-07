using System.Text.Json.Serialization;

namespace Monster_Builder_Web_API.Models
{
    /// <summary>
    /// This class is used to desdcribe the action and how it opperates
    /// </summary>
    public class ActionEffect
    {
        private string description { get; set; }
        /// <summary>
        /// This is the public description of the action effect describing how it operates
        /// </summary>
        public string Description { get { return description; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Description must not be empty");
                description = value;
            }
        }
        
        /// <summary>
        /// This is a JSON constructor for the Action Effect to be used when importing from Repository
        /// </summary>
        [JsonConstructor]
        public ActionEffect() 
        {
        }
        /// <summary>
        /// This is the Manual Constuctor for an Action Effect. 
        /// </summary>
        /// <param name="description"> This should be used to describe the effect</param>
        public ActionEffect(string description)
        {
            Description = description;

        }

    }
}
