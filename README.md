To Build Project

Template:
dotnet build NQueen/NQueen.csproj --runtime <runtime_identifier> --configuration <Release|Debug>

The implemented runtime identifiers are:
	win-x64
	win-x86
	linux-x64
	osx-x64
	
Example win-x64:
dotnet build NQueen/NQueen.csproj --runtime win-x64 --configuration Release