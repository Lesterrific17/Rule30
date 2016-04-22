using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rule_30
{
    class Program{
        static void Main(string[] args){
            R30Printer rp = new R30Printer();
            Console.Write("Enter Binary Seed: ");
            string Seed = Console.ReadLine();
            Console.Write("\n\nHow many Generations? ");
            int GenCount = int.Parse( Console.ReadLine() );
            Console.WriteLine();
            rp.Generate(Seed, GenCount);
        }
    }

    class R30Printer{

        public List<string> Seeds;
        public List<char> Results;

        public R30Printer(){
            Seeds = new List<string>();
            Results = new List<char>();
            AddRule("111", '0');
            AddRule("110", '0');
            AddRule("101", '0');
            AddRule("100", '1');
            AddRule("011", '1');
            AddRule("010", '1');
            AddRule("001", '1');
            AddRule("000", '0');
            //PrintRules();
        }

        void AddRule(string Seed, char Result) {
            Seeds.Add(Seed);
            Results.Add(Result);
        }
        
        public void Generate(string Seed, int GenerationCount) {
            char[] InitialGeneration = Seed.ToCharArray();
            

            PrintGeneration(InitialGeneration);
            for(int g = 0; g < GenerationCount; g++) {
                char[] NextGeneration = Evolve(InitialGeneration);
                PrintGeneration(NextGeneration);
                InitialGeneration = NextGeneration;
            }

        }

        public char[] Evolve(char[] PreviousGen) {
            char[] NextGen = new char[PreviousGen.Length];

            for (int i = 0; i < PreviousGen.Length; i++) {
                string r = "";
                if((i - 1) >= 0) {
                    r = PreviousGen[i - 1].ToString();
                }
                else {
                    r = "0";
                }
                r = r + PreviousGen[i];
                if(i + 1 <= (PreviousGen.Length - 1)) {
                    r = r + PreviousGen[i + 1];
                }
                else {
                    r = r + "0";
                }
                //Console.Write(r + " ");
                NextGen[i] = Results.ElementAt(Seeds.IndexOf(r));
            }
            //Console.WriteLine();
            return NextGen;
        }

        void PrintGeneration(char[] Generation) {
            for (int i = 0; i < Generation.Length; i++) {
                Console.Write(Generation[i] + " ");
            }
            Console.WriteLine();
        }
    }

}
