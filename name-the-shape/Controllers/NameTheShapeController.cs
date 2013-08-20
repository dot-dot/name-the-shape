using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using nts.Models;

namespace nts.Controllers
{
    public class NameTheShapeController : ApiController
    {

        public string Post([FromBody] IEnumerable<SimplePoint> points)
        {
            if (points == null)
            {
                return "Invalid Quadrilaterals";
            }

            var shape = new Models.Quadrilateral(points.ToArray());

            try
            {
                return shape.GetShapeType();
            }
            catch (Exception)
            {

                return "Invalid Quadrilaterals";
            }
           
        }
    }  
}
