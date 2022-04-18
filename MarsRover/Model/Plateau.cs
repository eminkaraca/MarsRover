using MarsRover.Interface;
using System;

namespace MarsRover.Model
{
    public class Plateau : IPlataeu
    {
        public int xRight { get; set; }
        public int xLeft { get; set; }
        public int yUpper { get; set; }
        public int yLower { get; set; }

        /// <summary>
        /// Create a new Palataeu on mars 
        /// left lower coordinates are 0,0 
        /// right upper coordinates are taken from parameters
        /// </summary>
        /// <param name="xCoordinate"> X coordinate of right upper corner of plataeu</param>
        /// <param name="yCoordinate"> Y coordinate of right upper corner of plataeu</param>
        public Plateau(int xCoordinate, int yCoordinate) {

            xRight = xCoordinate;
            yUpper = yCoordinate;
            xLeft = 0;
            yLower = 0;

            // check id uppur right coordinates are above point 0,0
            if (xRight < 0 || yUpper < 0)
                throw new ArgumentException(string.Format("plataeu upeer right corner's coordinates shoud be greater than 0. X Coordinate: {0}, Y Coordinate: {1}", xCoordinate, yCoordinate));

        }

        /// <summary>
        /// Create a new Palataeu on mars 
        /// left lower coordinates are 0,0 
        /// right upper coordinates are taken from parameters
        /// </summary>
        /// <param name="xCoordinate"> X coordinate of right upper corner of plataeu</param>
        /// <param name="yCoordinate"> Y coordinate of right upper corner of plataeu</param>
        public Plateau(string xCoordinate, string yCoordinate)
        {
            // use try catch to control if given coordinates are not integer
            try
            {
                xRight = Int32.Parse( xCoordinate);
                yUpper = Int32.Parse( yCoordinate);
            }
            catch (Exception e) {
                throw new ArgumentException(string.Format("Given parameters for plataeu is not corrext X Coordinate: {0}, Y Coordinate: {1}", xCoordinate, yCoordinate));
            }
            
            // check id uppur right coordinates are above point 0,0
            if(xRight < 0 || yUpper < 0)
                throw new ArgumentException(string.Format("plataeu upeer right corner's coordinates shoud be greater than 0. X Coordinate: {0}, Y Coordinate: {1}", xCoordinate, yCoordinate));
            
            xLeft = 0;
            yLower = 0;
        }
    }
}
