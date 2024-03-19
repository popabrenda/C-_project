using System;
using System.Collections.Generic;
using System.Data;
using log4net;
using PoateAiciFunctioneaza.Domain;

namespace PoateAiciFunctioneaza.Repository
{
    public class RezervareDBRepository:IRezervareRepository
    {
        private static readonly ILog log = LogManager.GetLogger("RezevareDBRepository");
        IDictionary<String, string> props;

        public RezervareDBRepository(IDictionary<String, string> props)
        {
            log.Info("Creating RezevareDBRepository ");
            this.props = props;
        }


        public void Add(Rezervare entity)
        {
            log.InfoFormat("Entering Add with value {0}", entity);
            IDbConnection con = DBUtils.getConnection(props);
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into Rezervari (id, idClient, idExcursie, nrBilete)  values (@id, @idClient, @idExcursie,@nrBilete)";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = entity.Id;
                comm.Parameters.Add(paramId);
                
                IDbDataParameter paramIdClient = comm.CreateParameter();
                paramIdClient.ParameterName = "@idClient"; 
                paramIdClient.Value = entity.client.Id;
                comm.Parameters.Add(paramIdClient);
                
                IDbDataParameter paramIdExcursie = comm.CreateParameter();
                paramIdExcursie.ParameterName = "@idExcursie";
                paramIdExcursie.Value = entity.excursie.Id;
                comm.Parameters.Add(paramIdExcursie);
                
                IDbDataParameter paramNrBilete = comm.CreateParameter();
                paramNrBilete.ParameterName = "@nrBilete";
                paramNrBilete.Value = entity.nrBilete;
                comm.Parameters.Add(paramNrBilete);
                
                var result = comm.ExecuteNonQuery();
                if (result == 0)
                {
                    log.InfoFormat("Exiting Add with value {0}", "A fost adaugat");
                    throw new RepositoryException("Nu a fost adaugat!");
                }
                log.InfoFormat("Exiting Add with value {0}", "A fost adaugat");
            }
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Rezervare Find(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rezervare> GetAll()
        {
            log.InfoFormat("Entering GetAll");
            IDbConnection con = DBUtils.getConnection(props);
            IList<Rezervare> rezervari = new List<Rezervare>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Rezervari";
                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int idRezervare = dataR.GetInt32(0);
                        int idClient = dataR.GetInt32(1);
                        int idExcursie = dataR.GetInt32(2);
                        int nrBilete = dataR.GetInt32(3);
                        ClientDBRepository clientDBRepository = new ClientDBRepository(props);
                        Client client = clientDBRepository.Find(idClient);
                        
                        ExcursieDBRepository excursieDBRepository = new ExcursieDBRepository(props);
                        Excursie excursie = excursieDBRepository.Find(idExcursie);
                        Rezervare rezervare = new Rezervare(idRezervare, client,excursie, nrBilete);
                        rezervari.Add(rezervare);
                    }
                }
            }
            log.InfoFormat("Exiting GetAll with value {0}", rezervari);
            return rezervari;
        }

        public void Update(int id, Rezervare newEntity)
        {
            throw new NotImplementedException();
        }

        public void SetAll(IEnumerable<Rezervare> entities)
        {
            throw new NotImplementedException();
        }
    }
}