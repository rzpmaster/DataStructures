using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public class Emp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Emp Next { get; set; }
        public Emp(int id,string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
