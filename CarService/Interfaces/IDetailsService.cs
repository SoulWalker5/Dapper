using BusinessLogicLayer.Models;
using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    public interface IDetailsService
    {
        IEnumerable<DetailModel> GetDetails();
        void Create(DetailModel car);
        void Update(DetailModel car);
        void Delete(int id);
        DetailModel GetById(int id);
    }
}