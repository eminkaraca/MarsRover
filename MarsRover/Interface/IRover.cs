using MarsRover.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Interface
{
    public interface IRover
    {
       public IPlataeu plateau { get; set; }
       public Heading heading { get; set; }
        public Coordinate coordinate { get; set; }

        void Start(string command);
        string GetPosition();
    }
}
