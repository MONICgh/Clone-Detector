namespace HW_11;

public static class Buses
{
    public static int Solve(IReadOnlyCollection<List<int>> routes, int start, int end)
    {
        var distance = new Dictionary<int, int> { { start, 0 } };
        var queue = new Queue<int>();
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            var vertex = queue.Dequeue();
            var hashSet = routes.Where(list => list.Contains(vertex)).SelectMany(list => list).ToHashSet();
            foreach (var item in hashSet)
            {
                if (distance.ContainsKey(item))
                {
                    var len = distance[item];
                    if (len <= distance[vertex] + 1)
                        continue;
                    distance[item] = distance[vertex] + 1;
                    queue.Enqueue(item);
                }
                else
                {
                    distance[item] = distance[vertex] + 1;
                    queue.Enqueue(item);
                }
            }
        }

        return distance[end];
    }
}
