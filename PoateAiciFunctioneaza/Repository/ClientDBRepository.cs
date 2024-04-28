using System;
using System.Collections.Generic;
using System.Data;
using log4net;
using PoateAiciFunctioneaza.Domain;


namespace PoateAiciFunctioneaza.Repository
{
    
    public class ClientDBRepository : IClientRepository
    {
        private static readonly ILog log = LogManager.GetLogger("ClientDBRepository");
        IDictionary<String, string> props;

        public ClientDBRepository(IDictionary<String, string> props)
        {
            log.Info("Creating ClientDBRepository ");
            this.props = props;
        }

        public void Add(Client entity)
        {
            log.InfoFormat("Entering Add with value {0}", entity);
            IDbConnection con = DBUtils.getConnection(props);

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = 
                    "insert into Clienti (nume,nrTelefon)  values (@nume,@nrTelefon)";
               
                IDbDataParameter paramNume = comm.CreateParameter();
                paramNume.ParameterName = "@nume";
                paramNume.Value = entity.nume;
                comm.Parameters.Add(paramNume);

                IDbDataParameter parmNrTelefon = comm.CreateParameter();
                parmNrTelefon.ParameterName = "@nrTelefon";
                parmNrTelefon.Value = entity.nrTelefon;
                comm.Parameters.Add(parmNrTelefon);

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

        public Client Find(int id)
        {
            log.InfoFormat("Entering Find with value {0}", id);
            IDbConnection con = DBUtils.getConnection(props);
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id,nume,nrTelefon from Clienti where id=@id";
                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);
                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int idClient = dataR.GetInt32(0);
                        String nume = dataR.GetString(1);
                        String nrTelefon = dataR.GetString(2);
                        Client client = new Client(nume, nrTelefon);
                        client.Id = idClient;
                        log.InfoFormat("Exiting Find with value {0}", client);
                        client.Id = idClient;
                        if (client != null)
                             return client;
                    }
                }
            }

            return null;
        }
        

        public IEnumerable<Client> GetAll()
        {
            log.InfoFormat("Entering findAll");
            IDbConnection con = DBUtils.getConnection(props);
            IList<Client> clienti = new List<Client>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id,nume,nrTelefon from Clienti";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int idClient = dataR.GetInt32(0);
                        string nume = dataR.GetString(1);
                        string nrTelefon = dataR.GetString(2);
                        Client client = new Client(nume, nrTelefon);
                        client.Id = idClient;
                        clienti.Add(client);
                    }
                }
            }

            log.InfoFormat("Exiting findAll with value {0}", clienti);
            return clienti;
        }

        public void Update(int id, Client newEntity)
        {
            throw new NotImplementedException();
        }
        
        public void SetAll(IEnumerable<Client> entities)
        {
            throw new NotImplementedException();
        }
    }
}
