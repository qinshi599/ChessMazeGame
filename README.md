# Chess Maze Game

A C# chess maze game inspired by [Mazelog](http://www.mazelog.com/show?9).

## About

This project is a chess maze game where players need to find a path from start to finish using chess piece movement rules.

## Features

1. Game Management
- Restart Game: Reset the game to its initial state
- Undo: Revert to previous move
- Make Move: Execute chess piece movements
- Track Move History: Record all moves made during gameplay
- Move Steps Count: Track the number of moves made
- IsGameOver: Detect when player has reached the goal

2. Board Management
- Get Piece at Position: Retrieve chess piece at a specific board coordinate
- Place Piece on Board: Position pieces on the game board
- Validate Board Position (IsValidPosition): Check if coordinates are within board boundaries
- Validate Empty Position (IsEmptyPosition): Verify if a position is unoccupied
- Validate Move (IsMoveLegal): Ensure moves follow chess rules
- Path Clear Validation (IsPathClear): Check if the path between positions is unobstructed

3. Piece Movement
- Support for multiple chess pieces:
    - King movement
    - Rook movement
    - Knight movement
    - Bishop movement
    - Pawn movement (with promotion capability)

4. Player Management
- Player movement controls

## Tech Stack

- C# .NET
- Visual Studio
- MS Unit Test (for testing)

## How to Run

1. Clone the repository
2. Open the solution in Visual Studio
3. Build and run the project

## Project Structure

- `ChessMazeGame/` - Main project code
- `ChessMazeGameTest/` - Unit test project

## License

[Add your license information] 