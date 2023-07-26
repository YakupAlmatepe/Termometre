
using System;
using EntityLayer; // Entity modellerini içeren projenizin ismini buraya ekleyin
using DataAccessLayer.Concrete; // Veritabanı bağlantıları ve AppContext sınıfını içeren projenizin ismini buraya ekleyin
using EntityLayer.Concrete;
using AppContext = DataAccessLayer.Concrete.AppContext;
using System.ComponentModel.DataAnnotations;

public class Program
{
    static void Main(string[] args)
    {
        Random randomtemp = new Random();

        for (int i = 0; i < 100; i++)
        {
            int sayi = randomtemp.Next(1, 100);

            using (var _context = new AppContext())
            {
                var randomTemperature = new RandomTempreture
                {
                    Tempreture = sayi
                };

                _context.RandomTempretures.Add(randomTemperature);

                _context.SaveChanges();
            }

            Console.WriteLine(sayi.ToString());
        }
    }
}












//using EntityLayer;
//public class Program
//{
//    void Main(string[] args)
//    {
//        Random randomtemp = new Random();

//        for (int i = 0; i < 100; i++)
//        {
//            int sayi = randomtemp.Next(1, 100);

//            using (var _context = new DataAccessLayer.Concrete.AppContext())
//            {
//              //  _context.RandomTempretures.Update();
//               // _context.RandomTempretures.();
//            }
//            Console.WriteLine(sayi.ToString());
//        }
//    }
//}