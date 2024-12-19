using System.Text;

namespace Home_Wokr_11._1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
            Console.WriteLine("Вітаємо! Спробуйте вгадати зашифроване слово!");
            string word = "Amsterdam";

            GetLetters(word);

        }


        static void GetLetters(string word)
        {
            int numberOfAttempts = word.Length;

            Console.WriteLine($"Кількість літер у слові: {word.Length}");
            Console.WriteLine($"Кількість можливих невірних спроб: {word.Length}\n");
            bool[] wordGuessed = new bool[word.Length]; //Масив для відслідковування вгаданих літер
            bool guessed = false;


            while (numberOfAttempts > 0 && !guessed) // 1  - коли спроб залишиться 0 або guessed = true 
            {
                Console.Write("Введіть літеру:");
                char input;

                if (!char.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Будь ласка введіть тільки одну літеру");
                    continue;
                }


                bool found = false;
                string position = ""; // Змінна для зберігання позиції літери 
                for (int i = 0; i < word.Length; i++)
                {
                    if (char.ToLower(word[i]) == char.ToLower(input)) // Порівняння за ідексами слова і що вів input 
                    {
                        wordGuessed[i] = true;
                        found = true;
                        position += (i + 1) + " ";
                    }
                }

                if (found)
                {
                    Console.WriteLine($"Літера {input} є у слові! Позиція літери: {position}");
                }
                else
                {
                    numberOfAttempts--;   // віднімаємо спроби
                    Console.WriteLine($"Такої літери немає! Залишилось спроб: {numberOfAttempts}");
                    if (numberOfAttempts == 0)
                    {
                        Console.WriteLine("Game Over");
                        break;
                    }
                }

                guessed = true;
                for (int i = 0; i < word.Length; i++)
                {

                    if (!wordGuessed[i])
                    {
                        guessed = false;
                        break;
                    }
                }

                if (guessed)
                {
                    Console.WriteLine($"Вітаємо, ви вгадали слово! Зашифроване слово: {word.ToString()}");
                    Console.WriteLine("Дякуємо за гру.");
                    break;
                }

            }
        }
    }
}
