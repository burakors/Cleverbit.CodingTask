using Cleverbit.CodingTask.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Data.Aggregates.ApplicationUserAggregate
{
    public class ApplicationUser : EntityBase
    {
        public ApplicationUser(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
        public string UserName { get; private set; }
        public string Password { get; private set; }
    }
}
