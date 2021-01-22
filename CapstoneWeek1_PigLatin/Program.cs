using System;

namespace CapstoneWeek1_PigLatin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Pig Latin Translator!");
            bool translatorRunning = true;

            while (translatorRunning == true)
            {

                //Prompt user for a word
                Console.WriteLine("Enter a line to be translated: ");

                //store input as a variable

                string input = Console.ReadLine().ToLower();

                //if input is null or whitespace prompt user to try again and go to top of loop

                if(string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("invalid data, please try again");
                    continue;
                }

                //translate into piglatin and display on consul
                foreach(string word in StringToArray(input)) 
                {
                    //don't translate extra spaces Ex: 2 spaces between words (remove the extra space)
                    if(word == "" || word == null)
                    {
                        continue;
                    }
                    Console.Write(TranslatePigLatin(word) + " ");
                }
                //Application asks user if they want to translate another word
                

                translatorRunning = YesNoValidation();


            }
        }

        public static string TranslatePigLatin(string word)
        {
            //does the word contain symbol? if yes- don't translate
            
            if (ContainsSymbol(word) == true)
            {
                return word;
            } 
            //does the word contain a number? if yes - don't translate
            if (ContainsNumber(word) == true)
            {
                return word;
            }

            //figure out the first letter of the string
            
            string firstletter = word.Substring(0, 1);

            //figure out the last letter of string if ends with punctuation
            char lastletter = word.ToCharArray()[word.Length - 1];
            
            
            if (char.IsPunctuation(lastletter) == true)
            {
                string translatedWord;
                translatedWord = TranslateWithPunctuation(word);
                return translatedWord;
            }

            //if starts with vowel
            if (firstletter == "a" || firstletter == "e" || firstletter == "i" || firstletter == "o" || firstletter == "u")
            {

                return word + "way";
            }
            else if (IsIndexOfVowel(word) != -1)
            {
                string wordStartingWithFirstVowel = word.Substring(IsIndexOfVowel(word));
                string wordBeforeFirstVowel = word.Substring(0, IsIndexOfVowel(word));

                return wordStartingWithFirstVowel + wordBeforeFirstVowel + "ay";

            }
            else
            {
                return word + "way";

            }

        }

        public static bool YesNoValidation()
        {
            Console.WriteLine();

            Console.WriteLine("Do you want to translate another word (y/n)");

            bool questionAnswered = false;
            while (questionAnswered == false)
            {
                string yesOrNo = Console.ReadLine();
                if (yesOrNo == "n")
                {
                    Console.WriteLine("Goodbye!");
                    questionAnswered = true;
                    return false;

                }
                else if (yesOrNo == "y")
                {
                    Console.WriteLine("yay");
                    questionAnswered = true;
                    return true;
                }
                else
                {
                    Console.Beep();
                    Console.WriteLine("invalid answer");
                }
            }
            return false;
        }

        public static string[] StringToArray(string input)
        {
            string[] sentence = input.Split();

            return sentence;
        }

        public static bool ContainsSymbol(string word)
        {

            char[] lettersInWord = word.ToCharArray();
            int count = 0;
            foreach (char letter in lettersInWord)
            {


                if (Char.IsSymbol(letter))
                {
                    count++;
                }
            }

            if (count == 0)
            {
                return false;
            }
            return true;
        }

        public static bool ContainsNumber(string word)
        {

            char[] lettersInWord = word.ToCharArray();
            int count = 0;
            foreach (char letter in lettersInWord)
            {


                if (Char.IsDigit(letter))
                {
                    count++;
                }
            }

            if (count == 0)
            {
                return false;
            }
            return true;
        }

        public static int IsIndexOfVowel(string word)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

           return word.IndexOfAny(vowels);
            
        }

        public static string TranslateWithPunctuation(string word)
        {
            string firstletter = word.Substring(0, 1);

            //if starts with vowel

            string lastLetter = word.Substring(word.Length - 1);
            string wordWithoutLastLetter = word.Substring(0, word.Length - 2);

            if (firstletter == "a" || firstletter == "e" || firstletter == "i" || firstletter == "o" || firstletter == "u")
            {
                
                

                return wordWithoutLastLetter + "way" + lastLetter;
            }
            else if (IsIndexOfVowel(word) != -1)
            {
                string wordStartingWithFirstVowel = word.Substring(IsIndexOfVowel(word), word.Length-2);
                string wordBeforeFirstVowel = word.Substring(0, IsIndexOfVowel(word));

                return wordStartingWithFirstVowel + wordBeforeFirstVowel + "ay" + lastLetter;

            }
            else
            {
                return wordWithoutLastLetter + "way" + lastLetter;

            }
        }
    }
}