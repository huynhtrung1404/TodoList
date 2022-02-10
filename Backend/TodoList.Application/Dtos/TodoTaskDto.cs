using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Applications.Dtos
{
    public class TodoTaskDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DueDate { get; set; }
        public Guid PriorityId { get; set; }
        public Guid UserId { get; set; }
    }
}
