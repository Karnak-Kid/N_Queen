## Description
This is an implementation of an N-Queens solver written in C#. It employs a genetic algorithm following the  Adam & Eve approach.

       _____ _____ _____ _____ _____ _____ _____ _____
      |     |     |     |     |     |     |     |     |
    8 |     |     |     |     |     |     |  Q  |     |
      |_____|_____|_____|_____|_____|_____|_____|_____|
      |     |     |     |     |     |     |     |     |
    7 |     |     |     |     |  Q  |     |     |     |
      |_____|_____|_____|_____|_____|_____|_____|_____|
      |     |     |     |     |     |     |     |     |
    6 |     |     |  Q  |     |     |     |     |     |
      |_____|_____|_____|_____|_____|_____|_____|_____|
      |     |     |     |     |     |     |     |     |
    5 |  Q  |     |     |     |     |     |     |     |
      |_____|_____|_____|_____|_____|_____|_____|_____|
      |     |     |     |     |     |     |     |     |
    4 |     |     |     |     |     |  Q  |     |     |
      |_____|_____|_____|_____|_____|_____|_____|_____|
      |     |     |     |     |     |     |     |     |
    3 |     |     |     |     |     |     |     |  Q  |
      |_____|_____|_____|_____|_____|_____|_____|_____|
      |     |     |     |     |     |     |     |     |
    2 |     |  Q  |     |     |     |     |     |     |
      |_____|_____|_____|_____|_____|_____|_____|_____|
      |     |     |     |     |     |     |     |     |
    1 |     |     |     |  Q  |     |     |     |     |
      |_____|_____|_____|_____|_____|_____|_____|_____|
         a     b     c     d     e     f     g     h

## Build
**Template:** dotnet build NQueen/NQueen.csproj --runtime **<runtime_identifier>** --configuration **<Release|Debug>**

The implemented runtime identifiers are:
* win-x64
* win-x86
* linux-x64
* osx-x64
	
**Example for Windows:** dotnet build NQueen/NQueen.csproj --runtime **win-x64** --configuration **Release**

## Build
**Example for Windows:** dotnet run  --framework net8.0  --runtime **win-x64** --configuration **Debug**