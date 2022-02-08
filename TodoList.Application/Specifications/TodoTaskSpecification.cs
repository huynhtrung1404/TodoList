using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TodoList.Entities.Entities;

namespace TodoList.Applications.Specifications
{
    public class TodoTaskSpecification : BaseSpecification<TodoTask>
    {
        public TodoTaskSpecification(Guid userId) : base(x => x.Id.Equals(userId))
        {
        }
    }
}
