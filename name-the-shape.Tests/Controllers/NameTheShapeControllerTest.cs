using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nts.Controllers;
using nts.Models;

namespace nts.Tests.Controllers
{
    [TestClass]
    public class NameTheShapeControllerTest
    {
        [TestMethod]
        public void Post()
        {
            var controller = new NameTheShapeController();

            var square = new[]
                {
                    new SimplePoint() {X = 1, Y = 1},
                    new SimplePoint() {X = 2, Y = 1},
                    new SimplePoint() {X = 2, Y = 2},
                    new SimplePoint() {X = 1, Y = 2}
                };
            
            Assert.AreEqual("Square", controller.Post(square));


            var rectangle = new[]
                {
                    new SimplePoint() {X = 1, Y = 1},
                    new SimplePoint() {X = 3, Y = 1},
                    new SimplePoint() {X = 3, Y = 2},
                    new SimplePoint() {X = 1, Y = 2}
                };

            Assert.AreEqual("Rectangle", controller.Post(rectangle));


            var rhombus = new[]
                {
                    new SimplePoint() {X = 4, Y = 5},
                    new SimplePoint() {X = 9, Y = 5},
                    new SimplePoint() {X = 6, Y = 1},
                    new SimplePoint() {X = 1, Y = 1}
                };

            Assert.AreEqual("Rhombus", controller.Post(rhombus));

            var parallelogram = new[]
                {
                    new SimplePoint() {X = 0, Y = 0},
                    new SimplePoint() {X = 4, Y = 0},
                    new SimplePoint() {X = 5, Y = 2},
                    new SimplePoint() {X = 1, Y = 2}
                   };

            Assert.AreEqual("Parallelogram", controller.Post(parallelogram));


            var trapezoid = new[]
                {
                    new SimplePoint() {X = 0, Y = 0},
                    new SimplePoint() {X = 3, Y = 0},
                    new SimplePoint() {X = 2, Y = 2},
                    new SimplePoint() {X = 0, Y = 2}
                };

            Assert.AreEqual("Trapezoid - (UK: Trapezium)", controller.Post(trapezoid));


            var kite = new[]
                {
                    new SimplePoint() {X = 4, Y = 1},
                    new SimplePoint() {X = 6, Y = 3},
                    new SimplePoint() {X = 4, Y = 8},
                    new SimplePoint() {X = 2, Y = 3}
                };

            Assert.AreEqual("Kite", controller.Post(kite));


            var complex = new[]
                {
                    new SimplePoint() {X = 0, Y = 4},
                    new SimplePoint() {X = 3, Y = 6},
                    new SimplePoint() {X = 3, Y = 4},
                    new SimplePoint() {X = 0, Y = 6}
                };

            Assert.AreEqual("Complex Quadrilaterals", controller.Post(complex));


            var quadrilateral = new[]
                {
                    new SimplePoint() {X = 1, Y = 1},
                    new SimplePoint() {X = 3, Y = 0},
                    new SimplePoint() {X = 4, Y = 4},
                    new SimplePoint() {X = 1, Y = 2}
                };

            Assert.AreEqual("Quadrilateral", controller.Post(quadrilateral));


            var invalid = new[]
                {
                    new SimplePoint() {X = 1, Y = 1},
                    new SimplePoint() {X = 3, Y = 1},
                    new SimplePoint() {X = 3, Y = 2},
                    new SimplePoint() {X = 3, Y = 1}
                };

            Assert.AreEqual("Invalid Quadrilateral", controller.Post(invalid));


            var concave = new[]
                {
                    new SimplePoint() {X = -2, Y = 0},
                    new SimplePoint() {X = -1, Y = 0},
                    new SimplePoint() {X = -1, Y = -1},
                    new SimplePoint() {X = 0, Y = 1}
                };

            Assert.AreEqual("Concave Quadrilateral", controller.Post(concave));
        }
    }
}
