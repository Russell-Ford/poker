# Introduction

This is a C# [.NET Core](https://github.com/dotnet/core) solution judge 3 Card poker. It _should_ be cross-platform but was developed and tested on Win10-x64 so your mileage may vary.

# Requirements
1. [.NET Core SDK](https://www.microsoft.com/net/download/core)
2. [Python 2.7](https://www.python.org/downloads/) - required to run tests

# Build/Compile

## CLI Publish
1. Set current directory to `.\src` from project root
2. Run `dotnet publish -o ..\publish`

# Run
1. Set current directory to published code location
   * if following above from project root that is `.\publish`
2. Run `dotnet PokerSolver.dll`  

# Test
1. `python .\run_tests "dotnet .\publish\PokerSolver.dll"`
	* **Note**: the path the the published dll is relative to the project root. The above only works if publish directions above are followed.

