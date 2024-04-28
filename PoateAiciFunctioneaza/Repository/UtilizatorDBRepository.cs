

using System;
using System.Data;
using System.Collections.Generic;
using log4net;
using Problema6_mpp.Repository;
using PoateAiciFunctioneaza.Domain;
using PoateAiciFunctioneaza.Repository;

namespace Problema6_mpp.Repository
{
    public class UtilizatorDBRepository : IUtilizatorReposiroty
    {
        private static readonly ILog log = LogManager.GetLogger("UtilizatorDBRepository");
        IDictionary<String, string> props;

        public UtilizatorDBRepository(IDictionary<String, string> props)
        {
            log.Info("Creating UtilizatorDBRepository ");
            this.props = props;
        }

        public void Add(Utilizator entity)
        {
            log.InfoFormat("Entering Add with value {0}", entity);
            IDbConnection con = DBUtils.getConnection(props);

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into Utilizatori (username,password)  values (@username,@password)";
                
                IDbDataParameter paramUsername = comm.CreateParameter();
                paramUsername.ParameterName = "@username";
                paramUsername.Value = entity.username;
                comm.Parameters.Add(paramUsername);

                IDbDataParameter paramPassword = comm.CreateParameter();
                paramPassword.ParameterName = "@password";
                paramPassword.Value = entity.password;
                comm.Parameters.Add(paramPassword);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                {
                    throw new RepositoryException("Nu a fost adaugat!");
                }
            }

            log.InfoFormat("Exiting Add with value {0}", "A fost adaugat");
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Utilizator Find(int id)
        {
            log.InfoFormat("Entering findOne with value {0}", id);
            IDbConnection con = DBUtils.getConnection(props);

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select username,password from Utilizatori where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int idU = dataR.GetInt32(0);
                        String username = dataR.GetString(1);
                        String password = dataR.GetString(2);
                        Utilizator utilizator = new Utilizator(username, password);
                        utilizator.Id = idU;
                        log.InfoFormat("Exiting findOne with value {0}", utilizator);
                        return utilizator;
                    }
                }
            }
            log.InfoFormat("Exiting findOne with value {0}", null);
            return null;
        }

        public IEnumerable<Utilizator> GetAll()
        {
            log.InfoFormat("Entering findAll");
            IDbConnection con = DBUtils.getConnection(props);
            IList<Utilizator> utilizatori = new List<Utilizator>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id,username,password from Utilizatori";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int idV = dataR.GetInt32(0);
                        String username = dataR.GetString(1);
                        String password = dataR.GetString(2);
                        Utilizator utilizator = new Utilizator(username, password);
                        utilizator.Id = idV;
                        utilizatori.Add(utilizator);
                    }
                }
            }

            log.InfoFormat("Exiting findAll with value {0}", utilizatori);
            return utilizatori;
        }

        public void Update(int id, Utilizator newEntity)
        {
            throw new NotImplementedException();
        }

        public void SetAll(IEnumerable<Utilizator> entities)
        {
            throw new NotImplementedException();
        }
    }
}
    
