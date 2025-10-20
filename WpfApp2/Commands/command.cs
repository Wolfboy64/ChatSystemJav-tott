using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Users.Permissions;

namespace WpfApp2.Commands
{
    internal class command
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Users.Permissions.Permission Permissions { get; set; }

        public command(string name, string description, Users.Permissions.Permission permission )
        {
            Name = name;
            Description = description;
            Permissions = permission;
        }
        public static command help = new command("/help", "Shows all commands", Permission.phelp);

        List<string> ExecutedCommands = new List<string>();
        public void Execute(command cmd, string argument)
        {
            ExecutedCommands.Add($"{cmd.ToString()} {argument}");
            if (ExecutedCommands.Count >= 0)
            {
                for (int i = 0; i < ExecutedCommands.Count; i++)
                {
                    Logs.logs.SaveLog(ExecutedCommands[i], Users.User.Act.Name);
                }
            }
            
        }


        public override string ToString()
        {
            return $"{Name}.{Description}.{Permissions}";
        }
    }
}
