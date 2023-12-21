using System.Text.Json.Serialization;
using Monster_Builder_Web_API.Models.Enum;

namespace Monster_Builder_Web_API.Models
{
    public class MonsterAction
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ActionType Type { get; set; }
        public RechargeType Recharge { get; set; }

        public ActionEffect Effect { get; set; }

        public MonsterAction (string name, string description, ActionType type, RechargeType recharge, ActionEffect effect)
        {
            Name = name;
            Description = description;
            Type = type;
            Recharge = recharge;
            Effect = effect;
        }
        [JsonConstructor]
        public MonsterAction(){}
    }
}
