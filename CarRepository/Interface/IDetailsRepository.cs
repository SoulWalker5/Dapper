using DataAccessLayer.Models;
using System.Collections.Generic;

namespace DataAccessLayer.Interfaces
{
    public interface IDetailsRepository
    {
        Detail GetById(int id);
        IEnumerable<Detail> GetDetails();
        void Create(Detail detail);
        void Delete(int id);
        void Update(Detail detail);
    }
}
