# rCompiler
A Dotnet repo to convert rC files into executables       

## Requirements to run the compiler:      
- Windows: Visual Studio with C# packages;       
- Linux: Mono Toolkit       

## Requirements to run the generated exe:     
- Windows: Nothing      
- Linux: Mono Runtime / Dotnet Runtime

## Running the compiler:      
- Place rCompiler.exe and Compile_Example.rcompiler in the same directory as the rC source code;      
- Run the following:
```
rcc.exe <all_the_files.rcode> <os>
```   
- Example:
```
rcc.exe Main.rcode headers.h.rcode --windows        
rcc.exe Main.rcode headers.h.rcode --linux
```   
