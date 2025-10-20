using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Logs
{
    internal class logs
    {

        public string Log { get; set; }
        public DateTime Time { get; set; }
        public logs(string log)
        {
            Log = log;
            Time = DateTime.Now;
        }
        public override string ToString()
        {
            return $"{Time} - {Log}";
        }
        //ha nem létezik akkor egy logs.txt-t kell létrehozni, ha pedig létre van hozva akkor hozzá kell fűzni a logokat
        //a chatet és a loginokat is ide mentem, illetve a regisztrációkat is, valamint a parancsokat is.
        //az Users.User.Act.ToString() -al lehet megjeleníteni a felhasználó nevét
        public static void SaveLog(string log, string username)
        {
            string directory = "Logs\\";
            string path = System.IO.Path.Combine(directory, "logs.txt");

            // Ensure the Logs directory exists
            if (!System.IO.Directory.Exists(directory))
            {
                System.IO.Directory.CreateDirectory(directory);
            }

            // Format the log to include the username
            string logEntry = $"{username} : {log} ";

            // Append the log entry to logs.txt, creating the file if it doesn't exist
            using (System.IO.StreamWriter sw = System.IO.File.AppendText(path))
            {
                sw.WriteLine(new logs(logEntry).ToString() + " ");
            }
        }
    }
}
