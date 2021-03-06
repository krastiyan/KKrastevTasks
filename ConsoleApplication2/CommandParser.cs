﻿using System;
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
                    if (!isAddCommandCorrect(extractedCommand))
                    {
                        throw new FormatException($"Invalid {commandFound} passed - check syntax!");
                    }
                    break;
                case SupportedCommands.find:
                    if (!isFindCommandCorrect(extractedCommand))
                    {
                        throw new FormatException($"Invalid {commandFound} passed - check syntax!");
                    }
                    break;
                case SupportedCommands.serialize:
                    if (!isSerializeCommandCorrect(extractedCommand))
                    {
                        throw new FormatException($"Invalid {commandFound} passed - check syntax!");
                    }
                    break;
                default: throw new ArgumentException($"Unrecognized command passed: {command} ");
            }
            return extractedCommand;
        }

        private static string[] extractCommand(string command)
        {
            return command.Split(new string[] { "(", ")", ",", "\"", ";"}, StringSplitOptions.RemoveEmptyEntries);
        }

        public static bool isAddCommandCorrect(string[] command)
        {
            int commandLength = (command[command.Length - 1].StartsWith("//")) ? command.Length - 1 : command.Length;
            return (commandLength == 4 || commandLength == 5);
        }

        public static bool isFindCommandCorrect(string[] command)
        {
            int commandLength = (command[command.Length - 1].StartsWith("//")) ? command.Length - 1 : command.Length;
            return ((commandLength == 2 || commandLength == 3) && (command[commandLength - 1].Contains('/') || command[commandLength - 1].Contains('\\')));
        }

        public static bool isSerializeCommandCorrect(string[] command)
        {
            int commandLength = (command[command.Length - 1].StartsWith("//")) ? command.Length - 1 : command.Length;
            return (commandLength == 4 && (command[commandLength-1].Equals("XML") || command[commandLength - 1].Equals("JSON")));
        }
    }//class
}
