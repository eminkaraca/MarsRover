using System;


namespace MarsRover.Model
{
    public class Coordinate
    {
        public int x { get; set; }
        public int y { get; set; }


        /// <summary>
        /// Creates a new coordinates X and Y
        /// Throw ArgumentException if parameters are not integer value
        /// </summary>
        /// <param name="xCoordinate">X coordinate</param>
        /// <param name="yCoordinate">Y coordinate</param>
        public Coordinate(string xCoordinate, string yCoordinate) {

            try
            {
                x = Int32.Parse(xCoordinate);
                y = Int32.Parse(yCoordinate);
            }
            catch (Exception ex) {
                throw new ArgumentException(string.Format("Given parameters for Poasition Coordinates X an Y  is not corrext X Coordinate: {0}, Y Coordinate: {1}", xCoordinate, yCoordinate));
            }
        }
    }
}
