<h2>Description</h2>
This is an implementation of an N-Queens solver writen in C#, using a genetic algorithm, and visualized in a console application.

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

<h2>Build</h2>
<h6>Template</h6>
dotnet build NQueen/NQueen.csproj --runtime <runtime_identifier> --configuration <Release|Debug>

The implemented runtime identifiers are:
	win-x64
	win-x86
	linux-x64
	osx-x64
	
<h6>Example</h6>
dotnet build NQueen/NQueen.csproj --runtime win-x64 --configuration Release