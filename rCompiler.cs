using System;
using rC;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace rC
{
   public static class Split
    {
    public class rCompiler{

       static void Main(string [] args){

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Note: if running this on windows, make sure to run it on Developer Command Prompt");
            Console.WriteLine("Note: if running this on linux, make sure to have the mono toolkit installed (csc is needed) ");
            Console.WriteLine("Note: the file \"Compile_Example.rcompiler\" must be in PATH / in current directory");

            Console.ResetColor();
            List<string> final_code = new List<string>();
            string final_code_str = "";

            if(args.Length>=1){
              foreach(var arg in args){
                try{
                  StreamReader rread = new StreamReader(arg);
                  string read_line = "";
                  while((read_line=rread.ReadLine())!=null){
                    final_code.Add(read_line);
                    final_code_str+=read_line+"\n";
                  }
                  rread.Close();
                }catch{
                  Console.WriteLine("Couldn't read file: "+arg);
                  Environment.Exit(1);
                }
              }
            }else{
               Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: No arguments");

            Console.ResetColor();
              Environment.Exit(1);
            }
              string [] Exception_Chars = {"\""};
            foreach(var __char in Exception_Chars){
              final_code_str = final_code_str.Replace(__char, "\""+__char);
            }
            string final_to_write = @"using System;
using rC;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace rC
{
  public class Program{
    static void Main(string [] args){
        List<string> numberNames = new List<string>();
            List<float> numberValues = new List<float>();
            List<string> strNames = new List<string>();
            List<string> strValues = new List<string>();
            List<string> references = new List<string>();
            List<string> strListNames = new List<string>();
            List<List<string>> strListValues = new List<List<string>>();
            List<string> numListNames = new List<string>();
            List<List<float>> numListValues = new List<List<float>>();
            List<List<string>> lines_for_functions = new List<List<string>>();
            List<string> names_for_functions = new List<string>();
            List<string> definers_to_replace = new List<string>();
            List<string> defined_to_replace = new List<string>();
            string code_str = "+'@'+'"'+final_code_str+'"'+@";
            List<string> code = code_str.Split('\n').ToList();
 rCompiler.Compile(code, numberNames, numberValues, strNames, strValues, references, strListNames, strListValues, numListNames, numListValues, lines_for_functions, names_for_functions, definers_to_replace, defined_to_replace);            }
            }
            ";
          
            StreamReader _rread = new StreamReader("Compile_Example.rcompiler");
                  string _read_line = "";
                  while((_read_line=_rread.ReadLine())!=null){
                    final_to_write+=_read_line+"\n";
                  }
                  _rread.Close();
            
            StreamWriter __write = new StreamWriter(args[0].Split('.')[0]+".cs");
            __write.Write(final_to_write);
            __write.Close();
            Console.WriteLine("Made Temp file -> "+args[0].Split('.')[0]+".cs");
            Process.Start(@"C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe", args[0].Split('.')[0]+".cs");
            Console.WriteLine("Compiled into -> "+args[0].Split('.')[0]+".exe");
            File.Delete(args[0].Split('.')[0]+".cs");
            Console.WriteLine("Deleted Temp file -> "+args[0].Split('.')[0]+".cs");
            Console.WriteLine("Compilation Finished...");
            
       }
    }
    }
}