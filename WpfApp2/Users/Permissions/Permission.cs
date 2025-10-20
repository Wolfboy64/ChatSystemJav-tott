using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Users.Permissions
{
    internal class Permission
    {
        public int lvl { get; set; }
        public string NeedRole { get; set; }
        public string CommandName { get; set; }
        
        public Permission(int lvl, string needRole, string commandName)
        {
            this.lvl = lvl;
            NeedRole = needRole;
            CommandName = commandName;
        }

        public static Permission phelp = new Permission(0, "User", "help");
        public static Permission pban = new Permission(4, "Admin", "ban");
        public static Permission pkick = new Permission(3, "Staff", "kick");
        public static Permission pmute = new Permission(2, "Designer", "mute");
        public static Permission punmute = new Permission(2, "Designer", "unmute");
        public static Permission pwarn = new Permission(0, "User", "warn");
        public static Permission punwarn = new Permission(0, "User", "unwarn");
        public static Permission pinfo = new Permission(0, "User", "info");


        public override string ToString()
        {
            return $"{lvl}.{NeedRole}.{CommandName}";
        }
    }
}
