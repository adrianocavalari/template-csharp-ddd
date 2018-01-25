﻿using System.Collections.Generic;

namespace Template.Domain.Entities
{
    public class User
    {
        public User()
        {
            Orders = new List<Order>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

    }
}
