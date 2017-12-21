using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class DictionaryImpl
    {
        public static void Init() 
        {
            HashMap hashMap = new HashMap();
            hashMap.put(10, 20);
            hashMap.put(20, 11);
            hashMap.put(21, 1);
            hashMap.put(20, 10);

            int value = hashMap.get(20);
        }

        class HashMap 
        {
            List<HashEntry> table;
            public HashMap() 
            {
                table = new List<HashEntry>();
            }

            public void put(int key, int value) {
                int index = hashCodeNew(key);
                Console.WriteLine(index);
                HashEntry hashEntry = new HashEntry(key, value);
                if (table[index] == null) 
                {
                    table[index] = hashEntry;
                } 
                else 
                {
                    HashEntry runner = table[index];
                    while (runner.next != null) 
                    {
                        if (runner.key == hashEntry.key) 
                        {
                            runner.value = hashEntry.value;
                            break;
                        } else 
                        {
                            runner = runner.next;
                        }
                    }
                    if (runner.next == null) 
                    {
                        if (runner.key == hashEntry.key) 
                        {
                            runner.value = hashEntry.value;
                        } 
                        else 
                        {
                            runner.next = hashEntry;
                        }
                    }
                }

            }

            public int get(int key) 
            {
                int index = hashCodeNew(key);
                if (table[index] == null) 
                {
                    return -1;
                } 
                else 
                {
                    HashEntry runner = table[index];
                    if (runner.key == key) 
                    {
                        return runner.value;
                    }
                    while (runner.next != null) 
                    {
                        if (runner.key == key) 
                        {
                            return runner.value;
                        }
                    }
                    return -1;
                }
            }

            public int hashCodeNew(int h) 
            {
                h ^= (h >> 20) ^ (h >> 12);
                int hashCode = h ^ (h >> 7) ^ (h >> 4);
                return hashCode;
            }
        }

        class HashEntry 
        {
            public int key;
            public int value;
            public HashEntry next = null;

            public HashEntry() {
            }

            public HashEntry(int key, int value) {
                this.key = key;
                this.value = value;
            }

            public int getKey() {
                return this.key;
            }

            public int getValue() {
                return this.value;
            }
        }
    }
}
