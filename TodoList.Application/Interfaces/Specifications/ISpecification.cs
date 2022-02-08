using System.Linq.Expressions;

namespace TodoList.Applications.Interfaces.Specifications
{
    public interface ISpecification<T>
    {
        Expression<Func<T,bool>> Criteria { get; }
        List<Expression<Func<T,object>>> Includes { get; }
        List<string> IncludeStrings { get; }
    }
}
