using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable hashTable = new HashTable(7);

            Emp tom = new Emp(1, "tom");
            Emp zhangshan = new Emp(2, "zhangsan");
            Emp lisi = new Emp(8, "lisi");

            //添加
            hashTable.Add(tom);
            hashTable.Add(zhangshan);
            hashTable.Add(lisi);
            //hashTable.ShowHashTable();

            //查找
            hashTable.FindEmpById(8);

            Console.ReadLine();
        }
    }
}
