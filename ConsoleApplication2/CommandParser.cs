using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp
{
    public class CommandParser
    {
        public static string[] ParseCommand(string command)
        {
            string[] extractedCommand = extractCommand(command);
            SupportedCommands commandFound = (SupportedCommands)Enum.Parse(typeof(SupportedCommands), extractedCommand[0]);
            switch (commandFound)
            {
                case SupportedCommands.Add:
                    if (AddCommandCorrect(extractedCommand))
                    { }
                    else
                    {
                        throw new FormatException($"Invalid {commandFound} passed - check synytaxis!");
                    }
                    break;
                case SupportedCommands.find:
                    if (FindCommandCorrect(extractedCommand))
                    { }
                    else
                    {
                        throw new FormatException($"Invalid {commandFound} passed - check synytaxis!");
                    }
                    break;
                case SupportedCommands.serialize:
                    if (SerializeCommandCorrect(extractedCommand))
                    { }
                    else
                    {
                        throw new FormatException($"Invalid {commandFound} passed - check synytaxis!");
                    }
                    break;
                default: throw new ArgumentException($"Unrecognized command passed: {command} ");
            }
        }

        private static string[] extractCommand(string command)
        {
            return command.Split(new string[] { "(", ")", ",", "\"", ";"}, StringSplitOptions.RemoveEmptyEntries);
        }

        public static bool AddCommandCorrect(string[] command)
        {
            int commandLength = (command[command.Length - 1].StartsWith("//")) ? command.Length - 1 : command.Length;
            return (commandLength == 4 || commandLength == 5);
        }

        public static bool FindCommandCorrect(string[] command)
        {
            int commandLength = (command[command.Length - 1].StartsWith("//")) ? command.Length - 1 : command.Length;
            return ((commandLength == 2 || commandLength == 3) && (command[commandLength - 1].Contains('/') || command[commandLength - 1].Contains('\\')));
        }

        public static bool SerializeCommandCorrect(string[] command)
        {
            int commandLength = (command[command.Length - 1].StartsWith("//")) ? command.Length - 1 : command.Length;
            return (commandLength == 4 && (command[commandLength-1].Equals("XML") || command[commandLength - 1].Equals("JSON")));
        }
    }//class
}
