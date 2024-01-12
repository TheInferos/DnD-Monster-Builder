using System.Text.Json.Serialization;
using Monster_Builder_Web_API.Models.ENUM;

namespace Monster_Builder_Web_API.Models
{
    /// <summary>
    /// This is where an action that can be used by a creature is stored.
    /// This is a placeholder currently and does not do anything minus store the information
    /// </summary>
    public class CreatureAction
    {
        /// <summary>
        /// This is the Name of the Action
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// This is a summary of the actions effect to display in quick form.
        /// </summary>
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// This is what type of action that is required to use the action
        /// </summary>
        public ActionType Type { get; set; }
        /// <summary>
        /// This is for how often the Action will Recharge. Instant means no recharge. 
        /// </summary>
        public RechargeType Recharge { get; set; }
        /// <summary>
        /// This is a placeholder effect for the Action. This should define what the action does in detail
        /// And the user should be able to follow this for the full effect.
        /// </summary>
        public ActionEffect Effect { get; set; } = new ActionEffect();
        /// <summary>
        /// This is optional value for if the action has changes and if so how many. This typically will only be used for Short and Long rest Items and items
        /// That do not recharge
        /// </summary>
        public int? Charges { get; set; }

        /// <summary>
        /// This is the constructor for the creature Action.
        /// </summary>
        /// <param name="name">Name to refer to the Action by</param>
        /// <param name="description">A Short Summary of what the action does</param>
        /// <param name="type">What type of action is required to use this action </param>
        /// <param name="recharge">How often can this action be used</param>
        /// <param name="effect">This is the detailed effect of the action</param>
        public CreatureAction(string name, string description, ActionType type, RechargeType recharge, ActionEffect effect)
        {
            Name = name;
            Description = description;
            Type = type;
            Recharge = recharge;
            Effect = effect;
        }
        /// <summary>
        /// This is a basic constructor for JSONS to import into as needed
        /// </summary>
        [JsonConstructor]
        public CreatureAction()
        {
        }
    }
}
