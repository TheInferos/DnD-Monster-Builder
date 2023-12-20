using Monster_Builder_Web_API.Models.ENUM;

namespace Monster_Builder_Web_API.Models
{
    public class Action
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ActionType Type { get; set; }
        public RechargeType Recharge { get; set; }


    }
}
