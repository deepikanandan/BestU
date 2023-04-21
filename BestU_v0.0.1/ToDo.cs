using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestU_v0._0._1
{

    // ToDo Class
    // This is the base class for the two other types of todo's - Habits and Single ToDo's
    public class ToDo
    {
        public string Name { get; set; }
        public bool IsCompleted { get; set; }

        public ToDo(string _name)
        {
            Name = _name;
            IsCompleted = false;
        }
    }
}
