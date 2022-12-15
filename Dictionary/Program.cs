using System;
using System.Collections.Generic;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> kullanicilar = new Dictionary<int, string>();
            kullanicilar.Add(0, "KEREM ÖZER");
            kullanicilar.Add(1, "Ali RODOPLU");
            Console.WriteLine(kullanicilar.Count);


            MyDictionary<int, string> kullanicilar2 = new MyDictionary<int, string>();
            kullanicilar2.Add(0, "KEREM ÖZER");
            kullanicilar2.Add(1, "Ali RODOPLU");
            Console.WriteLine(kullanicilar2.Count);
            kullanicilar2.showList();
            kullanicilar2.Add(2, "Ali RODOPLU");
        }
    }

    class MyDictionary<T, K>
    {
        KeyValuePair<T, K>[] items;
        public MyDictionary()
        {
            items = new KeyValuePair<T, K>[0];
        }

        public void Add(T _key, K _value)
        {
            if (Control(_value))
            {
                Configuration();
                items[items.Length - 1] = new KeyValuePair<T, K>(_key, _value);
            }
            else
            {
                Console.WriteLine("Girdiğiniz key değeri özel olmalı.Önceden eklenmemiş olmalıdır tekrar girilmeyen bir değer giriniz.");
            }
        }

        public void showList()
        {
            foreach (var item in items)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
        }

        private void Configuration()
        {
            KeyValuePair<T, K>[] tempArray = items;
            items = new KeyValuePair<T, K>[items.Length + 1];
            for (int i = 0; i < tempArray.Length; i++)
            {
                items[i] = tempArray[i];
            }
        }

        private bool Control(K _value)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Value.ToString() == _value.ToString())
                {
                    return false;
                }
            }
            return true;
        }


        public int Count
        {
            get { return items.Length; }

        }

    }
}
