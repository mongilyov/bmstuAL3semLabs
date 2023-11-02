using System;
namespace task02
{
	public class MyList<T>
	{
		public int Length => size;
		public int Capacity
		{
			get => array.Length;
			set
			{
				if (value > 0 && value > size)
				{
					T[] items = new T[value];
					array.CopyTo(items, 0);
					array = items;
				}
			}
		}

		private T[] array;
		private int size;



		public MyList()
		{
			array = new T[0];
			size = 0;
			Capacity = 0;
		}

		public MyList(int capacity)
		{
			array = new T[capacity];
		}

		public MyList(IEnumerable<T> collection)
		{
			if (collection == null)
			{
				throw new Exception();
			}
            ICollection<T> collection1 = collection as ICollection<T>;

            if (collection1.Count() == 0)
			{
				array = new T[0];
				return;
			}
			array = new T[collection1.Count()];
			collection1.CopyTo(array, 0);
			size = array.Length;
		}

		public void Add(T elem)
		{
			if (size == 0)
			{
				Resize(1);
			}
			else if (size == Capacity)
			{
				Resize(Capacity * 2);
			}
			array[size] = elem;
            ++size;
        }

		public void Resize(int newCapacity)
		{
			Capacity = newCapacity;
		}

		public T this[int index]
		{
			get => array[index];
			set
			{
				array[index] = value;
				if (index == size)
				{
					++size;
				}
			}
		}
	}
}

