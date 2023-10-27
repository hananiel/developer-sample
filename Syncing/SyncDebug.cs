using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace DeveloperSample.Syncing
{
    public class SyncDebug
    {
        public List<string> InitializeList(IEnumerable<string> items)
        {
            var bag = new ConcurrentBag<string>();
            
            Parallel.ForEachAsync(items, async (i, token) =>
            {
                var r = await Task.Run(() => i).ConfigureAwait(false);
                bag.Add(r);
            }).Wait();

            var list = bag.ToList();
            return list;
        }

        public Dictionary<int, string> InitializeDictionary(Func<int, string> getItem)
        {
            var itemsToInitialize = Enumerable.Range(0, 100).ToList();

            var concurrentDictionary = new ConcurrentDictionary<int, string>();
            var threads = Enumerable.Range(0, 3)
                .Select(i => new Thread(() =>
                {
                    int increment = 100 / 3;
                    int index = increment * i;
                    int count = i < 2 ? increment : increment + 1;

                    // Above logic same as .. 
                    //switch (i)
                    //{
                    //    case 0: index = 0; count = 33; break;
                    //    case 1: index = 33; count = 33; break;
                    //    case 2: index = 66; count = 34; break;
                    //}

                    foreach (var item in itemsToInitialize.GetRange(index, count)) // split workload among threads 
                    {
                        concurrentDictionary.AddOrUpdate(item, getItem, (_, s) => s);
                    }
                })
                {

                })
                .ToList();

            foreach (var thread in threads)
            {
                thread.Start();
            }
            foreach (var thread in threads)
            {
                thread.Join();
            }

            return concurrentDictionary.ToDictionary(kv => kv.Key, kv => kv.Value);
        }
    }
}