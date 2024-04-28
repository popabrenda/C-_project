using System.Collections.Generic;
using System.Data.SQLite;
using log4net;
using TripModel;
using Utils;

namespace TripPersistence
{
    public class RepositoryFirmaTransport : IRepositoryFirmaTransport
    {
        private UtilsDB _dbUtils;
        private static readonly ILog MyLogger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public RepositoryFirmaTransport(UtilsDB db)
        {
            this._dbUtils = db;
        }
    
        public Optional<FirmaTransport> Save(FirmaTransport entitate)
        {
            MyLogger.Info($"Salvare firma transport {entitate}");
            SQLiteConnection connection = _dbUtils.GetConnection();
            connection.Open();
            using (var cmd = new SQLiteCommand(connection))
            {
                cmd.CommandText = "INSERT INTO FirmeTransport(nume) VALUES (@nume)";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@nume", entitate.Nume);
                var linii = cmd.ExecuteNonQuery();
                var idInserat = (int)connection.LastInsertRowId;
                entitate.Id = idInserat;
                connection.Close();
                if (linii == 1)
                {
                    MyLogger.Info($"Firma transport {entitate} a fost salvata");
                    return Optional<FirmaTransport>.Of(entitate);
                }
                else
                {
                    MyLogger.Info($"Firma transport {entitate} nu a fost salvata");
                    return Optional<FirmaTransport>.Empty();
                }
            }
        }

        public Optional<FirmaTransport> Update(FirmaTransport entitate)
        {
            MyLogger.Info($"Update firma transport {entitate}");
            SQLiteConnection connection = _dbUtils.GetConnection();
            connection.Open();
            using (var cmd = new SQLiteCommand(connection))
            {
                cmd.CommandText = "UPDATE FirmeTransport SET nume = @nume WHERE id = @id";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", entitate.Id);
                cmd.Parameters.AddWithValue("@nume", entitate.Nume);
                var linii = cmd.ExecuteNonQuery();
                connection.Close();
                if (linii == 1)
                {
                    MyLogger.Info($"Firma transport {entitate} a fost updatata");
                    return Optional<FirmaTransport>.Of(entitate);
                }
                else
                {
                    MyLogger.Info($"Firma transport {entitate} nu a fost updatata");
                    return Optional<FirmaTransport>.Empty();
                }
            }
        }

        public Optional<FirmaTransport> FindOne(int id)
        {
            MyLogger.Info($"Cautare firma transport cu id {id}");
            SQLiteConnection connection = _dbUtils.GetConnection();
            connection.Open();
            using (var cmd = new SQLiteCommand(connection))
            {
                cmd.CommandText = "SELECT ID, NUME FROM FirmeTransport WHERE id = @id";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int idFirma = reader.GetInt32(0);
                        string numeFirma = reader.GetString(1);
                        FirmaTransport firma = new FirmaTransport(numeFirma);
                        firma.Id = idFirma;
                        MyLogger.Info($"Firma transport cu id-ul {id} a fost gasita");
                        connection.Close();
                        return Optional<FirmaTransport>.Of(firma);
                    }
                    else
                    {
                        connection.Close();
                        MyLogger.Info($"Firma transport cu id-ul {id} nu a fost gasita");
                        return Optional<FirmaTransport>.Empty();
                    }
                }
            }
        }

        public Optional<FirmaTransport> Delete(int id)
        {
            MyLogger.Info($"Stergere firma transport cu id {id}");
            var firma = FindOne(id);
            SQLiteConnection connection = _dbUtils.GetConnection();
            connection.Open();
            using (var cmd = new SQLiteCommand(connection))
            {
                cmd.CommandText = "DELETE FROM FirmeTransport WHERE id = @id";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", id);
                var deletedRows = cmd.ExecuteNonQuery();
                connection.Close();
                if (deletedRows == 0)
                {
                    MyLogger.Info($"Firma transport cu id-ul {id} nu a fost stearsa");
                    return Optional<FirmaTransport>.Empty();
                }
                else
                {
                    MyLogger.Info($"Firma transport cu id-ul {id} a fost stearsa");
                    return firma;
                }
            }
        }

        public List<FirmaTransport> FindAll()
        {
            MyLogger.Info("Cautare toate firmele de transport");
            SQLiteConnection connection = _dbUtils.GetConnection();
            connection.Open();
            List<FirmaTransport> firme = new List<FirmaTransport>();
            using (var cmd = new SQLiteCommand(connection))
            {
                cmd.CommandText = "SELECT ID, NUME FROM FirmeTransport";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int idFirma = reader.GetInt32(0);
                        string numeFirma = reader.GetString(1);
                        FirmaTransport firma = new FirmaTransport(numeFirma);
                        firma.Id = idFirma;
                        firme.Add(firma);
                    }
                }
            }
            connection.Close();
            return firme;
        }
    }
}