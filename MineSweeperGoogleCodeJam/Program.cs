using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperGoogleCodeJam
{
    class Program
    {

        const int BOMBVALUE = 100;
        static int[,] myTable;
        static int lines { get; set; }
        static int cols { get; set; }
        static int bombs { get; set; }

        static void Main(string[] args)
        {
            System.IO.StreamReader sr = new System.IO.StreamReader("c:\\users\\nicolas\\documents\\lol.in");
            int cases = Convert.ToInt32(sr.ReadLine()); 
            for (int myCase = 1; myCase <= cases; myCase++)
            {
                string[] str = sr.ReadLine().Split(' ');
                lines = Convert.ToInt32(str[0]);
                cols = Convert.ToInt32(str[1]); 
                bombs = Convert.ToInt32(str[2]); 
                myTable = new int[lines, cols];
                if (bombs > 0)
                {
                    myTable[0, 0] = BOMBVALUE;
                    bombs--;

                    int colunainicial = 1;
                    int linhainicial = 0;
                    int linetmp = linhainicial;
                    int coltmp = colunainicial;
                    int cont = 0;
                    //Fill bombs
                    while (bombs > 0)
                    {
                        if ((coltmp < 0) || (linetmp >= lines))
                        {
                            colunainicial += 1;
                            if (colunainicial >= cols)
                            {
                                coltmp = cols - 1;
                                linhainicial += 1;
                                linetmp = linhainicial;
                            }
                            else
                            {
                                coltmp = colunainicial;
                                linetmp = 0;
                            }
                        }
                        myTable[linetmp, coltmp] = BOMBVALUE;
                        bombs--;

                        coltmp--;
                        linetmp++;
                        Console.WriteLine(cont++);
                        //print();
                    }

                    //Fill with 0 or sum of neighborhoods
                    for (int line = 0; line < lines; line++)
                    {
                        for (int col = 0; col < cols; col++)
                        {
                            if (myTable[line, col] != BOMBVALUE)
                            {
                                if (line + 1 < lines)
                                    myTable[line, col] += myTable[line + 1, col] == BOMBVALUE ? 1 : 0;
                                if (line + 1 < lines && col + 1 < cols)
                                    myTable[line, col] += myTable[line + 1, col + 1] == BOMBVALUE ? 1 : 0;
                                if (line + 1 < lines && col - 1 > 0)
                                    myTable[line, col] += myTable[line + 1, col - 1] == BOMBVALUE ? 1 : 0;
                                if (line - 1 > 0 && col + 1 < cols)
                                    myTable[line, col] += myTable[line - 1, col + 1] == BOMBVALUE ? 1 : 0;
                                if (line - 1 > 0)
                                    myTable[line, col] += myTable[line - 1, col] == BOMBVALUE ? 1 : 0;
                                if (line - 1 > 0 && col - 1 > 0)
                                    myTable[line, col] += myTable[line - 1, col - 1] == BOMBVALUE ? 1 : 0;
                                if (col - 1 > 0)
                                    myTable[line, col] += myTable[line, col - 1] == BOMBVALUE ? 1 : 0;
                                if (col + 1 < cols)
                                    myTable[line, col] += myTable[line, col + 1] == BOMBVALUE ? 1 : 0;

                            }
                        }
                    }

                    print(myCase);
                }
            }


            
        }


        static void print(int selectedCase)
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter("c:\\users\\nicolas\\documents\\lol.out",true);
            sw.WriteLine(string.Format("Case #{0}:", selectedCase));
            if (myTable != null && myTable[lines-1,cols-1] == 0)
            {
                for (int line = 0; line < lines; line++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (myTable[line, col] == BOMBVALUE)
                        {
                            sw.Write("*");
                        }
                        else if (line == lines - 1 && col == cols - 1)
                        {
                            sw.Write("c");
                        }
                        else
                        {
                            sw.Write(".");
                        }
                    }
                    sw.WriteLine();
                }
            }
            else
            {
                sw.WriteLine("Impossible");
            }
            sw.Close();
            sw.Dispose();
        }
    }

    


}
