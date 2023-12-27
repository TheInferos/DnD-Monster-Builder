namespace Monster_Builder_Web_API.Models.Enum
{
    /// <summary>
    /// 
    /// </summary>
    public enum ActionType
    {
        /// <summary>
        /// The most common type of action, allowing a character to perform various tasks like attacking 
        /// with a weapon, casting a spell, activating an item, or using class abilities. This usually consumes 
        /// the character's action for their turn.
        /// </summary>
        Action,
        /// <summary>
        /// A shorter, secondary action that some spells, abilities, or class features grant. 
        /// A character can take a bonus action only when specifically prompted by a feature, 
        /// spell, or other abilities.
        /// </summary>
        Bonus,
        /// <summary>
        /// An instant response to a specific trigger, often taken in response to something happening outside 
        /// of the character's turn. Common reactions include making opportunity attacks, using certain spells 
        /// like shield, or utilizing other abilities that specify they can be used as reactions.
        /// </summary>
        Reaction,
        /// <summary>
        /// Actions that are so minor or quick that they don't require a specific action type and are usually 
        /// allowed at the DM's discretion. These might include dropping an item, speaking a few words, 
        /// or releasing a held object.
        /// </summary>
        Free,
        /// <summary>
        /// Although not technically an action type, movement is an integral part of a character's turn. 
        /// In a turn, a character can move up to their speed (which is determined by their race and certain effects),
        /// broken up before, after, or between other actions.
        /// </summary>
        Movement,
        /// <summary>
        /// Interacting with an object around you might require your action or can be performed as 
        /// part of your movement or action, such as drawing or sheathing a weapon, picking up an item, 
        /// opening a door, or retrieving an object from your backpack.
        /// </summary>
        Object,
        /// <summary>
        /// Legendary Actions are abilities that certain powerful creatures can take at the end of another creature's turn. 
        /// These actions allow these creatures to act outside their regular turn in combat. 
        /// These actions are separate from their regular action and can be taken a limited number of 
        /// times between other creatures' turns during the round. Legendary creatures might have a variety of 
        /// options for their Legendary Actions, providing them with additional mobility, attacks, or other powerful 
        /// abilities to challenge the party.
        /// </summary>
        Legendary,
        /// <summary>
        /// Lair Actions are special abilities that are tied to the environment where a creature resides, 
        /// such as its lair. Certain powerful creatures have lairs that can take special actions during combat rounds, 
        /// typically at initiative count 20 (losing initiative ties). 
        /// These actions represent the lair itself aiding the creature or affecting the battlefield, 
        /// such as summoning reinforcements, altering the terrain, or unleashing environmental hazards.
        /// </summary>
        Lair
    }
}
