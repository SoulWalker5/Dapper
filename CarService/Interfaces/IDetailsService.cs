using BusinessLogicLayer.Models;
using System.Collections.Generic;

namespace BusinessLogicLayer.Interfaces
{
    public interface IDetailsService
    {
        IEnumerable<DetailModel> GetDetails();
    }
}