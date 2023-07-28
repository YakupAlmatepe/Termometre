using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using MassTransit;

    Random randomtemp = new Random();

    List<int> randomNumbers = new List<int>();
    var bus = Bus.Factory.CreateUsingRabbitMq(factory =>
    {
        factory.Host("localhost", "/", h =>
        {
            h.Username("altis");
            h.Password("altis");

        });

    });

    //Kanal başlatılıyor
    bus.Start();
    while (true)
    {
        Console.WriteLine("Entera bas");
        Console.ReadLine();


        int sayi = randomtemp.Next(300, 400);

        using (var _context = new ApplicationContext())
        {
            var rand = new RandomTemperature
            {
                Tempreture = sayi
            };
                bus.Publish(rand);//mesajın publish edilmesi 
            Console.WriteLine(sayi.ToString());
        }
        

    }


