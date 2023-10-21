using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace LocalDBMS
{
    internal static class DBmanager
    {

        internal static void loadDataBases()
        {
            DirectoryInfo d = new DirectoryInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data") );
            d.Create();
            FileInfo[] DBfiles = d.GetFiles("*.json");
            var jsonSerializerOptions = new JsonSerializerOptions();
            jsonSerializerOptions.Converters.Add(new SupportedTypeConverter());

            foreach (FileInfo dbf in DBfiles)
            {
                string json = File.ReadAllText(dbf.FullName);
                DataBase? db = JsonSerializer.Deserialize<DataBase>(json, jsonSerializerOptions);
                if (db != null)
                {
                    db.WasChanged = false;
                    Bases.Add(db);
                }
            }
            for(int i = 0; i < Bases.Count; i++)
                for(int j = 0; j < Bases[i].Tables.Count; j++)
                    Bases[i].Tables[j].Parent = Bases[i];
        }

        internal static void saveDataBases()
        {
            var jsonSerializerOptions = new JsonSerializerOptions();
            jsonSerializerOptions.Converters.Add(new SupportedTypeConverter());

            foreach (DataBase b in Bases)
                if(b.WasChanged)
                {
                    string json = JsonSerializer.Serialize(b, jsonSerializerOptions);
                    File.WriteAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", b.Name + ".json"), json);
                }
        }

        internal static List<DataTable> getAllTables()
        {
            List<DataTable> tables = new List<DataTable>();
            foreach(var db in Bases)
                foreach(var dt in db.Tables)
                    tables.Add(dt);
            return tables;
        }

        internal static void addDB(string name)
        {
            Bases.Add(new DataBase(name));
        }
        internal static void addDB(DataBase db)
        {
            Bases.Add(db);
        }

        internal static void removeDB(DataBase db)
        {
            Bases.Remove(db);
        }

        internal static List<DataBase> Bases = new List<DataBase>();
    }
}
