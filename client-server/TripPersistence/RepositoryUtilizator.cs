using System;
using System.Collections.Generic;
using System.Data.SQLite;
using log4net;
using TripModel;
using Utils;

namespace TripPersistence
{
    public class RepositoryUtilizator : IRepositoryUtilizator
    {
        private UtilsDB _dbUtils;
        private static readonly ILog MyLogger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    
        public RepositoryUtilizator(UtilsDB db)
        {
            this._dbUtils = db;
        }
    
        public Optional<Utilizator> Save(Utilizator entitate)
        {
            MyLogger.Info($"Salvare utilizator {entitate}");
            SQLiteConnection connection = _dbUtils.GetConnection();
            connection.Open();
            using (var cmd = new SQLiteCommand(connection))
            {
                cmd.CommandText =
                    "INSERT INTO utilizatori (nume, username, password) VALUES (@nume, @username, @password)";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@nume", entitate.Nume);
                cmd.Parameters.AddWithValue("@username", entitate.Username);
                cmd.Parameters.AddWithValue("@password", entitate.Password);
                var linii = cmd.ExecuteNonQuery();
                var idInserat = (int)connection.LastInsertRowId;
                entitate.Id = idInserat;
                connection.Close();
                if (linii == 1)
                {
                    MyLogger.Info($"Utilizatorul {entitate} a fost salvat");
                    return Optional<Utilizator>.Of(entitate);
                }
                else
                {
                    MyLogger.Info($"Utilizatorul {entitate} nu a fost salvat");
                    return Optional<Utilizator>.Empty();
                }
            
            }
        }

        public Optional<Utilizator> Update(Utilizator entitate)
        {
            MyLogger.Info($"Update utilizator {entitate}");
            SQLiteConnection connection = _dbUtils.GetConnection();
            connection.Open();
            using (var cmd = new SQLiteCommand(connection))
            {
                cmd.CommandText =
                    "UPDATE utilizatori SET nume = @nume, username = @username, password = @password WHERE id = @id";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", entitate.Id);
                cmd.Parameters.AddWithValue("@nume", entitate.Nume);
                cmd.Parameters.AddWithValue("@username", entitate.Username);
                cmd.Parameters.AddWithValue("@password", entitate.Password);
                var linii = cmd.ExecuteNonQuery();
                connection.Close();
                if (linii == 1)
                {
                    MyLogger.Info($"Utilizatorul {entitate} a fost updatat");
                    return Optional<Utilizator>.Of(entitate);
                }
                else
                {
                    MyLogger.Info($"Utilizatorul {entitate} nu a fost updatat");
                    return Optional<Utilizator>.Empty();
                }
            }
        }

        public Optional<Utilizator> FindOne(int id)
        {
            MyLogger.Info($"Cautare utilizator cu id {id}");
            SQLiteConnection connection = _dbUtils.GetConnection();
            connection.Open();
            using (var cmd = new SQLiteCommand(connection))
            {
                cmd.CommandText = "SELECT * FROM utilizatori WHERE id = @id";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        MyLogger.Info($"Utilizatorul cu id {id} a fost gasit");
                        var user =  new Utilizator(reader.GetString(1), reader.GetString(2), reader.GetString(3));
                        user.Id = reader.GetInt32(0);
                        connection.Close();
                        return Optional<Utilizator>.Of(user);
                    }
                    else
                    {
                        MyLogger.Info($"Utilizatorul cu id {id} nu a fost gasit");
                        connection.Close();
                        return Optional<Utilizator>.Empty();
                    }
                }
            }
        }

        public Optional<Utilizator> Delete(int id)
        {
            MyLogger.Info($"Stergere utilizator cu id {id}");
            var user = FindOne(id);
            SQLiteConnection connection = _dbUtils.GetConnection();
            connection.Open();
            using (var cmd = new SQLiteCommand(connection))
            {
                cmd.CommandText = "DELETE FROM utilizatori WHERE id = @id";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", id);
                var deletedRows = cmd.ExecuteNonQuery();
                connection.Close();
                if (deletedRows == 0)
                {
                    MyLogger.Info($"Utilizatorul cu id {id} nu a fost sters");
                    return Optional<Utilizator>.Empty();
                }
                else
                {
                    MyLogger.Info($"Utilizatorul cu id {id} a fost sters");
                    return user;
                }
            }
        }

        public List<Utilizator> FindAll()
        {
            MyLogger.Info("Find all utilizatori");
            SQLiteConnection connection = _dbUtils.GetConnection();
            connection.Open();
            List<Utilizator> utilizatori = new List<Utilizator>();
            using (var cmd = new SQLiteCommand(connection))
            {
                cmd.CommandText = "SELECT ID, NUME, USERNAME, PASSWORD FROM utilizatori";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var user = new Utilizator(reader.GetString(1), reader.GetString(2), reader.GetString(3));
                        user.Id = reader.GetInt32(0);
                        utilizatori.Add(user);
                    }
                }
            }
            connection.Close();
            return utilizatori;
        }

        public Optional<Utilizator> FindUtilizatorByUsername(string username)
        {
            MyLogger.Info($"Cautare utilizator cu username {username}");
            Console.WriteLine("RepoUtilizator cauta dupa username" + username);
            SQLiteConnection connection = _dbUtils.GetConnection();
            connection.Open();
            using (var cmd = new SQLiteCommand(connection))
            {
                cmd.CommandText = "SELECT * FROM utilizatori WHERE username = @username";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@username", username);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        MyLogger.Info($"Utilizatorul cu username {username} a fost gasit");
                        var user = new Utilizator(reader.GetString(1), reader.GetString(2), reader.GetString(3));
                        user.Id = reader.GetInt32(0);
                        connection.Close();
                        Console.WriteLine("RepoUtilizator gasit" + user);
                        return Optional<Utilizator>.Of(user);
                    }
                    else
                    {
                        MyLogger.Info($"Utilizatorul cu username {username} nu a fost gasit");
                        connection.Close();
                        return Optional<Utilizator>.Empty();
                    }
                }
            }
        }
    }
}