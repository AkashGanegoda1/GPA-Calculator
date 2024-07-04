using System.Data.SQLite;
using System.IO;
using System.Reflection;
using System.Linq;

namespace GPA_Calculator
{
    internal class Database_Connection
    {
        public SQLiteConnection con;
        public SQLiteCommand cmd;
        public SQLiteDataReader dr;

        public Database_Connection()
        {
            string appDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string dbFilePath = Directory.GetFiles(appDirectory, "*.db").FirstOrDefault();
            if (string.IsNullOrEmpty(dbFilePath))
            {
                throw new FileNotFoundException("No .db file found in the application directory.");
            }
            con = new SQLiteConnection($"Data Source={dbFilePath};Version=3;BusyTimeout=100000;");

        }
    }
}
