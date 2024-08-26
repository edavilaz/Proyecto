using Proyecto.Models;
using SQLite;

namespace Proyecto.Data
{

    //REVISAR
    public class UserDatabase
    {
        string _dbPath;
        public string StatusMessage { get; set; }

        private SQLiteConnection conn;

        private void Init()
        {
            if (conn is not null)
                return;
            conn = new(_dbPath);
            conn.CreateTable<User>();
        }

        public UserDatabase(string dbPath)
        {
            _dbPath = dbPath;
        }

        public void AddNewUser(string username)
        {
            int result = 0;
            try
            {
                Init();

                // validación básica
                if (string.IsNullOrEmpty(username))
                    throw new Exception("Valid username required");
                //creamos el nuevo usuario con el nombre que entra en username
                User user = new User() { Username = username };
                result = conn.Insert(user);

                // Obtenemos el id generado
                StatusMessage = string.Format("{0} record(s) added (Name: {1}", result, username);
            }
            catch (Exception ex)
            {

                StatusMessage = string.Format("Failed to add {0}. Error: {1}", username, ex.Message);
            }


        }

        public List<User> GetAllUsers()
        {
            try
            {
                Init();
                return conn.Table<User>().ToList();
            }
            catch (Exception ex)
            {

                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<User>();
        }

    }
}

