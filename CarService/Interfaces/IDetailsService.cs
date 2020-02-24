using BusinessLogicLayer.Models;
using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    public interface IDetailsService
    {
        IEnumerable<DetailModel> GetDetails();
        void Create(DetailModel car);
        void Update(DetailModel car);
        void Delete(DetailModel car);
        DetailModel GetById(int id);


    }
}