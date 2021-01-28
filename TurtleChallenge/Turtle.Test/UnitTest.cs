using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Turtle.Library;
using Turtle.Library.Models;
using Turtle.Library.Strategy;

namespace Turtle.Test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestPoint()
        {
            Point point = new Point(10, 5);
            Assert.AreEqual(5,point.Y);
        }

        [TestMethod]
        public void TestObserver()
        {
            Observer observer = new Observer(new Grid(10,6));
            Assert.AreEqual(false,observer.IsDanger(new Point(5,5)));
        }

        [TestMethod]
        public void TestColor()
        {
            string colorGreen = typeof(White).BaseType?.ToString();
            string tString = typeof(Color).ToString();
            Assert.AreEqual(colorGreen,tString);
        }

        [TestMethod]
        public void TestTurtle()
        {
            Library.Models.Turtle turtle = Library.Models.Turtle.Instance(new Point(5, 6));
            int positionX = turtle.Position.X;
            int positionY = turtle.Position.Y;
            Assert.AreEqual(positionX,5);
            Assert.AreEqual(positionY,6);
        }

        [TestMethod]
        public void TestPrinter()
        {
            Assert.AreNotEqual(Printer.SUCCESS,Printer.DEAD);
        }

    }
}
