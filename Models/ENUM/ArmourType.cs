namespace Monster_Builder_Web_API.Models.Enum
{
    /// <summary>
    /// This is the type of Armour which will help derive how AC is calculated
    /// </summary>
    public enum ArmourType
    {
        /// <summary>
        /// This is an unarmoured base (10)) for Monsters with No Armour
        /// Alternatively this is can be increased with a Shell, Hide, Scales ect.
        /// </summary>
        Natural,
        /// <summary>
        /// Made from supple and thin materials, light armor favors agile adventurers since it offers 
        /// some protection without sacrificing mobility. If you wear light armor, you add your 
        /// Dexterity modifier to the base number from your armor type to determine your Armor Class.
        /// </summary>
        Light,
        /// <summary>
        /// Medium armor offers more protection than light armor, but it also impairs movement more. 
        /// If you wear medium armor, you add your Dexterity modifier, to a maximum of +2, to the 
        /// base number from your armor type to determine your Armor Class.
        /// </summary>
        Medium,
        /// <summary>
        /// 
        /// Of all the armor categories, heavy armor offers the best protection. 
        /// These suits of armor cover the entire body and are designed to stop a wide range of attacks. 
        /// Only proficient warriors can manage their weight and bulk.  
        /// Heavy armor doesn’t let you add your Dexterity modifier to your Armor Class, but it also doesn’t 
        /// penalize you if your Dexterity modifier is negative.
        /// </summary>
        Heavy,
        /// <summary>
        /// This category refers to magical armors or enchantments that offer protection and special effects 
        /// against specific types of attacks or conditions. These armors might not fit strictly into the light, 
        /// medium, or heavy classifications and often have unique properties.
        /// </summary>
        Spell,
        /// <summary>
        /// This category might include exotic or non-standard armors that don't fit neatly into the traditional 
        /// classifications. They could have special effects, resistances, or weaknesses that make them distinct 
        /// from the standard armor types.
        /// </summary>
        Other
    }
}
