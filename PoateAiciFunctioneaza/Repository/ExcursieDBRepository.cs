using System;
using System.Collections.Generic;
using System.Data;
using log4net;
using PoateAiciFunctioneaza.Domain;

namespace PoateAiciFunctioneaza.Repository
{
    public class ExcursieDBRepository : IExcursieRepository
    {
        private static readonly ILog log = LogManager.GetLogger("ExcursieDBRepository");
        IDictionary<String, string> props;

        public ExcursieDBRepository(IDictionary<String, string> props)
        {
            log.Info("Creating ExcursieDBRepository ");
            this.props = props;
        }

        public void Add(Excursie entity)
        {
            log.InfoFormat("Entering Add with value {0}", entity);
            IDbConnection con = DBUtils.getConnection(props);
            using (var comm = con.CreateCommand())
            {
                comm.CommandText =
                    "insert into Excursii (id,obiectiv,firmaTransport,oraPlecare,pret,locuriDisponibile)  values (@id,@obiectiv,@firmaTransport,@oraPlecare,@pret,@locuriDisponibile)";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = entity.Id;
                comm.Parameters.Add(paramId);

                IDbDataParameter paramObiectiv = comm.CreateParameter();
                paramObiectiv.ParameterName = "@obiectiv";
                paramObiectiv.Value = entity.obiectiv;
                comm.Parameters.Add(paramObiectiv);


                IDbDataParameter paramFirmaTransport = comm.CreateParameter();
                paramFirmaTransport.ParameterName = "@firmaTransport";
                paramFirmaTransport.Value = entity.firmaTransport;
                comm.Parameters.Add(paramFirmaTransport);

                IDbDataParameter paramOraPlecarii = comm.CreateParameter();
                paramOraPlecarii.ParameterName = "@oraPlecare";
                paramOraPlecarii.Value = entity.oraPlecare;
                comm.Parameters.Add(paramOraPlecarii);

                IDbDataParameter paramPret = comm.CreateParameter();
                paramPret.ParameterName = "@pret";
                paramPret.Value = entity.pret;
                comm.Parameters.Add(paramPret);

                IDbDataParameter paramLocuriDisponibile = comm.CreateParameter();
                paramLocuriDisponibile.ParameterName = "@locuriDisponibile";
                paramLocuriDisponibile.Value = entity.locuriDisponibile;
                comm.Parameters.Add(paramLocuriDisponibile);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                {
                    log.InfoFormat("Exiting Add with value {0}", "A fost adaugat");
                    throw new RepositoryException("Nu a fost adaugat!");
                }
            }

            log.InfoFormat("Exiting Add with value {0}", "A fost adaugat");

        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public Excursie Find(int id)
        {
            log.InfoFormat("Entering findOne with value {0}", id);
            IDbConnection con = DBUtils.getConnection(props);
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id,obiectiv,firmaTransport,oraPlecare, pret,locuriDisponibile from Excursii where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);
                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int idExcursie = dataR.GetInt32(0);
                        String obiectiv = dataR.GetString(1);
                        String firmaTransport = dataR.GetString(2);
                        int oraPlecare = dataR.GetInt32(3);
                        int pret = dataR.GetInt32(4);
                        int locuriDisponibile = dataR.GetInt32(5);
                        Excursie excursie = new Excursie(idExcursie, obiectiv, firmaTransport, oraPlecare, pret,
                            locuriDisponibile);
                        log.InfoFormat("Exiting findOne with value {0}", excursie);
                        return excursie;
                    }
                }
            }
            log.InfoFormat("Exiting findOne with value {0}", null);
            return null;
        }

        public IEnumerable<Excursie> GetAll()
        {
            log.InfoFormat("Entering GetAll");
            IDbConnection con = DBUtils.getConnection(props);
            IList<Excursie> excursii = new List<Excursie>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id,obiectiv,firmaTransport,oraPlecare, pret,locuriDisponibile from Excursii";
                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int id = dataR.GetInt32(0);
                        String obiectiv = dataR.GetString(1);
                        String firmaTransport = dataR.GetString(2);
                        int oraPlecare = dataR.GetInt32(3);
                        int pret = dataR.GetInt32(4);
                        int locuriDisponibile = dataR.GetInt32(5);
                        Excursie excursie = new Excursie(id, obiectiv, firmaTransport, oraPlecare, pret,
                            locuriDisponibile);
                        excursii.Add(excursie);
                    }
                }
            }
           
            log.InfoFormat("Exiting GetAll with value {0}", excursii);
            return excursii;
        }

        public void Update(int id, Excursie newEntity)
        {
            throw new System.NotImplementedException();
        }

        public void SetAll(IEnumerable<Excursie> entities)
        {
            throw new System.NotImplementedException();
        }
    }
}
