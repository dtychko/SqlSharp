using SqlSharp.Expressions;

namespace SqlSharp.Builder
{
    public interface IFinalState
    {
        Expression Expression { get; }
    }
}
