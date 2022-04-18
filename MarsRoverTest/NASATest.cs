using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MarsRoverTest
{
    [TestClass]
    public class NASATest
    {
        [TestMethod]
        public void TestApplyCommandsCorrectly()
        {
            NASA.CreatePlataeu("5 5");
            NASA.CreateRover("1 2 N");
            NASA.StartRover("LMLMLMLMM");
            Assert.AreEqual("1 3 N", NASA.GetRoverPosition());

            NASA.CreateRover("3 3 E");
            NASA.StartRover("MMRMMRMRRM");
            Assert.AreEqual("5 1 E", NASA.GetRoverPosition());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestRoverOutSideOfPlataeu()
        {
            NASA.CreatePlataeu("5 5");
            NASA.CreateRover("6 5 E");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPlataeuNegativeCoordinate()
        {
            NASA.CreatePlataeu("-1 5");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPlataeuWrongParameters()
        {
            NASA.CreatePlataeu("55");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestPlataeuNonIntegerCoordinate()
        {
            NASA.CreatePlataeu("A 5");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIncorrectDirection()
        {
            NASA.CreatePlataeu("5 5");
            NASA.CreateRover("1 2 T");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIncorrectCoordinate()
        {
            NASA.CreatePlataeu("5 5");
            NASA.CreateRover("A 2 T");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestWrongNumberofParameter()
        {
            NASA.CreatePlataeu("5 5");
            NASA.CreateRover("A 2 E E");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestWrongCommand()
        {
            NASA.CreatePlataeu("5 5");
            NASA.CreateRover("A 2 E ");
            NASA.StartRover("LLK");
        }

    }
}
