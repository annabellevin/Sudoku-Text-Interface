using System;
using System.Collections;
using System.Linq;
using System.Text.RegularExpressions;


namespace myApp
{
    class Program
    {
        static public int size;
        static public Sudoku Sudoku;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello User. What size sudoku do you like?");
                while (!int.TryParse(Console.ReadLine(), out size)) {
                     Console.WriteLine("Invalid number entered. Please enter an integer from 1 - 10");
                }
                //create and print an empty a*a sudoku
                    Console.WriteLine("Cool. Creating a sudoku of size "+ size);
                    Sudoku = new Sudoku(size);
                    Sudoku.printSudoku();
                    Sudoku.commandLoop();
                    
                
                    
        }

    }

    class Sudoku
    {
        public string[] values;
        public int size;
        
        public Sudoku(int sizeN)
        {
             size = sizeN;
             values = Enumerable.Repeat("x", size*size).ToArray();
        }

        public void commandLoop()
        {
            string cmd;
             while (true) {
                    cmd = Console.ReadLine();
                   // Console.WriteLine(cmd);
                    switch (cmd)
                    {
                       case "q":
                            Console.WriteLine("Quitting app.");
                            Environment.Exit(0);
                            break;
                        case "clear":
                            clearSudoku();
                            Console.WriteLine("Sudoku cleared.");
                            break;

                        case var someVal when new Regex(@"set [0-8] [0-8] [1-9]").IsMatch(someVal):
                            Console.WriteLine(cmd.Split(" ")[1]);
                            bool tryP = true; 
                            int rowNum;
                            int colNum;
                            int valNum;
                            int.TryParse(cmd.Split(" ")[1], out rowNum);
                            int.TryParse(cmd.Split(" ")[2], out colNum);
                            int.TryParse(cmd.Split(" ")[3], out valNum);
                            if (!tryP) Console.WriteLine("Incorrect input added. Try again");
                            setItem(rowNum, colNum, valNum);
                            break;
                        default:
                            Console.WriteLine("Default case");
                            Console.WriteLine(cmd);
                            break; 
                    }
                     printSudoku();
                     if(isSolved())
                     {
                         Console.WriteLine("YOU WON!!!!!!!");
                         Environment.Exit(0);
                     }
                }
        }


        public void setItem(int r, int c, int val){
           try
           {    
                if ((c >= size) || (r >= size) || (val >= 10) || (val <= 0))
                {
                    throw new Exception();
                } 
                values[r*size + c] = val.ToString();
           } 
           catch (Exception e){
                Console.WriteLine("Out of bounds input added. Try again");
           }
        }


        public bool isSolved(){
           // return true; 
            return false;
            //check squares
            //check rows
            //check cols
        }
        

        public void clearSudoku(){
            values = Enumerable.Repeat("x", size*size).ToArray();
        }

        public void printSudoku()
        {
            for(int i = 0; i < 6*size; i++){
                            Console.Write("-");
                        }
                        Console.Write("\n");
                    for(int row=0; row < size; row++){
                        for(int col=0; col < size; col++){
                            Console.Write("|  " + values[row*size + col] + "  ");
                        }
                        Console.Write("|\n");
                        for(int i = 0; i < 6*size; i++){
                            Console.Write("-");
                        }
                        Console.Write("\n");
                    }
        }
    }
}
