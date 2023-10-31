using RabbitMQ.Client;
using System.Text;


public static class Sender
{
    public static void Publicar() {

        var factory = new ConnectionFactory
        {
            HostName = "localhost",
            UserName = "guest",
            Password = "guest"
        };


        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare("BrenoQueue", false, false, false);

            var message = "Bem vindo ao currso de  RabbitMQ em .NET";

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(
                        exchange: "",
                        routingKey: "BrenoQueue",
                        basicProperties: null,
                        body: body
                    );

            Console.WriteLine("Menssagem foi enviada");
        }
    }
}