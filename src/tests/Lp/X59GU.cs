using System.Collections.Generic;
using System.Linq;

namespace BusRoutes
{
    public class Solver
    {
        public int Solve(List<int[]> routes, int start, int end)
        {
            var stops = new Dictionary<int, List<int>>();
            var it = 0;
            foreach (var route in routes)
            {
                foreach (var stop in route)
                {
                    if (!stops.ContainsKey(stop))
                    {
                        stops.Add(stop, new List<int>());
                    }

                    stops[stop].Add(it);
                }

                ++it;
            }

            var graph = new Dictionary<int, List<int>>();

            foreach (var pp in stops)
            {
                foreach (var u in pp.Value)
                {
                    if (!graph.ContainsKey(u))
                    {
                        graph.Add(u, new List<int>());
                    }

                    foreach (var v in pp.Value.Where(v => u != v))
                    {
                        graph[u].Add(v);
                    }
                }
            }

            if (start == end) return 0;
            if (!stops.ContainsKey(start) || !stops.ContainsKey(end)) return -1;

            var q = new Queue<int>();
            var dist = new Dictionary<int, int>();
            foreach (var v in stops[start])
            {
                dist.Add(v, 1);
                q.Enqueue(v);
            }
            while (q.Count > 0)
            {
                var v = q.Dequeue();

                if (!graph.ContainsKey(v))
                {
                    continue;
                }

                foreach (var to in graph[v].Where(to => !dist.ContainsKey(to)))
                {
                    dist.Add(to, dist[v] + 1);
                }
            }

            var ans = -1;
            foreach (var v in stops[end].Where(v => dist.ContainsKey(v)).Where(v => ans == -1 || ans > dist[v]))
            {
                ans = dist[v];
            }
            return ans;
        }
    }
}