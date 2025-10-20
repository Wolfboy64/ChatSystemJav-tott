using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace WpfApp2.Users
{
    internal class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Roles.Role Roll { get; set; }
        public User(int id, string name, string password, Roles.Role roll)
        {
            Id = id;
            Name = name;
            Password = password;
            Roll = roll;
        }

        public static User first = new User(1, "Admin", "Admin", Roles.Role.r5);
        public static User Secondary = new User(2, "Admin2", "Admin2", Roles.Role.r5);

        //lista index alapján teszem egyenlővé az Act-ot, hogy a chaten  megjelenjen a rang
        public static User Act;
        
        
        
        public static int a;



        public static List<User> users = new List<User>() {first, Secondary};

        

        public int IDCheck(User b) 
        {
            
            int ret = 0;
            if (b.Id != null)
            {
                int c_ = users.Count;
                int d_ = c_ - 1;
                int e_ = d_ + 1;
                b.Id = e_;
                    
                
            }
            

                return ret;          
        }
        List<string> names = new List<string>() { "Jhon", "Sam", "Rob", "Peter" };
        private string NameRepair(User c, List<string> strs) 
        {
            string ret = "Ismeretlen";
            Random r = new Random();
            int v = r.Next(0, strs.Count);
            if (c.Name == null)
            {
                c.Name = strs[v];
                ret = c.Name;
            }
            else
            {
                ret = c.Name;
            }

            return ret;
        }
        public static bool Ret = false;
      
        public static void RoleCheck() 
        {

            string s_ = "";
            for (int i = 0; i < users.Count; i++)
            {
                s_ = users[i].Roll.Name ;
            }
            Act.Roll.Name = s_;

            for (int i = 0; i < Roles.Role.roles.Count; i++)
            {
                if (Roles.Role.roles[i].Name == s_)
                {
                    Act.Roll = Roles.Role.roles[i];
                }
            }
        }
        public void LoginCheck(User d)
        {
            
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Name == d.Name && users[i].Password == d.Password)
                {
                    users[i].Password = d.Password;
                    users[i].Name = d.Name;
                    users[i].Id = IDGenerate(User.users);

                    Ret = true;
                    break;
                }
            }
            
        }
        public static int IDGenerate(List<User> a) 
        {
            int ret = 0;
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i].Id != i + 1)
                {
                    ret = i + 1;
                }
            }
            return ret;
        }

        public bool RegisterCheck(User e) 
        {
            bool ret = false;
            if (e != null)
            {
                e.Id = IDGenerate(users);
                e.Name = NameRepair(e, names);
                users.Add(e);
                ret = true;
                Act = e;
            }
            else { ret = false; }
            return ret;
        }
        //ha a user 5 percig nem csinál semmit akkor kijelentkeztetem
        public static DateTime time = DateTime.Now;
        public static void AutoLogout() 
        {
            DateTime now = DateTime.Now;
            TimeSpan difference = now - time;
            if (difference.TotalMinutes >= 1) 
            {
                Act = null;
            }
        }
        //ezen az elérési úton legyen egy registeredusers. txt: C:\Users\Richárd\source\repos\WpfApp2\WpfApp2\Users\RegisteredUsers\ amibe mentve van az összes regisztrált user
        public static string path = System.IO.Path.Combine("Users", "RegisteredUsers", "registeredusers.txt"); //Comlbine jelentése: összekapcsol
        public static void SaveUsersToFile() 
        {
            List<string> lines = new List<string>();
            //ha nem létezik akkor létrehozza a fájlt
            string directory = System.IO.Path.GetDirectoryName(path);
            if (!System.IO.Directory.Exists(directory))
            {
                System.IO.Directory.CreateDirectory(directory);
            }
            else
            {
                foreach (var user in users)
                {
                    string s_ = Convert.ToBase64String(Encoding.UTF8.GetBytes(user.Password));
                    string line = $"{user.Id}; {user.Name}; {s_.ToString()}; {user.Roll.Name};";
                    lines.Add(line);
                }
                System.IO.File.WriteAllLines(path, lines);
            }
        }


        public override string ToString()
        {
            return $"Id: {Id} Role: <{Roll.ToString()}>  Name: {Name} ";
        }
    }
}
