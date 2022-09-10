// See https://aka.ms/new-console-template for more information

namespace bank                                                                // Баловался с пространством имён
{
    class Trade
    {
        public static void DollarToRu()
        {
            Console.Write("Введите ваш баланс в долларах($): ");
            var userInput = Console.ReadLine();
            decimal RuCourse = 63.7m, comission = 0.37m, balance = 0.0m;
            while(!decimal.TryParse(userInput, out balance))                     // Ждём корректного ввода пользователя
            {
                Console.Write("Введите ваш баланс в долларах($): ");
                userInput = Console.ReadLine();
            }
            var ruBalance = balance > 500 ? balance * RuCourse / 100 * (100 - comission): balance * RuCourse - 8; 

                Console.WriteLine($"Ваш баланс в рублях по курсу 63,7 с учётом комиссии: {ruBalance: ###,###.##} руб.");
        }
    }
    class Program                                       // Тут я просто баловался с классами, по сути можно всё сделать через один Main()
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Trade.DollarToRu();
            Console.ReadLine();
        }
    }
}


