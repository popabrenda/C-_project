using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using log4net;
using TripModel;
using Utils;

namespace TripPersistence
{
    public class RepositoryExcursie : IRepositoryExcursie
    {
        private static readonly ILog MyLogger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private UtilsDB _dbUtils;
        private IRepositoryFirmaTransport _repositoryFirmaTransport;
    
        public RepositoryExcursie(UtilsDB db, IRepositoryFirmaTransport repositoryFirmaTransport)
        {
            this._dbUtils = db;
            this._repositoryFirmaTransport = repositoryFirmaTransport;
        }
    
        public Optional<Excursie> Save(Excursie entitate)
        {
            MyLogger.Info($"Salvare excursie {entitate}");
            SQLiteConnection connection = _dbUtils.GetConnection();
            connection.Open();
            using (var cmd = new SQLiteCommand(connection))
            {
                cmd.CommandText = "INSERT INTO Excursii(OBIECTIV_TURISTIC, PRET, NR_LOCURI, ORA_PLECARII, ID_FIRMA_TRANSPORT) VALUES (@obiectiv, @pret, @nrLocuri, @oraPlecare, @idFirmaTransport)";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@obiectiv", entitate.ObiectivTuristic);
                cmd.Parameters.AddWithValue("@pret", entitate.Pret);
                cmd.Parameters.AddWithValue("@nrLocuri", entitate.NumarLocuriTotale);
                cmd.Parameters.AddWithValue("@oraPlecare", entitate.OraPlecarii);
                cmd.Parameters.AddWithValue("@idFirmaTransport", entitate.FirmaTransport.Id);
                var linii = cmd.ExecuteNonQuery();
                int id = (int)connection.LastInsertRowId;
                entitate.Id = id;
                connection.Close();
                if (linii == 0)
                {
                    MyLogger.Info($"Excursia {entitate} nu a fost salvata");
                    return Optional<Excursie>.Empty();
                }
                else
                {
                    MyLogger.Info($"Excursia {entitate} nu a fost salvata");
                    return Optional<Excursie>.Of(entitate);
                }
            }
        }

        public Optional<Excursie> Update(Excursie entitate)
        {
            MyLogger.Info($"Update excursie {entitate}");
            SQLiteConnection connection = _dbUtils.GetConnection();
            connection.Open();
            using (var cmd = new SQLiteCommand(connection))
            {
                cmd.CommandText = "UPDATE Excursii SET OBIECTIV_TURISTIC = @obiectiv, PRET = @pret, NR_LOCURI = @nrLocuri, ORA_PLECARII = @oraPlecare, ID_FIRMA_TRANSPORT = @idFirmaTransport WHERE ID = @id";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", entitate.Id);
                cmd.Parameters.AddWithValue("@obiectiv", entitate.ObiectivTuristic);
                cmd.Parameters.AddWithValue("@pret", entitate.Pret);
                cmd.Parameters.AddWithValue("@nrLocuri", entitate.NumarLocuriTotale);
                cmd.Parameters.AddWithValue("@oraPlecare", entitate.OraPlecarii);
                cmd.Parameters.AddWithValue("@idFirmaTransport", entitate.FirmaTransport.Id);
                var linii = cmd.ExecuteNonQuery();
                connection.Close();
                if (linii == 1)
                {
                    MyLogger.Info($"Excursia {entitate} a fost updatata");
                    return Optional<Excursie>.Of(entitate);
                }
                else
                {
                    MyLogger.Info($"Excursia {entitate} nu a fost updatata");
                    return Optional<Excursie>.Empty();
                }
            }
        }

        public Optional<Excursie> FindOne(int id)
        {
            MyLogger.Info($"Cautare excursie cu id-ul {id}");
            SQLiteConnection connection = _dbUtils.GetConnection();
            connection.Open();
            using (var cmd = new SQLiteCommand(connection))
            {
                cmd.CommandText = "SELECT ID, OBIECTIV_TURISTIC, PRET, NR_LOCURI, ORA_PLECARII, ID_FIRMA_TRANSPORT FROM Excursii WHERE ID = @id";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var idFirmaTransport = reader.GetInt32(5);
                        var excursie = new Excursie(reader.GetString(1), null, TimeSpan.Parse(reader.GetString(4)), reader.GetDouble(2), reader.GetInt32(3));
                        excursie.Id = reader.GetInt32(0);
                        connection.Close();
                        var firmaTransport = _repositoryFirmaTransport.FindOne(idFirmaTransport).Value;
                        excursie.FirmaTransport = firmaTransport;
                        MyLogger.Info($"Excursia cu id-ul {id} a fost gasita");
                        return Optional<Excursie>.Of(excursie);
                    }
                    else
                    {
                        MyLogger.Info($"Excursia cu id-ul {id} nu a fost gasita");
                        return Optional<Excursie>.Empty();
                    }
                }
            }
        }

        public Optional<Excursie> Delete(int id)
        {
            MyLogger.Info($"Stergere excursie cu id-ul {id}");
            SQLiteConnection connection = _dbUtils.GetConnection();
            var excursie = FindOne(id);
            connection.Open();
            using (var cmd = new SQLiteCommand(connection))
            {
                cmd.CommandText = "DELETE FROM Excursii WHERE ID = @id";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@id", id);
                var linii = cmd.ExecuteNonQuery();
                connection.Close();
                if (linii == 0)
                {
                    MyLogger.Info($"Excursia cu id-ul {id} nu a fost stearsa");
                    return Optional<Excursie>.Empty();
                }
                else
                {
                    MyLogger.Info($"Excursia cu id-ul {id} a fost stearsa");
                    return excursie;
                }
            }
        }

        public List<Excursie> FindAll()
        {
            MyLogger.Info("Cautare toate excursiile");
            var listaFirmeTransport = _repositoryFirmaTransport.FindAll();
            SQLiteConnection connection = _dbUtils.GetConnection();
            connection.Open();
            using (var cmd = new SQLiteCommand(connection))
            {
                cmd.CommandText = "SELECT ID, OBIECTIV_TURISTIC, PRET, NR_LOCURI, ORA_PLECARII, ID_FIRMA_TRANSPORT FROM Excursii";
                using (var reader = cmd.ExecuteReader())
                {
                    var listaExcursii = new List<Excursie>();
                    while (reader.Read())
                    {
                        var idFirmaTransport = reader.GetInt32(5);
                        var excursie = new Excursie(reader.GetString(1), null, TimeSpan.Parse(reader.GetString(4)), reader.GetDouble(2), reader.GetInt32(3));
                        excursie.Id = reader.GetInt32(0);
                        var firmaTransport = listaFirmeTransport.Find(firma => firma.Id == idFirmaTransport);
                        excursie.FirmaTransport = firmaTransport;
                        listaExcursii.Add(excursie);
                    }
                    connection.Close();
                    return listaExcursii;
                }
            }
        }

        public List<Excursie> FindExcursieByFilter(string obiectivTuristic, TimeSpan deLa, TimeSpan panaLa)
        {
            MyLogger.Info(
                $"Cautare excursii cu obiectivul turistic {obiectivTuristic} si ora de plecare intre {deLa} si {panaLa}");
            var listaFirmeTransport = _repositoryFirmaTransport.FindAll();
            SQLiteConnection connection = _dbUtils.GetConnection();
            connection.Open();
            using (var cmd = new SQLiteCommand(connection))
            {
                cmd.CommandText =
                    "SELECT ID, OBIECTIV_TURISTIC, PRET, NR_LOCURI, ORA_PLECARII, ID_FIRMA_TRANSPORT FROM Excursii WHERE OBIECTIV_TURISTIC like @obiectiv AND ORA_PLECARII BETWEEN @deLa AND @panaLa";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@obiectiv", '%' + obiectivTuristic + '%');
                cmd.Parameters.AddWithValue("@deLa", deLa.ToString());
                cmd.Parameters.AddWithValue("@panaLa", panaLa.ToString());
                using (var reader = cmd.ExecuteReader())
                {
                    var listaExcursii = new List<Excursie>();
                    while (reader.Read())
                    {
                        var idFirmaTransport = reader.GetInt32(5);
                        var excursie = new Excursie(reader.GetString(1), null, TimeSpan.Parse(reader.GetString(4)),
                            reader.GetDouble(2), reader.GetInt32(3));
                        excursie.Id = reader.GetInt32(0);
                        var firmaTransport = listaFirmeTransport.Find(firma => firma.Id == idFirmaTransport);
                        excursie.FirmaTransport = firmaTransport;
                        listaExcursii.Add(excursie);
                    }

                    connection.Close();
                    return listaExcursii;
                }
            }
        }
    }
}