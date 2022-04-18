using MarsRover.Interface;
using System;

namespace MarsRover.Model
{
    public class Rover : IRover
    {
        /// <summary>
        /// Plataue of the rover
        /// </summary>
        public IPlataeu plateau { get; set; }
        /// <summary>
        /// Direction of the rover
        /// </summary>
        public Heading heading { get; set; }
        public Coordinate coordinate { get; set; }


        /// <summary>
        /// Create a new rover
        /// </summary>
        /// <param name="plateau">Plataeu that rover will investigate</param>
        /// <param name="heading">direction of the rover</param>
        /// <param name="coordinate">initial coordinates of the rover</param>
        public Rover(IPlataeu plateau, Heading heading, Coordinate coordinate) {

            this.plateau = plateau;
            this.heading = heading;
            this.coordinate = coordinate;

            IsRoverInsidePlataeu();
        }

        /// <summary>
        /// Controls if the commands is right.
        /// Throws ArgumentException if there is an unknown command
        /// </summary>
        private void ControlCommands(string commands)
        {
            string validCommands = "MLR";

            foreach (char c in commands)
            {
                if (!validCommands.Contains(c.ToString()))
                    throw new ArgumentException(string.Format("There is no Command for {0}", c.ToString()));
            }

        }

        /// <summary>
        /// Start appliying the commands
        /// </summary>
        /// <param name="roverCommands">Commands for the rover</param>
        public void Start(string roverCommands) {

            String commnad = roverCommands.ToUpper().TrimEnd(' ');

            ControlCommands(commnad);

            for (int i = 0; i < commnad.Length; i++)
            {
                RunCommand(commnad[i]);
            }

        }

        /// <summary>
        /// Runs the given command
        /// </summary>
        /// <param name="command">Char implementation of the Command L for turning left, R for turning rigt, M for move</param>
        private void RunCommand(char command)
        {
            switch(command) {
                case 'L':
                    {
                        heading.TurnLeft();
                        break;
                    }
                case 'R':
                    {
                        heading.TurnRight();
                        break;
                    }
                case 'M':
                    {
                        Move();
                        break;
                    }
            }
        }

        /// <summary>
        /// Moves the ravor by 1 grid point and maintain the direction
        /// </summary>
        private void Move()
        {
            switch (heading.headingTo) {
                case "N":
                    {
                        coordinate.y += 1;
                        break;
                    }
                case "E":
                    {
                        coordinate.x += 1;
                        break;
                    }
                case "S":
                    {
                        coordinate.y -= 1;
                        break;
                    }
                case "W":
                    {
                        coordinate.x -= 1;
                        break;
                    }
            }


            IsRoverInsidePlataeu();
        }

        /// <summary>
        /// Control if the cooridinates of the rover is inside the plataeu
        /// Throws ArgumentException if rover is outside of the plataeu
        /// </summary>
        private void IsRoverInsidePlataeu()
        {
            if( !(plateau.xLeft <= coordinate.x &&  plateau.xRight >= coordinate.x && plateau.yLower <= coordinate.y && plateau.yUpper >= coordinate.y))
                throw new ArgumentException("Can not move outsife of Plateau");
        }

        /// <summary>
        /// return the current position and direction
        /// </summary>
        /// <returns>position and direction in the format X Y Direction</returns>
        public string GetPosition() {

            return string.Format("{0} {1} {2}"
                , this.coordinate.x.ToString()
                , coordinate.y.ToString()
                , heading.headingTo);
        }
    }
}
