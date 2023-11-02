using System;
using System.Collections;

namespace task03
{
    static class PrimeHelper
    {
        private static bool isPrime(int n)
        {
            // Corner cases
            if (n <= 1) return false;
            if (n <= 3) return true;

            // middle five numbers in below loop
            if (n % 2 == 0 || n % 3 == 0) return false;

            for (int i = 5; i * i <= n; i = i + 6)
                if (n % i == 0 || n % (i + 2) == 0)
                    return false;

            return true;
        }
        
        public static int nextPrime(int N)
        {

            // Base case
            if (N <= 1)
                return 2;

            int prime = N;
            bool found = false;

            // Loop continuously until isPrime returns
            // true for a number greater than n
            while (!found)
            {
                prime++;

                if (isPrime(prime))
                    found = true;
            }

            return prime;
        }
    }


	public class MyDictionary<TKey, TValue> : IEnumerator, IEnumerable
	{

        private struct Entry
        {
            public int hashCode;

            public int next;

            public TKey key;

            public TValue value;
        }

        private int[] _buckets;

        private Entry[] _entries;

        private int _count;

        private int _freeList;

        private int _freeCount;

        private int _version;

        private int position = -1;

        public MyDictionary()
		{
            _buckets = new int[0];
            _entries = new Entry[0];
            _count = 0;
            _freeList = -1;
            _freeCount = 0;
            _version = 0;
		}

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        public bool MoveNext()
        {
            ++position;
            return (position < _count);
        }

        public void Reset()
        {
            position = -1;
        }

        public object Current
        {
            get => new KeyValuePair<TKey, TValue>(_entries[position].key,
                _entries[position].value);
        }

        public void Add(TKey key, TValue value)
        {
            if (_freeList == -1)
            {
                AddWithResize(key, value, 3);
                return;
            }
            if (_freeCount == 0)
            {
                AddWithResize(key, value, _count * 2);
                return;
            }
            int keyHashCode = key.GetHashCode();
            ref int bucket = ref GetBucket(keyHashCode);

            if (bucket == 0)
            {
                bucket = _freeList + 1;
                _entries[_freeList].hashCode = keyHashCode;
                _entries[_freeList].value = value;
                _entries[_freeList].key = key;
                _entries[_freeList].next = -1;
                --_freeCount;
                ++_freeList;
                ++_count;
                return;
            }
            int nextIndex = bucket - 1;
            while (nextIndex != -1)
            {
                if (keyHashCode == _entries[nextIndex].hashCode)
                {
                    _entries[nextIndex].value = value;
                    return;
                } else
                {
                    nextIndex = _entries[nextIndex].next; 
                }
            }
            _entries[_freeList].hashCode = keyHashCode;
            _entries[_freeList].value = value;
            _entries[_freeList].key = key;
            _entries[_freeList].next = bucket - 1;
            bucket = _freeList + 1;
            --_freeCount;
            ++_freeList;
            ++_count;
        }

        public ref int GetBucket(int hashCode)
        {
            int bucketIndex = hashCode % _buckets.Length;
            if (bucketIndex < 0)
            {
                bucketIndex += _buckets.Length;
            }
            return ref _buckets[bucketIndex];
        }

        public void Resize(int newSize)
        {
            int exactSize = PrimeHelper.nextPrime(newSize);
            Entry[] newEntries = new Entry[exactSize];
            _buckets = new int[exactSize];
            _entries.CopyTo(newEntries, 0);
            
            for (int i = 0; i < _count; i++)
            {
                if (newEntries[i].next >= -1)
                {
                    ref int bucket = ref GetBucket(newEntries[i].hashCode);
                    newEntries[i].next = bucket - 1;
                    bucket = i + 1;
                }
            }
            _entries = newEntries;
            _freeCount = newSize - _count;
            ++_version;
            _freeList = _count;
        }

        public void AddWithResize(TKey key, TValue value, int newSize)
        {
            Resize(newSize);
            Add(key, value);
        }

        public TValue this[TKey key]
        {
            get
            {
                int keyHashCode = key.GetHashCode();
                ref int bucket = ref GetBucket(keyHashCode);

                if (bucket == 0)
                {
                    throw new Exception();
                }
                int nextIndex = bucket - 1;
                while (nextIndex != -1)
                {
                    if (keyHashCode == _entries[nextIndex].hashCode)
                    {
                        return _entries[nextIndex].value;
                    }
                    else
                    {
                        nextIndex = _entries[nextIndex].next;
                    }
                }
                throw new Exception();
            }
        }
	}
}

