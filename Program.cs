using System.Collections;

namespace Pisti
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //pişti - hakan edition

            //oyun bilgiler
            //----------------------

            //tek deste var
            //destede 52 kart var
            //kupa, maça, sinek, karo için 1-13'e kadar kağıtlar
            //iki oyuncu vardır

            //oyun nasıl oynanır
            //---------------------------

            //deste ilk elden önce karılır
            //sırayla her bir oyuncu desteden random kar çeker ve yere at
            //eğer oyunculardan birisi yerdeki bir kartla aynı sayıdaki bir kartı atarsa yerdeki tüm kartların puanını alır
            //çekilecek kart bitince oyun biter, en yüksek puan alan kazanır

            //int[] deste = new int[52];
            ArrayList deste = new ArrayList();

            Random random = new Random();
            int oyuncu1 = 0, oyuncu2 = 0;

            for (int i = 0; i < 4; i++) //karo, maça, sinek, kupa
            {
                for (int j = 0; j < 13; j++)
                {
                    //deste[(i * 13) + j] = j + 1;
                    deste.Add(j + 1);
                }
            }

            ArrayList yer = new ArrayList();
            //for (int i = 0; i < 27; i++)
            //{
            while(deste.Count > 0)
            {
                int oyuncu1Numara = random.Next(0, deste.Count);
                int oyuncu1Kart = Convert.ToInt32(deste[oyuncu1Numara]);

                if (yer.Count > 0 && oyuncu1Kart == Convert.ToInt32(yer[yer.Count - 1]))
                {
                    int toplam = 0;
                    foreach (var item in yer)
                        toplam += Convert.ToInt32(item);

                    oyuncu1 += toplam;
                    yer.Clear();

                    continue;
                }

                yer.Add(oyuncu1Kart);
                deste.RemoveAt(oyuncu1Numara);

                int oyuncu2Numara = random.Next(0, deste.Count);
                int oyuncu2Kart = Convert.ToInt32(deste[oyuncu2Numara]);

                if (oyuncu2Kart == Convert.ToInt32(yer[yer.Count - 1]))
                {
                    int toplam = 0;
                    foreach (var item in yer)
                        toplam += Convert.ToInt32(item);

                    oyuncu2 += toplam;
                    yer.Clear();
                }

                yer.Add(oyuncu1Kart);
                deste.RemoveAt(oyuncu2Numara);
            }

            Console.WriteLine("Puanlar -> Oyuncu1: " + oyuncu1 + ", Oyuncu2: " + oyuncu2);
            
            if (oyuncu1 > oyuncu2)
                Console.WriteLine("Oyuncu1 kazandı");
            else if (oyuncu2 > oyuncu1)
                Console.WriteLine("Oyuncu2 kazandı");
            else
                Console.WriteLine("Berabere");

            Console.ReadLine();
        }
    }
}