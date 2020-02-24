using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public class Car
    {
        public Car()
        {
            Parts = new List<Detail>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Detail> Parts { get; set; }
    }
}
