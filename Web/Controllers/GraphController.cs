using CSharpRemoteChallenge.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Web.Controllers
{
    public class GraphController : ApiController
    {
        [HttpGet]
        public void Get(string graph)
        {
            // A void action returns no content with status 204 (No Content).
        }

        [HttpGet]
        public int TotalDistance(string graph, string path)
        {
            var _graph = new Graph(graph);
            var _path = new Path(path);

            return _graph.ComputeDistance(_path);
        }

        [HttpGet]
        public IEnumerable<string> AvailableRoute(string graph, string origin, string destiny, int maxStops)
        {
            var _graph = new Graph(graph);
            var _origin = new Town(origin);
            var _destiny = new Town(destiny);

            var paths = _graph.ListAvailableRoutes(_origin, _destiny, maxStops);

            return (
                from path in paths
                select path.ToString()
            );
        }

        [HttpGet]
        public string ShortestRoute(string graph, string origin, string destiny)
        {
            var _graph = new Graph(graph);
            var _origin = new Town(origin);
            var _destiny = new Town(destiny);

            var path = _graph.FindShortestRoute(_origin, _destiny);

            return path.ToString();
        }
    }
}