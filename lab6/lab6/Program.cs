using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using opennlp.tools.tokenize;
using java.io;

namespace lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] files = Directory.GetFiles(@"C:\10311173\lab-5-opennlp-tokenization-Changyiyu\Dataset", "*.html");
            StreamWriter sw = new StreamWriter(@"TokensReader.txt");
            foreach (string thefile in files)
            {
                using (StreamReader sr = new StreamReader(thefile))
                {
                    while (sr.Peek() != -1)
                    {
                        string line = sr.ReadLine();
                        string[] tokens;
                        InputStream modelIn = new FileInputStream(@"C:\10311173\lab-6-opennlp-ju-zi-qie-fen-Changyiyu\en-token.bin");
                        TokenizerModel model = new TokenizerModel(modelIn);
                        TokenizerME enTokenizer = new TokenizerME(model);
                        tokens = enTokenizer.tokenize(line);

                        for (int i = 0; i < tokens.Length; i++)
                        {
                            //Regex reg = new Regex(".");
                            //Match m = reg.Match(tokens[i]);
                            sw.Write(tokens[i] + " ");
                            if (tokens[i].Equals("."))
                            {
                                sw.Write("\r\n");
                            }

                        }
                    }
                }
            }
            sw.Close();
        }
    }
}
