using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorHasel
{
    public class Generator
        {
        private readonly string[] alphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "W", "Y", "Z" };
        private readonly string[] alphabetLitle = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "r", "s", "t", "u", "w", "y", "z" };
        private readonly string[] alphabetNumeric = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
        private readonly string[] alphabetSpecial = { "!", "@", "#", "$", "%", "&", "*", "(", ")", "-", "=", "+" };
        private readonly string[] alphabetSpecial2 = { "{", "}", "[", "]", "<", ">", "/", "?" };

        private string result;
        private readonly Random rnd = new Random();

        public string GeneratePassword(int length, string allowedTypes = "all")
            {
            // Lista zestawów znaków, które mogą być używane
            var characterPools = new List<string[]>();

            // Dodaj odpowiednie grupy znaków na podstawie `allowedTypes`
            if (allowedTypes == "all" || allowedTypes.Contains("upper")) characterPools.Add(alphabet);
            if (allowedTypes == "all" || allowedTypes.Contains("lower")) characterPools.Add(alphabetLitle);
            if (allowedTypes == "all" || allowedTypes.Contains("numeric")) characterPools.Add(alphabetNumeric);
            if (allowedTypes == "all" || allowedTypes.Contains("special1")) characterPools.Add(alphabetSpecial);
            if (allowedTypes == "all" || allowedTypes.Contains("special2")) characterPools.Add(alphabetSpecial2);

            // Jeśli nie wybrano żadnych zestawów znaków, zgłoś wyjątek
            if (characterPools.Count == 0)
                throw new ArgumentException("No valid character types specified. Use: all, upper, lower, numeric, special1, special2.");

            var password = new List<string>();

            // Generowanie hasła
            for (int i = 0; i < length; i++)
                {
                var selectedPool = characterPools[rnd.Next(characterPools.Count)];
                password.Add(selectedPool[rnd.Next(selectedPool.Length)]);
                }

            this.result = string.Join("", password);
            return this.result;
            }

        public void SaveToFile()
            {
            if (string.IsNullOrEmpty(this.result))
                throw new InvalidOperationException("No password generated to save.");

            File.WriteAllText("Password.txt", this.result);
            }
        }
    } 
