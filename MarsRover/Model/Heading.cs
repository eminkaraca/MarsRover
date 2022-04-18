using System;
using System.Collections.Generic;

namespace MarsRover.Model
{
    public class Heading
    {
        public string headingTo { get; set; }
        //This array will be use as a circular array to use turn operations
        private List<string> headings = new List<string>{ "N", "E", "S", "W" };

        /// <summary>
        /// Create a new heading info that shows which direction does a rover head to
        /// </summary>
        /// <param name="heading"> String value N fo North, E for East, S for South, W for West</param>
        public Heading(string heading) {
            if (!headings.Contains(heading.ToUpper()))
                throw new ArgumentException(string.Format("There is no heading to {0}",heading));
            
            headingTo = heading.ToUpper();
        }

        /// <summary>
        /// Changes heading by turning it to rigt
        /// </summary>
        /// <returns>returns new heading direction</returns>
        public string TurnLeft()
        {
            int nextHeading = headings.IndexOf(headingTo) + 3;
            headingTo = headings[nextHeading % 4]; // using % 4 will make it circular
            return headingTo;
        }
        /// <summary>
        /// Changes heading by turning it to right
        /// </summary>
        /// <returns>returns new heading direction</returns>
        public string TurnRight()
        {
            int nextHeading = headings.IndexOf(headingTo) + 1;
            headingTo = headings[nextHeading % 4]; // using % 4 will make it circular
            return headingTo;
        }
    }
}
