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
        private string[] alphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "W", "Y", "Z" };
        private string[] alphabetLitle = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "r", "s", "t", "u", "w", "y", "z" };
        private string[] alphabetNumeric= { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
        private string[] alphabetSpecial = { "!", "@", "#", "$", "%", "&", "*", "(", ")", "-", "=", "+" };
		private string[] alphabetSpecial2 = { "{", "}", "[", "]", "<", ">", "/", "?" };
		private string result;
        Random rnd = new Random();
        public string GeneratePassword(int LongPassword)
        {
            var Password = new List<string>();
            for (int i = 0; i < LongPassword; i++)
            {
                int RandomTable = rnd.Next(1, 6);
                if (RandomTable == 1)
                {
                    Password.Add(alphabet[rnd.Next(0, alphabet.Count())]);
                }
                if (RandomTable == 2)
                {
                    Password.Add(alphabetLitle[rnd.Next(0, alphabetLitle.Count())]);
                }
                if (RandomTable == 3)
                {
                    Password.Add(alphabetNumeric[rnd.Next(0, alphabetNumeric.Count())]);
                }
                if (RandomTable == 4)
                {
                    Password.Add(alphabetSpecial[rnd.Next(0, alphabetSpecial.Count())]);
                }
				if (RandomTable == 5)
				{
					Password.Add(alphabetSpecial2[rnd.Next(0, alphabetSpecial2.Count())]);
				}
			}
            this.result = string.Join("", Password);
            return this.result;
        }

     public /*async Task*/ void SaveToFileAsync()
        {
             File.WriteAllText("Password.txt",this.result);
            
           //await File.WriteAllTextAsync("Password.txt", this.result);
        }
    }
} 
