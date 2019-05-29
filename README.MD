# Battleships

A simple version of the game Battleships that allow a single human player to play a one-sided game of Battleships against ships placed by the computer.

The program creates a 10x10 grid, and places several ships on the grid at random with the following sizes:
- 1x Battleship (5 squares)
- 2x Destroyers (4 squares)

The player enters or selects coordinates of the form "A5", where "A" is the column and "5" is the row, to specify a square to target. Shots result in hits, misses or sinks. The game ends when all ships are sunk.

### Usage

```
dotnet build
dotnet test
dotnet run -p Battleships
```

Alternatively using Docker
```
docker build -t battleships .
docker run -it --rm battleships
```

### Prerequisites
- .NET Core 2.2 SDK
- Docker client 18.03 or later