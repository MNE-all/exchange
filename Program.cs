// See https://aka.ms/new-console-template for more information

using Serilog;
using Serilog.Core;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace bank                                                                // Баловался с пространством имён
{
    class Trade
    {
        public static void DollarToRu()
        {
            
            decimal RuCourse = 63.7m, comission = 0.37m, balance = 0.0m;
            var logger = new LoggerConfiguration().MinimumLevel.Information()
             .Enrich.WithProperty("Курс: ", RuCourse)
             .WriteTo.Seq("http://localhost:5341", apiKey: "RAu7ePctKZSChRb2hqdS")
             .CreateLogger();
            var userInput = "null";

            do                    
            {
                if (userInput != "null")
                {
                    logger.Error("Обмен не прошёл!");

                }
                Console.Write("Введите ваш баланс в долларах($): ");

                logger.Information("Пользователь вводит информацию");

                userInput = Console.ReadLine();
            } while (!decimal.TryParse(userInput, out balance));            // Ждём корректного ввода пользователя
            logger.Information($"Ввод прошел успешно. Пользователь ввел {balance} Долларов");

            logger.Information(balance > 500 ? 
                $"Комиссия(%): {comission}" : 
                $"Комиссия(руб.): {8}");

            var ruBalance = balance > 500 ? 
                balance * RuCourse / 100 * (100 - comission): 
                balance * RuCourse - 8; 

            Console.WriteLine("Ваш баланс в рублях по курсу 63,7 с учётом комиссии: {0:C2}", ruBalance);

            logger.Information("Обмен прошел успешно. Пользователь получил {0:C2} (руб.)", ruBalance);


        }
    }
    class Program                                       
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            do
            {
                Trade.DollarToRu();
                Console.WriteLine("Для выхода - нажмите Ecs\n" +
                    "Нажмите любую другую клавишу для выхода");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}


