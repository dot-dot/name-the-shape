using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nts.Models;

namespace nts.Tests.Controllers
{
    [TestClass]
    public class QuadrilateralTest
    {
        [TestMethod]
        public void GetShapeType()
        {
            var square = new Models.Quadrilateral(new LineSegment[]
                {
                    new LineSegment()
                        {
                            Coordinates = new SimplePoint[]
                                {
                                    new SimplePoint() {X = 1, Y = 1},
                                    new SimplePoint() {X = 2, Y = 1}
                                }
                        },
                    new LineSegment()
                        {
                            Coordinates = new SimplePoint[]
                                {
                                    new SimplePoint() {X = 2, Y = 2},
                                    new SimplePoint() {X = 1, Y = 2}
                                }
                        },
                    new LineSegment()
                        {
                            Coordinates = new SimplePoint[]
                                {
                                    new SimplePoint() {X = 2, Y = 1},
                                    new SimplePoint() {X = 2, Y = 2}
                                }
                        },
                    new LineSegment()
                        {
                            Coordinates = new SimplePoint[]
                                {
                                    new SimplePoint() {X = 1, Y = 2},
                                    new SimplePoint() {X = 1, Y = 1}
                                }
                        }
                });

            Assert.AreEqual("Square", square.GetShapeType());
        }
    }
}
