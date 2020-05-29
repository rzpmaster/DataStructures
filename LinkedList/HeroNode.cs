using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class HeroNode
    {
        public int No { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public HeroNode Next { get; set; }//指向下一个节点
        public HeroNode Pre { get; set; }

        public HeroNode(int no,string name,string nickname)
        {
            No = no;
            Name = name;
            Nickname = nickname;
            Next = null;
            Pre = null;
        }

        public override string ToString()
        {
            return string.Format("排名：{0}\t名字：{1}\t外号：{2}", No, Name, Nickname);
        }
    }
}
