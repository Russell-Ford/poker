# "Poker" Solver

## Note

This was original done as a "homework" assignment for an interview screen. A best effort has been made to scrub the identity of the company from the code base but I make no promises it has been wholly excised.  No other alterations have been made to the source or history despite my vain desires. As it has been two years, and the code quality here isn't exactly something you should be copying, I feel this is safe to publish. However, DO YOUR OWN HOMEWORK.

This project was originally written to work on .NET Core 1.1 and minimal effort has been made to get it running in the latest .NET Core version.

## Introduction

This is a C# [.NET Core](https://github.com/dotnet/core) solution to judge 3 Card poker. It _should_ be cross-platform but was developed and tested on Win10-x64 so your mileage may vary.

### Design Goals

This project was designed to solve the problems of 3 Card poker while being extensible and flexible enough to be quickly adapted to solve other pokers. Below are the major namespaces and classes and what they mean to understand how this is achieved.

* `Program.cs`: Console program responsible for I/O
* `Poker.cs`: Defines the game of poker (a set of players with "hands") which is scored in tiers and then re-scored in "tie-breaker" fashion
* `RuleSets` (namespace): implementation of rule builder pattern, should allow the service to be quickly modified to support other pokers. Each "rule set" is a variation of poker rules to judge with.
* `RuleProcessors` (namespace): allow multiple rules to share logic and _cached results_
* `Rules` (namespace): define individual methods for evaluating hands in a round of poker; include initial evaluation and tie-breaking logic.
* `Models` (namespace): concepts fundamental to implementing poker.

Note, there is one significant kludge that may need to be refactored if the architecture were to be improved. Specifically, `Hand` is responsible for determining and knowing if it contains n-of-a-kind cards and what rank those cards are. Ideally this would live in something like a `NumberOfAKindProcessor` but getting that to work with Pair tiebreaking was too difficult to be worth it for initial round of dev.

Another potential refactor would be to create `PlayerHands.cs` to carry `PlayerId` + `Hand` instead of putting the Id onto `Hand` itself.

## Requirements
1. [.NET Core SDK](https://www.microsoft.com/net/download/core)
2. [Python 2.7](https://www.python.org/downloads/) - required to run tests
3. [VS 2017 IDE](https://www.visualstudio.com/downloads/) - required to open .sln and run+debug
   * If you don't want to download VS2017 the code files themselves can be easily viewed in any text editor. I would recommend [VS Code](https://code.visualstudio.com/?wt.mc_id=vscom_downloads) with C# plugin for text highlighting and integration with dotnet core.

## Build/Compile

### CLI Publish
1. Set current directory to `.\src` from project root
2. Run `dotnet publish -o ..\publish -c release`

Note, if you wish to produce an exe instead you can run `dotnet publish -o ..\publish -c release -r win10-x64`

## Run
1. Set current directory to published code location
   * if following above from project root that is `.\publish`
2. Run `dotnet PokerSolver.dll`
3. *OR* run `PokerSolver.exe` if you published the exe

## Test
1. Set current directory to project root
2. `python .\run_tests "dotnet .\publish\PokerSolver.dll"`
	* **Note**: the path the the published dll is relative to the project root. The above only works if publish directions above are followed. 
3. `python .\run_tests ".\publish\PokerSolver.exe"` if you published the exe

Note, Tests in the test folder _should_ automatically be run on build.

