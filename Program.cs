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

            //Chapter 1

            //Chapter 2

            //Chapter 3

            // Valor centinella: -1 NO és una opció vàlida.
            // El necessitem perquè el compilador no garanteix que 'option' s'assigni
            // dins del try (pot saltar una excepció abans d'arribar a l'assignació).

            int input = -1;
            bool isValid;

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
                    case 1: break;
                    //Chapter 1

                    case 2:  break;
                    //Chapter 2

                    case 3: break;
                    //Chapter 3

                    case 0: break; 
                }
            } while (!isValid || input != 0);
        }
    }
} 