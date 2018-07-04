using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KanjiApp.Utilities
{
	public static class RandomUtils
	{
		public static IList<T> PickSomeInRandomOrder<T>(IList<T> source,int maxCount)
		{
			Random random = new Random(DateTime.Now.Millisecond);

			Dictionary<double, T> randomSortTable = new Dictionary<double, T>();

			foreach (T element in source)
				randomSortTable[random.NextDouble()] = element;

			return randomSortTable.OrderBy(KVP => KVP.Key).Take(maxCount).Select(KVP => KVP.Value).ToList();
		}

		public static IList<T> Shuffle<T>(IList<T> source)
		{
			return source.OrderBy(x => Guid.NewGuid()).ToList();
		}
	}
}
