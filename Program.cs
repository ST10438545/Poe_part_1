using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Media;
using System.Speech.Synthesis;

namespace Poe_part_1
{
    internal class Program
    {
        // Automatic properties for user profile
        public class UserProfile
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string FullName => FirstName + " " + LastName; // Read-only property using concatenation
        }

        static void Main(string[] args)
        {
            // Display ASCII Art logo
            DisplayLogo();

            // Play the voice greeting
            PlayGreeting();

            UserProfile user = new UserProfile();

            // Get user input
            user.FirstName = GetUserInput("Enter your first name: ");
            user.LastName = GetUserInput("Enter your last name: ");

            // Display welcome message after gathering user input
            DisplayWelcomeMessage(user.FullName);

            // Interact with the user to respond to basic questions
            RespondToQuestions();

            Console.ReadLine(); // Wait for user to close the console
        }

        // Method to display ASCII art logo
        static void DisplayLogo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string logo = @"
     _,.----.  ,--.-,,-,--,   ,---.   ,--.--------.                       _,.---._    ,--.--------.  
 .' .' -   \/==/  /|=|  | .--.'  \ /==/,  -   , -\           _..---.  ,-.' , -  `. /==/,  -   , -\ 
/==/  ,  ,-'|==|_ ||=|, | \==\-/\ \\==\.-.  - ,-./         .' .'.-. \/==/_,  ,  - \\==\.-.  - ,-./ 
|==|-   |  .|==| ,|/=| _| /==/-|_\ |`--`\==\- \           /==/- '=' /==|   .=.     |`--`\==\- \    
|==|_   `-' \==|- `-' _ | \==\,   - \    \==\_ \          |==|-,   '|==|_ : ;=:  - |     \==\_ \   
|==|   _  , |==|  _     | /==/ -   ,|    |==|- |          |==|  .=. \==| , '='     |     |==|- |   
\==\.       /==|   .-. ,\/==/-  /\ - \   |==|, |          /==/- '=' ,\==\ -    ,_ /      |==|, |   
 `-.`.___.-'/==/, //=/  |\==\ _.\=\.-'   /==/ -/         |==|   -   / '.='. -   .'       /==/ -/   
            `--`-' `-`--` `--`           `--`--`         `-._`.___,'    `--`--''         `--`--`  
                                                             
                    Cybersecurity Awareness Bot
";
            Console.WriteLine(logo);
            Console.ResetColor();
        }

        // Method to play the greeting audio using speech synthesis
        static void PlayGreeting()
        {
            try
            {
                string audioFilePath = @"C:\Users\RC_Student_lab\source\repos\Poe_part_1\audio\bot.wav";
                SoundPlayer player = new SoundPlayer(audioFilePath);
                player.PlaySync();// Play the audio file
            }
            catch (Exception ex) // Error should Audio be unable to play
            {
                Console.WriteLine("Error playing audio: " + ex.Message);
            }
        }

        // Method to get user input and validate it
        static string GetUserInput(string prompt)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input cannot be empty. Please provide a valid input.");
                    Console.ResetColor();
                }
            } while (string.IsNullOrEmpty(input));

            return input;
        }

        // Method to display a personalized welcome message
        static void DisplayWelcomeMessage(string fullName)
        {
            Console.WriteLine("\n" + new string('*', 50));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Welcome to the Cybersecurity Awareness Bot, {fullName}!");
            Console.ResetColor();
            Console.WriteLine("We are here to help you stay safe online.");
            Console.WriteLine(new string('*', 50) + "\n");
        }

        // Method to respond to basic cybersecurity-related questions
        static void RespondToQuestions()
        {
            Console.WriteLine("Feel free to ask me any questions related to cybersecurity!");

            SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            {
                while (true)
                {
                    Console.Write("\nAsk me a question (type 'exit' to quit): ");
                    string question = Console.ReadLine().ToLower().Trim();

                    if (question == "exit")
                    {
                        break;
                    }

                    if (string.IsNullOrEmpty(question))
                    {
                        TypingEffect("I didn't quite understand that. Could you rephrase?", synthesizer);
                        continue;
                    }

                    // Handle valid questions
                    switch (question)
                    {
                        case "how are you?":
                            TypingEffect("I'm just a program, but I'm here to help you stay safe online!", synthesizer);
                            break;
                        case "what's your purpose?":
                            TypingEffect("My purpose is to provide information and guidance on cybersecurity best practices.", synthesizer);
                            break;
                        case "what can i ask you about?":
                            TypingEffect("You can ask me about various topics, including password safety, phishing, safe browsing, and general cybersecurity tips.", synthesizer);
                            break;
                        case "what can you tell me about password safety?":
                            TypingEffect("Use strong passwords that are at least 12 characters long, include a mix of letters, numbers, and symbols, and avoid using the same password across multiple sites.", synthesizer);
                            break;
                        case "what are some tips for creating a strong password?":
                            TypingEffect("Combine upper and lowercase letters, numbers, and special characters. Avoid using easily guessed information like birthdays or names.", synthesizer);
                            break;
                        case "what can you tell me about phishing?":
                            TypingEffect("Phishing is a method used by cybercriminals to trick you into providing personal information. Always verify the source of emails and never click on suspicious links.", synthesizer);
                            break;
                        case "how can I identify a phishing attempt?":
                            TypingEffect("Look for generic greetings, spelling errors, and urgent calls to action. Always check the URL before clicking.", synthesizer);
                            break;
                        case "what can you tell me about safe browsing?":
                            TypingEffect("To browse safely, ensure your browser is up-to-date, use HTTPS websites, and avoid entering personal information on unfamiliar sites.", synthesizer);
                            break;
                        case "what are some safe browsing practices?":
                            TypingEffect("Always use a secure connection, avoid public Wi-Fi for sensitive transactions, and regularly clear your browser's cache.", synthesizer);
                            break;
                        default:
                            TypingEffect("I'm sorry, I didn't quite understand that. Could you rephrase?", synthesizer);
                            break;
                    }
                }
            }
        }

        // Method to simulate a typing effect and use speech synthesis
        static void TypingEffect(string message, SpeechSynthesizer synthesizer)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(50); // Adjust delay for typing speed
            }
            Console.WriteLine();
            Console.ResetColor();
            synthesizer.Speak(message); // Speak the message
        }

        // Method to reverse a string
        static string ReverseString(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}

