using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Users.notific
{
    public class Noti
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }

        public Noti(int id, string text, string type)
        {
            Id = id;
            Text = text;
            Type = type;
        }
        public static Noti LoggedSeccues = new Noti(1, "Sikeres bejelentkezés", "Info");
        public static Noti LoggedFailed = new Noti(2, "Sikertelen bejelentkezés", "Error");
        public static Noti RegSeccues = new Noti(3, "Sikeres regisztráció", "Info");
        public static Noti RegFailed = new Noti(4, "Sikertelen regisztráció", "Error");

        public static List<Noti> DefaultNotis = new List<Noti>()
        {
            LoggedSeccues,
            LoggedFailed,
            RegSeccues,
            RegFailed
        };
        public static string SearchNoti(int id)
        {
            string ret = "Nincs ilyen értesítés";
            for (int i = 0; i < DefaultNotis.Count; i++)
            {
                if (DefaultNotis[i].Id == id)
                {
                    ret = DefaultNotis[i].Text;
                }
            }
            return ret;
        }
        public static string PictureChoice(string type)
        {
            string ret = "Nincs ilyen kép";
            if (type == "Info")
            {
                ret = "info.png";
            }
            else if (type == "Error")
            {
                ret = "error.png";
            }
            return ret;
        }
    }
}
