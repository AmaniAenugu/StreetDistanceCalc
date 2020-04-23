using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    /// <summary>
    /// Application Is used to add the location with name, start and End co-ordinates
    /// </summary>
   // [Route("api/[controller]")]
    [ApiController]
    
    public class ValuesController : ControllerBase
    {
        /// <summary>
        /// Gets all the streets in the list
        /// </summary>
        /// <returns></returns>
        // GET api/values
        [HttpGet,Route("GetAllStreets")]
        public IEnumerable<Street> Get()
        {
            List<Street> streets = Data.GetStreets();
            return streets;
        }

        /// <summary>
        /// Gets the closes street/ array of streets for the passed co-ordinates
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        // GET api/values/5
        [HttpGet,Route("/closest")]
        public IEnumerable<string> Get(double x, double y)
        {
            IEnumerable<string> Shorteststreets;
            try
            {
                Shorteststreets = GetShortestStreet(x, y);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            return Shorteststreets;
        }
        /// <summary>
        /// Creates the new street with the specified co-ordinates
        /// </summary>
        /// <param name="streetModel"></param>
        /// <returns></returns>
        // POST api/values
        [HttpPost, Route("/street")]
        public ActionResult Post([FromBody] Street streetModel)
        {
            Data.SaveData(streetModel);
            return Ok();

        }
        [NonAction]
        public IEnumerable<string> GetShortestStreet(double x , double y)
        {
            IEnumerable<string> ShortestStreets;
            try
            {
                List<Street> streets = Data.GetStreets();
                //List<string> leaastDisStreets= new List<string>();
                //List<Street> shorteStreets= new List<Street>();
                List<double> distances = new List<double>();
                List<string> Streets = new List<string>();
                List<KeyValuePair<double, string>> distancesDictionary = new List<KeyValuePair<double, string>>();


                foreach (var item in streets)
                {
                    double d1 = y - item.start.y;
                    double d2 = item.end.y - item.start.y;
                    double d3 = x - item.start.x;
                    double d4 = item.end.x - item.start.x;
                    double dx = item.start.y - item.end.y;
                    double dy = item.start.x - item.end.x;
                    double denominator = Math.Sqrt(dx * dx + dy * dy);

                    double d = (d1 * d4 - d2 * d3) / denominator;
                    distances.Add(d);
                    distancesDictionary.Add(new KeyValuePair<double, string>(d, item.name));
                    Streets.Add(item.name);
                }


                List<double> LeastDistanceList = new List<double>();

                double LeastDistance = Double.MaxValue;
                int Index = 0;

                //for (int i = 0; i < distances.Count; i++)
                //{
                //    if (distances[i] < LeastDistance)
                //    {
                //        LeastDistance = distances[i];
                //        Index = i;
                //        //LeastDistanceList.Add(LeastDistance);
                //        LeastDistanceList.Clear();
                //        leaastDisStreets.Clear();
                //        LeastDistanceList.Add(LeastDistance);
                //        leaastDisStreets.Add(Streets[i]);
                //        continue;
                //    }

                //    if (distances[i] == LeastDistance)
                //    {
                //        LeastDistance = distances[i];
                //        Index = i;
                //        LeastDistanceList.Add(LeastDistance);
                //        leaastDisStreets.Add(Streets[i]);
                //    }

                //}

                foreach (double dist in distances)
                {
                    if (dist<=LeastDistance)
                    {
                        LeastDistance = dist;
                    }
                        
                }

                ShortestStreets = from val in distancesDictionary
                                      where val.Key == LeastDistance
                                  select val.Value;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            return ShortestStreets;

        }
    }
}
