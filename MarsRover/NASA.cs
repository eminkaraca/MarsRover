using MarsRover.Interface;
using MarsRover.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    /// <summary>
    /// NASA is the Control Manager for Mars Project
    /// Creates Plataeu
    /// Creates Rovers
    /// Give commands to rovers
    /// </summary>
    public static class NASA
    {
        public static IPlataeu plateau;
        public static Heading heading;
        public static Coordinate coordinate;
        public static IRover rover;
        /// <summary>
        /// Create a new plataeu with given initial coordinates
        /// </summary>
        /// <param name="plataeuCommands">Upper Rigt X Y coordinate of Plataeu</param>
        /// <returns>returns a new plataeu</returns>
        public static void CreatePlataeu(string plataeuCommands)
        {
            string[] coordinates = plataeuCommands.TrimEnd(' ').Split(' ');

            // we need both X and Y coordinates thus input should have excatly 2 integer
            if (coordinates.Length != 2)
            {
                throw new ArgumentException(string.Format("Wrong parameters for Plataeu {0}", plataeuCommands));
            }

            plateau = new Plateau(coordinates[0], coordinates[1]);
        }

        public static void StartRover(String command)
        {
           rover.Start(command);
        }


        /// <summary>
        /// RETURNS THE CURRENT POSİTİON OF THE ROVER
        /// </summary>
        /// <returns>direction in the format;X Y coordinates and direction of the rove. Format : X Y Direction(N,E,S,W)</returns>
        public static string GetRoverPosition()
        {
            return rover.GetPosition();
        }

        /// <summary>
        /// Creates a new Rover 
        /// </summary>
        /// <param name="position">X Y coordinates and direction of the rove. Format : X Y Direction(N,E,S,W)</param>
        public static void CreateRover(string position)
        {
            String[] positionArr = ControlRoverPosition(position.TrimEnd(' '));

            heading = new Heading(positionArr[2]);
            coordinate = new Coordinate(positionArr[0], positionArr[1]);
            rover = new Rover(plateau, heading, coordinate);

        }

        /// <summary>
        /// Controls if given position for rover is correct
        /// Contains X,Y coordinates and a direction
        /// </summary>
        /// <param name="position">X Y coordinates and direction of the rove. Format : X Y Direction(N,E,S,W)</param>
        /// <returns>returns the poasitions in a string array</returns>
        private static string[] ControlRoverPosition(string position)
        {
            String[] positionArr = position.Split(" ");
            if (positionArr.Length != 3)
            {
                throw new ArgumentException(string.Format("Wrong parameters for Rover Poasition {0}", position));
            }

            return positionArr;
        }
    }
}
