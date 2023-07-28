
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using MassTransit;
using Microsoft.AspNetCore.SignalR.Client;
using System.Threading.Channels;

public class Program
{
    static void Main(string[] args)
    {
        var bus = Bus.Factory.CreateUsingRabbitMq(factory =>
        {
            factory.Host("localhost", "/", h =>
            {
                h.Username("altis");
                h.Password("altis");

            });
            factory.ReceiveEndpoint("randomNumberQueue", ep =>
            {
                // Gelen mesajları işlemek için bir tüketici (consumer) oluşturuyoruz
                ep.Handler<RandomTemperature>(context =>
                {
                    var randomTemperature = context.Message.Tempreture;

                    // Konsola mesajı yazdırıyoruz
                    Console.WriteLine($"Gelen sıcaklık değeri: {randomTemperature}");

                    
                    using (var _context = new ApplicationContext())
                    {
                        _context.RandomTempretures.Add(new RandomTemperature { Tempreture = randomTemperature });
                        _context.SaveChanges();
                    }
                    return Task.CompletedTask;
                });
            });
        });    
        //Kanal başlatılıyor
        bus.Start();
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

            
            //rABBİTMQ İÇİN Consume edilecek

            //using (var _context = new ApplicationContext())
            //{

            //    _context.RandomTempretures.Add(randomTemperature); // Update işlemi kaldırıldı
            //    _context.SaveChanges();
               
            //}
            //hubConnection.InvokeAsync("SendMessage", "message");
            //Console.WriteLine(sayi.ToString());

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