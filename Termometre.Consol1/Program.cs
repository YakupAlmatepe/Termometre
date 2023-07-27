
using System;
using EntityLayer; // Entity modellerini içeren projenizin ismini buraya ekleyin
using DataAccessLayer.Concrete; // Veritabanı bağlantıları ve AppContext sınıfını içeren projenizin ismini buraya ekleyin
using EntityLayer.Concrete;

using System.ComponentModel.DataAnnotations;
using Termometre.Consol1.Concrete;
using Termometre.Consol1;
using Microsoft.AspNetCore.SignalR.Client;

public class Program
{
    static void Main(string[] args)
    {

        var hubConnection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/myhub")
                .WithAutomaticReconnect()
                .Build();

        hubConnection.On<string>("ReceiveMessage",OnReceiveMessage);
         hubConnection.StartAsync();
        Random randomtemp = new Random();

        List<int> randomNumbers = new List<int>();

        while(true)
        {
            Console.WriteLine("Entera bas");
            Console.ReadLine();

            
            int sayi = randomtemp.Next(-40, 100);

            using (var _context = new RandomTempDbContext())
            {
                var randomTemperature = new RandomTemp
                {
                    Tempreture = sayi
                };

                _context.RandomTemps.Add(randomTemperature); // Update işlemi kaldırıldı
                _context.SaveChanges();
               
            }
            hubConnection.InvokeAsync("SendMessage", "message");
            Console.WriteLine(sayi.ToString());

        }
    }

    private static void OnReceiveMessage(string obj)
    {
        Console.WriteLine($"Mesaj Geldi={obj}");
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