
using System;
using System.Text;
//
//Cette version de FooBar est la plus simple qui me soit venu à l'esprit, 
//n'étant pas un expert .NET, mais donc pas la plus naturelle.
//Il est certain qui y aura presque autant de variation qu'il y a de développeur C#.
//Il est aussi certain qu'une telle version est difficilmement "TDDisable".
//Les voies d'amélioration sont donc multiplent, par exemple l'usage de fonction ex:
//new StringBuilder.Insert  ===>   string stringRepeater(uint repeat, string theString) => {for (int i = 0; i<repeat; i++){theString += theString;} return theString;}
//theInput.Split('').Length - 1 ===> int charCounter(string theInput, char theChar){int counter = 0;foreach (char readedChar in theInput) if(readedChar == theChar) counter++;return counter;
//Afin d'éviter tout effet de bord et apporter de la clarté.
//La prochaine version (FooBarDesignPatternWay), plus naturelle à lecture de l'énnoncée, introduira le design pattern Rule en version dédiée.
//
namespace FooBarSimpliestWay
{
   
    class MainClass
    {
        Func<int, uint, bool> isDevided = (value, divide) => (value % divide) == 0;
        Func<string> genFoo = () => "Foo";


        public static void Main(string[] args)
        {
            string inputLine;

            while (true)
            {
                inputLine = Console.ReadLine();

                Console.WriteLine(" " + inputLine + " ==> " + MainClass.Compute(inputLine));
            }
        }

        static string Compute(string theInput)
        {
            int numValue;
            string result = "";
            bool parsed = Int32.TryParse(theInput, out numValue);

            if (parsed == false) return " Please enter a valid Digit Sequence";
            // Step 1
            if (numValue % 3 == 0) result += "Foo";
            if (numValue % 5 == 0) result += "Bar";
            if (numValue % 7 == 0) result += "Qix";

            int count3 = theInput.Split('3').Length - 1;
            int count5 = theInput.Split('5').Length - 1;
            int count7 = theInput.Split('7').Length - 1;


            result += new StringBuilder().Insert(0, "Foo", count3).ToString();
            result += new StringBuilder().Insert(0, "Bar", count5).ToString();
            result += new StringBuilder().Insert(0, "Qix", count7).ToString();

            // Step 2
            if (result.Length == 0)
            {
                result = new StringBuilder("" + numValue).Replace('0', '*').ToString();
            }
            else
            {
                int countEtoile = theInput.Split('0').Length - 1;
                result += new StringBuilder().Insert(0, "*", countEtoile).ToString();
            }
            return result;

        }
    }
}
