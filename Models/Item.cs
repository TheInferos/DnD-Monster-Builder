using Monster_Builder_Web_API.Models.Enum;

namespace Monster_Builder_Web_API.Models
{
    /// <summary>
    /// This class is the parent class for all items, contianing core information that can be inherited across all items
    /// 
    /// </summary>
    public class Item
    {
        /// <summary>
        /// This is the name of the armour 
        /// Protected. 
        /// </summary>
        protected string name;
        /// <summary>
        /// This is the number of copper pieces that the armour costs.
        /// </summary>
        protected int cost;
        /// <summary>
        /// This is the number of copper pieces that the armour costs.
        /// Protected.
        /// </summary>
        protected int weight;
        /// <summary>
        /// This is the type of the item that is created.
        /// Protected.
        /// </summary>
        protected ItemType type;
        /// <summary>
        /// This is the ID for the item. It should be a guid.
        /// Protected
        /// </summary>
        protected string id;
        /// <summary>
        /// This is a list of Action that should be added to any creature using this item.
        /// </summary>
        protected List<CreatureAction> actions { get; set; }
        /// <summary>
        /// This is a toggle as to wether the item requires an attunement slot to gain affects.
        /// </summary>
        protected bool attunement { get; set; }

        /// <summary>
        /// This is the name of the armour. 
        /// Public
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Name must not be empty");
                name = value;
            }
        }
        /// <summary>
        /// This is the cost in Copper Peices of the item.
        /// </summary>
        public int Cost
        {
            get => cost;
            set
            {
                ArgumentOutOfRangeException.ThrowIfNegative(value);
                cost = value;
            }
        }
        /// <summary>
        /// This is the weight of the item in lbs. Whilst this can be 0 it typically should be 1+.
        /// This should never be negative
        /// </summary>
        public int Weight
        {
            get => weight;
            set
            {
                ArgumentOutOfRangeException.ThrowIfNegative(value);
                weight = value;
            }
        }
        /// <summary>
        /// This is a signifier of what type of item it i (Weapon, Armour, ect)
        /// </summary>
        public ItemType TypeOfItem
        {
            get => type;
        }
        /// <summary>
        /// This is the key that is used to access the armour in the future
        /// </summary>
        public string ID { get => id; }
        /// <summary>
        /// This is palceholder constructor for an item.
        /// TODO: Implement the minimal required items
        /// </summary>
        public Item()
        {
            id = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// This is the function will get all actions from the actions protected property on the Item
        /// </summary>
        /// <returns>List of Actions</returns>
        public List<CreatureAction> GetItemActions()
        {
            return actions;
        }
    }
}
