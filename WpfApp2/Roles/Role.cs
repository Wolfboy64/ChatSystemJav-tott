using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Users.Permissions;

namespace WpfApp2.Roles
{
    internal class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public List<Permission> Acces { get; set; }

        public Role(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
            //Acces = acces;
        }

        public static Role r1 = new Role(0, "Unknow", "" );
        public static Role r2 = new Role(0, "User", "");
        public static Role r3 = new Role(0, "Designer", "");
        public static Role r4 = new Role(0, "Staff", "");
        public static Role r5 = new Role(0, "Admin", "");
        public static Role r6 = new Role(0, "Manager", "");
        public static Role r7 = new Role(0, "Owner", "");

        public static List<Role> roles = new List<Role>()
        {
            r1, r2, r3, r4, r5, r6,
        };
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
