
using System;
using System.Collections.Generic;
using PoateAiciFunctioneaza.Domain;

namespace PoateAiciFunctioneaza.Repository
{
        
        public interface IRepository<ID, E> where E : Entity<ID>
        {
            void Add(E entity);
            void Remove(ID id);
            E Find(ID id);
            IEnumerable<E> GetAll();
            void Update(ID id, E newEntity);
            void SetAll(IEnumerable<E> entities);
        }
        public class RepositoryException:ApplicationException{
            public RepositoryException() { }
            public RepositoryException(String mess) : base(mess){}
            public RepositoryException(String mess, Exception e) : base(mess, e) { }
        }
       
    
    }


