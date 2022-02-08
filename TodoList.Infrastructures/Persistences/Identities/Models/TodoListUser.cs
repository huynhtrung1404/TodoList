using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Infrastructures.Persistences.Identities.Models
{
    public class TodoListUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime DOB { get; set; }
    }
}
