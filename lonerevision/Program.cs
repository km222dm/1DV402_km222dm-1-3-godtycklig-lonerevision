using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lonerevision
{
    class Program
    {
        static void Main(string[] args)
        {

            //Läs in ett godtyckligt antal löner med hjälp av en array av typen int[]
            // metoden "Main" ska genom att anropa ReadInt() läsa in antalet löner användaren matar in.

            do
            {
                int numberOfSalaries = 0;
                while (true)
                {
                    numberOfSalaries = ReadInt("Ange antal löner att mata in:   ");
                    Console.WriteLine("");

                    // är antalet löner att bearbeta färre än två ska ett felmeddelande visas.
                    if (numberOfSalaries < 2)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Du måste mata in minst två löner för att kunna göra en beräkning");
                        Console.ResetColor();
                    }
                    else
                    {
                        break;
                    }
                }
                // om antalet är minst 2 ska metoden "ProcessSalaries() anropas och antalet löner att bearbeta
                // skickas med som ett argument. 
                ProcessSalaries(numberOfSalaries);

                
                Console.WriteLine("");
                Console.Write("Tryck på valfri tangent för att börja om");  //användaren ska kunna trycka på vilken tangent som helst för att fortsätta
                Console.WriteLine("");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);      //använd Console.ReadKey (true) .Key !=ConsoleKey.Escape.
                                                                     

        }
        static int ReadInt(string prompt) //Här ligger metoden ReadInt
        {

            while (true)
            {   
                Console.Write(prompt);
                string inputString = Console.ReadLine();
                try
                {
                    
                   int input = int.Parse(inputString); //gör om inputstring från en sring till en int istället så att den siffrorna som värden

                        
                   return input;
                      
                }
                catch   // om man skriver in något annat än vad som ska tolkas ska ett felmeddelande visas
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("FEL! {0} kan inte tolkas som ett heltal", inputString);
                    Console.ResetColor();
                }

            }            
        }
        static void ProcessSalaries(int salariesInput)
        {
            int[] Salaries = new int[salariesInput];
              double median = 0;                        // variabel för median-uträkningen

            for (int i = 0; i < Salaries.Length; i++)
            {
                Salaries[i] = ReadInt (String.Format("Ange lön nummer {0}: ", i+1)); //String.format
            }

            //klonar arrayen till sortedSalaries, de har nu exakt samma värden i exakt samma ordning
            int[] SortedSalaries = (int[])Salaries.Clone();
            //array.sort sorterar sortedSalaries arrayen i stroleksordning. Salaries arrayen är fortfarande i samma ordning som tidigare
            Array.Sort(SortedSalaries);


            //beräkna lönespridning
            //highest salary räknar ut det sista(alltså högst) värdet i den sorterade arrayen. 
            //backa ett steg för att plocka ut det sista värdet
            int highestSalary =  SortedSalaries[SortedSalaries.Length -1 ];

            //lower salary räknar ut det första(alltså lägsta) värdet i den sorterade arrayen.         
            // den första platsen i arrayen innehåller lägsta värdet
            int lowerSalary = SortedSalaries[0];

            //räknar ut mellanskillnaden av lönerna
            int spreadSalary = highestSalary - lowerSalary;
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Lönespridning: {0}", spreadSalary);


            // beräkna medellön
            int average = (int)Math.Round(Salaries.Average(), MidpointRounding.ToEven); // MidpointRounding.ToEven hjälper mathRound att avrunda till närmaste heltal.
            Console.WriteLine("Medellön: {0}", average);

            //beräkna medianlön
            if(SortedSalaries.Length % 2 == 0 ) // om resultatet av den sorterade arryen % 2 är lika med 0 kommer den skriva ut följande:
            {
                int median1 = SortedSalaries[SortedSalaries.Length / 2 -1];  // denna hämtar mittenvärde 1, Arrayens längd / 2, -1 ser till så det blir första mittenvärdet.
                int median2 = SortedSalaries[SortedSalaries.Length / 2];    // denna hämtar mittenvärde 2  Arrayens längd / 2, här tar den automatiskt andra värdet.

                median = (median1 + median2) / 2;  //tar de två mittenvärdena den fick fram från ovanstående uträkning och dela dem med två för att få ut medianen.
            } 
            else {
                median = SortedSalaries[SortedSalaries.Length / 2];  //är längden på arrayen ett ojämnt tal behöver den bara plocka ut ett medianvärde
            }
            
            Console.WriteLine("Medianlön: {0}", (int)Math.Round(median, MidpointRounding.ToEven)); //presenterar medianlönen
            Console.WriteLine("---------------------------------");
            
            
            // presentera lönerna i den ordning användaren matat in dem med 3 löner per rad
             
            //for-loop, i den en switch med hjälp av modulus.(?)
            for (int i = 1; i < Salaries.Length; i++)
            {
                
                if (i % 3 != 0)         // om 1%3 stämmer överrens med 0 kommer den skriva ut lönerna på samma rad.
                {
                   Console.Write("{0,8}", Salaries[i - 1]);
                }
                else                    // stämmer det inte kommer den hoppa ner en rad och fortsätta skriva ut lönerna.
                {
                  Console.Write("{0,8}", Salaries[i - 1]);
                  Console.WriteLine();
                }
            }
            //om det är mer än tre lönevärden, byt rad.
             

            //användaren ska kunna välja att avsluta programmet med hjälp av escape.
            //om man trycker ner någon annan tangent ska användaren på nytt kunnan mata in löner.
    
        }
    }
}
