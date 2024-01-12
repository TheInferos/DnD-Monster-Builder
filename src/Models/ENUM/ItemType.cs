namespace Monster_Builder_Web_API.src.Models.ENUM
{
    /// <summary>
    /// When Creating an item it will have a type. This type will help show what type of item it is and therefore what functions
    /// Can be used on it
    /// </summary>
    public enum ItemType
    {
        /// <summary>
        /// Is the item a Peice of Armour.
        /// </summary>
        Armour,
        /// <summary>
        /// IS this item a Weapon that can be equipted
        /// </summary>
        Weapon,
        /// <summary>
        /// All undefined types will go here until classes are needed for them
        /// </summary>
        Other
    }
}
