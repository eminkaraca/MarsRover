using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Interface
{
    public interface IPlataeu
    {
        public int xRight { get; set; }
        public int xLeft { get; set; }
        public int yUpper { get; set; }
        public int yLower { get; set; }
    }
}
