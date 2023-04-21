using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestU_v0._0._1
{
    public class SingleToDo : ToDo
    {
        public DateTime DueDate { get; set; }

        public SingleToDo(string _name, DateTime _dueDate) : base(_name)
        {
            DueDate = _dueDate;
        }

        public SingleToDo(string _name): base(_name)
        {
            DueDate = DateTime.Today;
        }
    }
}

