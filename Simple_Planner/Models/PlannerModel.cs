using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Planner.Models
{
    internal class PlannerModel
    {
        public DateTime CreationDate { get; set; } = DateTime.Now;

        private bool _IsDone;
        private string _Text;

        public bool IsDone 
        { 
            get { return _IsDone; }
            set { _IsDone = value; }
        }
        public string Text
        {
            get { return _Text; }
            set { _Text = value; }
        }
    }
}
