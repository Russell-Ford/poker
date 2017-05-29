namespace PokerSolver.RuleProcessors.Interfaces
{
    using PokerSolver.Models;

    public interface ISameKindProcessor
    {
        /// <summary>
        ///     Evaluates whether a particular hand has some number of a kind.
        /// </summary>
        /// <param name="numberOfKind">The number of a kind to check a hand for. IE 3 would check a hand for 3 cards of the same rank.</param>
        /// <param name="hand">The hand to check.</param>
        bool EvaluateSameKind(Hand hand, int numberOfKind);
    }
}
