using System;
using System.Collections.Generic;
using System.Text;

namespace Utility
{
    public class BubbleSort<T> where T : IComparable<T>
	{
		public T[] Sort(T[] items)
		{

			for (int i = 0; i < items.Length; i++)
			{
				for (int j = 0; j < items.Length - 1 - i; j++)
				{
					if (items[j].CompareTo(items[j + 1]) > 0)
					{

						var temp = items[j];
						items[j] = items[j + 1];
						items[j + 1] = temp;
					}
				}
			}
			return items;
		}
	}
}
