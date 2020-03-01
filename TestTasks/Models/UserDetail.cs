using System;
using System.Collections.Generic;
using System.Text;

namespace TestTasks.Models
{
    [Serializable]
    public class UserDetail
    {
        private long id;

        private string firstName;

        public User ToUser;

        public UserDetail(long id, string firstName)
        {
            this.id = id;
            this.firstName = firstName;
        }

        public override string ToString()
        {
            return firstName;
        }
    }
}
