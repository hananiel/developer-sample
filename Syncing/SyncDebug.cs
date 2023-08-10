using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DeveloperSample.Syncing
{
    public class SyncDebug
    {
        public List<string> InitializeList(IEnumerable<string> items)
        {
            var bag = new ConcurrentBag<string>();
            Parallel.ForEach(items, i =>
            {
                //var r = await Task.Run(() => i).ConfigureAwait(false);
                //bag.Add(r);
                bag.Add(i);
            });
            var list = bag.ToList();
            return list;
        }

        public Dictionary<int, string> InitializeDictionary(Func<int, string> getItem)
        {
            //var itemsToInitialize = Enumerable.Range(0, 100).ToList();
            //var concurrentDictionary = new ConcurrentDictionary<int, string>();
            //Parallel.ForEach(itemsToInitialize, new ParallelOptions { MaxDegreeOfParallelism = 3 }, item => {
            //    concurrentDictionary.AddOrUpdate(item, getItem, (_, s) => s);
            //});
            //return concurrentDictionary.ToDictionary(kv => kv.Key, kv => kv.Value);

            int numberOfThreads = 3;
            int dictionaryLength = 100;
            int numberPerEntry = (int)Math.Ceiling((decimal)dictionaryLength / (decimal)numberOfThreads);

            var itemsToInitialize = Enumerable.Range(0, 100).ToList();

            var concurrentDictionary = new ConcurrentDictionary<int, string>();
            var threads = Enumerable.Range(0, 3)
                .Select(i => new Thread(() => {
                   
                    foreach (var item in itemsToInitialize.Skip(i*numberPerEntry).Take(numberPerEntry))
                    {
                        concurrentDictionary.AddOrUpdate(item, getItem, (_, s) => s);
                    }
                }))
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