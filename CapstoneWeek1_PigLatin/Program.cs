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
                string ogInput = Console.ReadLine();
                string input = ogInput.ToLower();

                //if input is null or whitespace prompt user to try again and go to top of loop

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Invalid data. Please enter something to be translated.");
                    continue;
                }

                //translate into piglatin and display on consul
                //Look at each word individually
                string[] arrayOfWords = StringToArray(input);
                string[] lowerTranslatedPigLatin = new string[arrayOfWords.Length];
                for (int i = 0; i < arrayOfWords.Length; i++)
                {
                    //don't translate spaces if multiple spaces in the text/weren't removed when going to an array
                    if (string.IsNullOrEmpty(arrayOfWords[i]))
                    {
                        lowerTranslatedPigLatin[i] = " ";

                        continue;
                    }



                    lowerTranslatedPigLatin[i] = TranslatePigLatin(arrayOfWords[i]);

                }

                // Let't try to translate the piglatin back into the Original case format
                string[] ogWords = ogInput.Split();


                int numberOfWordsInString = ogWords.Length;

                //Let's look at each letter of the ogWords
                string[] correctCaseTranslation;
                correctCaseTranslation = new string[numberOfWordsInString];

                for (int i = 0; i < numberOfWordsInString; i++)
                {

                    correctCaseTranslation[i] = FixCase(ogWords[i], lowerTranslatedPigLatin[i]);
                }
                string finalResult = String.Join(" ", correctCaseTranslation);

                Console.WriteLine(finalResult);


                //Application asks user if they want to translate another word


                translatorRunning = YesNoValidation();


            }
        }

        public static string TranslatePigLatin(string arrayOfWords)
        {
            //does the word contain symbol? if yes- don't translate

            if (ContainsSymbol(arrayOfWords) == true)
            {
                return arrayOfWords;
            }
            //does the word contain a number? if yes - don't translate
            if (ContainsNumber(arrayOfWords) == true)
            {
                return arrayOfWords;
            }

            //figure out the first letter of the string

            string firstletter = arrayOfWords.Substring(0, 1);

            //figure out the last letter of string if ends with punctuation
            char lastletter = arrayOfWords.ToCharArray()[arrayOfWords.Length - 1];


            if (char.IsPunctuation(lastletter) == true)
            {
                string translatedWord;
                translatedWord = TranslateWithPunctuation(arrayOfWords);
                return translatedWord;
            }
            int indexOfY = arrayOfWords.IndexOf('y');

            //if starts with vowel

            if (firstletter == "a" || firstletter == "e" || firstletter == "i" || firstletter == "o" || firstletter == "u")
            {

                return arrayOfWords + "way";
            }
            else if (IsIndexOfVowel(arrayOfWords) != -1)
            {
                string wordStartingWithFirstVowel = arrayOfWords.Substring(IsIndexOfVowel(arrayOfWords));
                string wordBeforeFirstVowel = arrayOfWords.Substring(0, IsIndexOfVowel(arrayOfWords));

                return wordStartingWithFirstVowel + wordBeforeFirstVowel + "ay";

            }
            else if (indexOfY != -1)
            {
                string wordStartingWithFirstY = arrayOfWords.Substring(arrayOfWords.IndexOf('y'));
                string wordBeforeY = arrayOfWords.Substring(0, arrayOfWords.IndexOf('y'));

                return wordStartingWithFirstY + wordBeforeY + "ay";
            }
            else
            {
                return arrayOfWords + "way";

            }

        }

        public static bool YesNoValidation()
        {
            Console.WriteLine();

            Console.WriteLine("Do you want to translate another word (y/n)");

            bool questionAnswered = false;
            while (questionAnswered == false)
            {

                string yesOrNo = Console.ReadLine().ToLower();
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
                    Console.WriteLine("Invalid answer. Play again? y/n?");
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
                if (letter.Equals('@'))
                {
                    count++;
                }


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

            int indexOfy = word.IndexOf('y');

            string lastLetter = word.Substring(word.Length - 1);
            string wordWithoutLastLetter = word.Substring(0, word.Length - 1);

            if (firstletter == "a" || firstletter == "e" || firstletter == "i" || firstletter == "o" || firstletter == "u")
            {



                return wordWithoutLastLetter + "way" + lastLetter;
            }
            else if (IsIndexOfVowel(word) != -1)
            {
                string wordStartingWithFirstVowel = word.Substring(IsIndexOfVowel(word), word.Length - 1 - IsIndexOfVowel(word));
                string wordBeforeFirstVowel = word.Substring(0, IsIndexOfVowel(word));

                return wordStartingWithFirstVowel + wordBeforeFirstVowel + "ay" + lastLetter;

            }
            else if (indexOfy != -1)
            {
                string wordStartingWithFirstY = word.Substring(word.IndexOf('y'), word.Length - 1 - word.IndexOf('y'));
                string wordBeforeY = word.Substring(0, word.IndexOf('y'));

                return wordStartingWithFirstY + wordBeforeY + "ay" + lastLetter;
            }
            else
            {

                return wordWithoutLastLetter + "way" + lastLetter;

            }
        }

        public static string FixCase(string ogWords, string lowerTranslatedPigLatin)
        {
            char[] ogWord = ogWords.ToCharArray();
            char[] lowerTranslatedPigWord = lowerTranslatedPigLatin.ToCharArray();
            char[] fixedCase = new char[lowerTranslatedPigLatin.Length];

            {
                for (int e = 0; e < ogWord.Length; e++)
                {
                    if (Char.IsUpper(ogWord[e]) == true)
                    {
                        fixedCase[e] = Char.ToUpper(lowerTranslatedPigWord[e]);

                    }
                    else
                    {

                        fixedCase[e] = lowerTranslatedPigWord[e];

                    }
                }

                for (int f = ogWord.Length; f < lowerTranslatedPigWord.Length; f++)
                {
                    fixedCase[f] = lowerTranslatedPigWord[f];
                }
                string fixedCaseTranslation = new string(fixedCase);

                string sendToUser = string.Join("", fixedCaseTranslation);
                return sendToUser;

            }
        }
    }
}