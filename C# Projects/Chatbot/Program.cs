using System;

namespace Chatbot
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "Cybersecurity Awareness Chatbot";

            try
            {
                string audioPath = @"C:\Users\chuma\OneDrive\Desktop\Portfolio\C# Projects\Chatbot\greeting.wav";

                // Play intro + banner
                SecurityChatbot botAudio = new SecurityChatbot(audioPath);
                botAudio.Greet();

                // Ask user for name with validation
                string username;
                do
                {
                    Console.Write("\nPlease enter your name: ");
                    username = Console.ReadLine();
                    if (!InputValidator.IsValid(username))
                    {
                        Console.WriteLine("Please enter a valid name (at least 2 characters)");
                    }
                } while (!InputValidator.IsValid(username));

                // Start main chat session
                SecurityChatbot bot = new SecurityChatbot(username, audioPath);
                bot.StartChat();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"⚠️ An unexpected error occurred: {ex.Message}");
                Console.ResetColor();
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}