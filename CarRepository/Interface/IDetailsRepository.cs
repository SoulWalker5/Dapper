using DataAccessLayer.Models;
using System.Collections.Generic;

namespace DataAccessLayer.Interfaces
{
    public interface IDetailsRepository
    {
        Detail GetById(int id);
        IEnumerable<Detail> GetDetails();
        void Create(Detail detail);
        void Delete(Detail detail);
        void Update(Detail detail);
    }
}
