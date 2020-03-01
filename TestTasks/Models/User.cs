using System;
using System.Collections.Generic;
using System.Text;

namespace TestTasks.Models
{
    [Serializable]
    public class User
    {
        private long id;

        private string userName;

        private DateTime createdOn;

        public UserDetail UserDetail;

        public User(long id, string userName)
        {
            this.id = id;
            this.userName = userName;
        }

        public override string ToString()
        {
            return userName;
        }
    }
}
