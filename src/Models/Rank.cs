namespace PokerSolver.Models
{
    /// <remarks>
    ///     This encodes some rule logic that is not strictly speaking portable.
    ///     For example, versions of poker exist where Ace is "less" than Two.
    ///     Consider using an interface instead (possibly overkill).
    /// </remarks>
    public enum Rank
    {
        Two = 2,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,

        // face cards
        Jack,
        Queen,
        King,
        Ace
    }
}
