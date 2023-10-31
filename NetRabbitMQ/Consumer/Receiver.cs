using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;


public static class Receiver { 


    public  static void Conumer()
    {
        var factory = new ConnectionFactory
        {

            HostName = "localhost",
            UserName = "guest",
            Password = "guest"
        };

        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare("BrenoQueue", false, false, false, null);
            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.Span;

                var menssagem = Encoding.UTF8.GetString(body);
                Console.WriteLine("Menssagem recebida"+ menssagem);
            };

            channel.BasicConsume("BrenoQueue", true, consumer);
            Console.WriteLine("Precione [enter] para sair do consumer");

        }

    }

}