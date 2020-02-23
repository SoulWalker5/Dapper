using DataAccessLayer.Models;
using System.Collections.Generic;

namespace DataAccessLayer.Interfaces
{
    public interface IDetailsRepository
    {
        IEnumerable<Detail> GetDetails();
        void Create(Detail detail);
        void Delete(Detail detail);
        void Update(Detail detail);
        Detail GetCar(int id);
    }
}
