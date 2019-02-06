using System.Collections.Generic;

namespace std_3_st2.Iterator
{
    public class IteratorMainApp
    {
        public static void Main() {
            ArrayList<string> collection = new ArrayList<string>();

            collection.Add("Първо Нещо");
            collection.Add("Второ Нещо");
            collection.Add("Tрето Нещо");
            collection.Add("Четвърто Нещо");
            collection.Add("Пето Нещо");

            Iterator<string> iterator = new Iterator<string>(collection);
            while(iterator.HasNext()) {
                System.Console.WriteLine(iterator.GetNext());
            }
        }
    }

    public class Iterator<T> {

        private ArrayList<T> collection;
        private int lastIndex;

        public Iterator(Collection<T> collection) {
            this.collection = collection;
        }

        public bool HasNext() {
            return collection.GetSize() <= (lastIndex + 1);
        }

        public T GetNext() {
            return collection[lastIndex++];
        }
    }
}