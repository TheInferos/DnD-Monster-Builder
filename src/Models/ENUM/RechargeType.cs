namespace Monster_Builder_Web_API.Models.ENUM
{
    /// <summary>
    /// This is how long an recharge period is required to use an action
    /// </summary>
    public enum RechargeType
    {
        /// <summary>
        /// Instantly can be used again
        /// </summary>
        Instant,
        /// <summary>
        /// Can only be used once a round
        /// </summary>
        Round,
        /// <summary>
        /// At the start of a turn roll a d6, 4 or above and the action recharges
        /// </summary>
        Roll4,
        /// <summary>
        /// At the start of a turn roll a d6, 5 or above and the action recharges
        /// </summary>
        Roll5,
        /// <summary>
        /// At the start of a turn roll a d6, 6 the action recharges
        /// </summary>
        Roll6,
        /// <summary>
        /// Will recharge all charges on a Short Rest
        /// </summary>
        ShortRest,
        /// <summary>
        /// Will recharge all charges on a Long Rest
        /// </summary>
        LongRest,
        /// <summary>
        /// This action will not regerate charges once used
        /// </summary>
        Never
    }
}
