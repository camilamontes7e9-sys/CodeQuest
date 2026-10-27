using System;
using System.Collections;
using System.Numerics;
using System.Text;

namespace CodeQuest
{
    public class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            
            //Menu
            const string MenuTitle = "===== MAIN MENU - CODEQUEST =====";
            const string MenuOption1 = "1. Train your wizard";
            const string MenuOption2 = "2. Check the dungeon";
            const string MenuOption3 = "3. Loot the mine";
            const string MenuOptionExit = "0. Exit game";
            const string MenuPrompt = "Choose an option (1-3) - (0) to exit: ";

            //Error control 
            const string ErrorNotNumber = "Error: you must type a number, not text.";
            const string ErrorTooBig = "Error: that number is too big.";
            const string ErrorRange = "Error: the option must be between 0 and 3.";
            const string ErrorNoInput = "Error: no input received.";
            const string ExitMsg = "Exit...";

            //Chapter 1
            const string InputNameMsg = "Enter your name, wizard: ";
            const string DailyMsg = "⌛ Day {0} -> {1}, you have meditated for {2} hours and you have obtained {3} power. Your total poder now is {4}";
            const string LevelUpdateMsg = " ⭐ You have reached level {0}!";
            const string CurrentTitleMsg = "You have the {0} title!";
            const int Days = 5;

            string[] Titles = new[] { 
                "Raoden the Elantri", 
                "Zyn the bugged", 
                "Arka Nullpointer", 
                "Elarion form the embers", 
                "ITB-Wizard the Grey" 
            };
            string[] TitleMessges = new[] {
                "You repeat 2nd convocatory", 
                "You still confuse the wand with a spoon",
                "You are a Summoner of Magical Breezes",
                "Wow! You can summon dragons without burning down the laboratory!",
                "You have reached the rank of Master of the Arcane!"
            }; 
            string inputName, title = Titles[0], titleMsg = "";
            int hours, dailyPower, totalPower = 0, level = 1;

            //Chapter 2

            //Chapter 3

            // Valor centinella: -1 NO és una opció vàlida.
            // El necessitem perquè el compilador no garanteix que 'option' s'assigni
            // dins del try (pot saltar una excepció abans d'arribar a l'assignació).

            int input = -1;
            bool isValid;
            Random rnd = new Random();

            do
            {
                isValid = false; // A cada volta suposem que l'entrada NO és vàlida

                Console.WriteLine(MenuTitle);
                Console.WriteLine(MenuOption1);
                Console.WriteLine(MenuOption2);
                Console.WriteLine(MenuOption3);
                Console.WriteLine(MenuOptionExit);
                Console.Write(MenuPrompt);

                try
                {
                    // int.Parse pot llançar: FormatException, OverflowException
                    // o ArgumentNullException (si ReadLine retorna null amb Ctrl+Z / Ctrl+D)
                    input = int.Parse(Console.ReadLine());

                    // Validació de rang: si no es compleix, LLANÇEM nosaltres l'excepció
                    if (input < 0 || input > 3)
                    {
                        throw new ArgumentOutOfRangeException(nameof(input), ErrorRange);
                    }

                    // Si arribem aquí no ha saltat cap excepció: entrada vàlida
                    isValid = true;
                    Console.WriteLine($"You chose: {input}");
                }
                catch (FormatException)              // Text que no és un número: "abc", "3.5", ""
                {
                    Console.WriteLine(ErrorNotNumber);
                }
                catch (OverflowException)            // Número que no cap en un int: "99999999999"
                {
                    Console.WriteLine(ErrorTooBig);
                }
                catch (ArgumentNullException)        // ReadLine ha retornat null
                {
                    Console.WriteLine(ErrorNoInput);
                }
                catch (ArgumentOutOfRangeException)  // La que hem llançat nosaltres pel rang
                {
                    Console.WriteLine(ErrorRange);
                }
                finally
                {
                    // S'executa SEMPRE: hi hagi error o no
                    Console.WriteLine("----------------------------");
                }

                // Repetim si l'entrada ha estat invàlida O si no han demanat sortir.
                // Comprovem primer !isValid perquè, amb un error, 'option' pot
                // valer 0 d'una volta anterior.

                switch (input)
                {
                    case 1:
                        //Chapter 1

                        Console.WriteLine(InputNameMsg);
                        inputName = Console.ReadLine();

                        for(int day = 1; day < Days; day++)
                        {
                            hours = rnd.Next(25);
                            dailyPower = rnd.Next(11);

                            totalPower += dailyPower;
                            level = 1 + (totalPower / 10);

                            Console.WriteLine(DailyMsg, day, inputName, hours, dailyPower, totalPower);

                            if (totalPower > 10)
                            {
                                Console.WriteLine(LevelUpdateMsg, level);
                            }
                        }

                        if (totalPower < 20)
                        {
                            title = Titles[0];
                            titleMsg = TitleMessges[0];
                        }
                        else if (totalPower >= 20 && totalPower < 30)
                        {
                            title = Titles[1];
                            titleMsg = TitleMessges[1];
                        }
                        else if (totalPower >= 30 && totalPower < 35)
                        {
                            title = Titles[2];
                            titleMsg = TitleMessges[2];
                        }
                        else if (totalPower >= 35 && totalPower < 40)
                        {
                            title = Titles[3];
                            titleMsg = TitleMessges[3];
                        }
                        else if (totalPower >= 40)
                        {
                            title = Titles[4];
                            titleMsg = TitleMessges[4];
                        }


                        Console.WriteLine(titleMsg);
                        Console.WriteLine(CurrentTitleMsg, title);

                        break;

                    case 2:
                        //Chapter 2

                        break;

                    case 3:
                        //Chapter 3

                        break;

                    case 0:
                        //Exit
                        Console.WriteLine(ExitMsg);
                        break; 
                }
            } while (!isValid || input != 0);
        }
    }
} 