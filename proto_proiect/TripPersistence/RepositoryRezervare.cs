using System.Collections.Generic;
using System.Data.SQLite;
using log4net;
using TripModel;
using Utils;


namespace TripPersistence
{
    public class RepositoryRezervare : IRepositoryRezervare
    {
        private UtilsDB _dbUtils;
        private IRepositoryExcursie _repoExcursie;
        private static readonly ILog MyLogger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public RepositoryRezervare(UtilsDB db, IRepositoryExcursie repoExcursie)
        {
            this._dbUtils = db;
            this._repoExcursie = repoExcursie;
        }
        public Optional<Rezervare> Save(Rezervare entitate)
        {
            MyLogger.Info($"Salvare rezervare {entitate}");
            SQLiteConnection connection = _dbUtils.GetConnection();
            connection.Open();
            using (var cmd = new SQLiteCommand(connection))
            {
                cmd.CommandText =
                    "INSERT INTO rezervari(NUME_CLIENT, TELEFON_CLIENT, NR_BILETE, ID_EXCURSIE) VALUES (@numeClient, @telefonClient, @numarBilete, @idExcursie)";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@numeClient", entitate.NumeClient);
                cmd.Parameters.AddWithValue("@telefonClient", entitate.TelefonClient);
                cmd.Parameters.AddWithValue("@idExcursie", entitate.Excursie.Id);
                cmd.Parameters.AddWithValue("@numarBilete", entitate.NumarBilete);
                var linii = cmd.ExecuteNonQuery();
                var idInserat = (int)connection.LastInsertRowId;
                entitate.Id = idInserat;
                connection.Close();
                if (linii == 1)
                {
                    MyLogger.Info($"Rezervarea {entitate} a fost salvata");
                    return Optional<Rezervare>.Of(entitate);
                }
                else
                {
                    MyLogger.Info($"Rezervarea {entitate} nu a fost salvata");
                    return Optional<Rezervare>.Empty();
                }
            }
        }

        public Optional<Rezervare> Update(Rezervare entitate)
        {
            MyLogger.Info($"Update rezervare {entitate}");
            SQLiteConnection connection = _dbUtils.GetConnection();
            connection.Open();
            using (var cmd = new SQLiteCommand(connection))
            {
                cmd.CommandText =
                    "UPDATE rezervari SET NUME_CLIENT = @numeClient, TELEFON_CLIENT = @telefonClient, ID_EXCURSIE = @idExcursie, NR_BILETE = @numarBilete WHERE id = @id";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", entitate.Id);
                cmd.Parameters.AddWithValue("@numeClient", entitate.NumeClient);
                cmd.Parameters.AddWithValue("@telefonClient", entitate.TelefonClient);
                cmd.Parameters.AddWithValue("@idExcursie", entitate.Excursie.Id);
                cmd.Parameters.AddWithValue("@numarBilete", entitate.NumarBilete);
                var linii = cmd.ExecuteNonQuery();
                connection.Close();
                if (linii == 1)
                {   
                    MyLogger.Info($"Rezervarea {entitate} a fost updatata");
                    return Optional<Rezervare>.Of(entitate);
                }
                else
                {
                
                    MyLogger.Info($"Rezervarea {entitate} nu a fost updatata");
                    return Optional<Rezervare>.Empty();
                }
            }
        }

        public Optional<Rezervare> FindOne(int id)
        {
            MyLogger.Info($"Cautare rezervare cu id {id}");
            SQLiteConnection connection = _dbUtils.GetConnection();
            connection.Open();
            using (var cmd = new SQLiteCommand(connection))
            {
                cmd.CommandText = "SELECT ID, NUME_CLIENT, TELEFON_CLIENT, ID_EXCURSIE, NR_BILETE FROM rezervari WHERE id = @id";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        MyLogger.Info($"Rezervarea cu id-ul {id} a fost gasita");
                        var idRezervare = reader.GetInt32(0);
                        var numeClient = reader.GetString(1);
                        var telefonClient = reader.GetString(2);
                        var idExcursie = reader.GetInt32(3);
                        var nrBilete = reader.GetInt32(4);
                        connection.Close();
                        var excursie = _repoExcursie.FindOne(idExcursie).Value;
                        var rezervare = new Rezervare(numeClient, telefonClient, excursie, nrBilete);
                        rezervare.Id = idRezervare;
                        return Optional<Rezervare>.Of(rezervare);
                    }
                    else
                    {
                        connection.Close();
                        MyLogger.Info($"Rezervarea cu id-ul {id} nu a fost gasita");
                        return Optional<Rezervare>.Empty();
                    }
                }
            }
        }

        public Optional<Rezervare> Delete(int id)
        {
            MyLogger.Info($"Stergere rezervare cu id {id}");
            SQLiteConnection connection = _dbUtils.GetConnection();
            var rezervare = FindOne(id);
            connection.Open();
            using (var cmd = new SQLiteCommand(connection))
            {
                cmd.CommandText = "DELETE FROM rezervari WHERE id = @id";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", id);
                var linii = cmd.ExecuteNonQuery();
                connection.Close();
                if (linii == 0)
                {
                    MyLogger.Info($"Rezervarea cu id-ul {id} nu a fost stearsa");
                    return Optional<Rezervare>.Empty();
                }
                else
                {
                    MyLogger.Info($"Rezervarea cu id-ul {id} a fost stearsa");
                    return rezervare;
                }
            }
        }

        public List<Rezervare> FindAll()
        {
            MyLogger.Info("Find all rezervari");
            var listaExcursii = _repoExcursie.FindAll();
            SQLiteConnection connection = _dbUtils.GetConnection();
            connection.Open();
            List<Rezervare> rezervari = new List<Rezervare>();
            using (var cmd = new SQLiteCommand(connection))
            {
                cmd.CommandText = "SELECT ID, NUME_CLIENT, TELEFON_CLIENT, ID_EXCURSIE, NR_BILETE FROM rezervari";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var idRezervare = reader.GetInt32(0);
                        var numeClient = reader.GetString(1);
                        var telefonClient = reader.GetString(2);
                        var idExcursie = reader.GetInt32(3);
                        var nrBilete = reader.GetInt32(4);
                        var excursie1 = listaExcursii.Find(excursie => excursie.Id == idExcursie);
                        var rezervare = new Rezervare(numeClient, telefonClient, excursie1, nrBilete);
                        rezervare.Id = idRezervare;
                        rezervari.Add(rezervare);
                    }
                }
            }
            connection.Close();
            return rezervari;
        }

        public int GetNumarOcupate(int excursieId)
        {
            MyLogger.Info($"Get numar ocupate pentru excursia cu id-ul {excursieId}");
            SQLiteConnection connection = _dbUtils.GetConnection();
            connection.Open();
            using (var cmd = new SQLiteCommand(connection))
            {
                cmd.CommandText = "SELECT SUM(NR_BILETE) FROM rezervari WHERE ID_EXCURSIE = @idExcursie";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@idExcursie", excursieId);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        if (reader.IsDBNull(0))
                        {
                            connection.Close();
                            return 0;
                        }
                        var numarOcupate = reader.GetInt32(0);
                        connection.Close();
                        return numarOcupate;
                    }
                    else
                    {
                        connection.Close();
                        return 0;
                    }
                }
            }
        }
    }
}