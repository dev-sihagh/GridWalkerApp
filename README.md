# Toy Robot Simulator

A C# console application that simulates a GridWalker robot moving on a 5x5 tabletop grid.

## Description

- The robot can be placed on the table using the `PLACE X,Y,F` command, where `X` and `Y` are coordinates, and `F` is the direction (NORTH, SOUTH, EAST, WEST).
- Once placed, the robot can move with `MOVE`, rotate with `LEFT` or `RIGHT`, and report its position and direction using `REPORT`.
- The robot will ignore any movement that would cause it to fall off the table.
- The robot also ignores commands until a valid `PLACE` command is given.

## How to Run

1. Make sure you have [.NET 6 SDK](https://dotnet.microsoft.com/download) or later installed.
2. Clone this repository:
   ```bash
   git clone https://github.com/dev-sihagh/GridWalkerApp.git
   cd GridWalkerApp
   ```
3. Run the application:
   ```bash
   dotnet run
   ```
4. Enter commands in the console. Type `EXIT` to quit.

## Example

**Input:**
```
PLACE 0,0,NORTH
MOVE
REPORT
```

**Output:**
```
Output: 0,1,NORTH
```

## Commands

- `PLACE X,Y,F` – Place the robot at a specific location and facing a direction.
- `MOVE` – Move the robot one unit forward in the direction it's facing.
- `LEFT` / `RIGHT` – Rotate the robot 90 degrees left or right.
- `REPORT` – Output the robot’s current position and direction.
- `EXIT` – Exit the program.

## Notes

- The table is 5x5 units.
- The origin (0,0) is the bottom-left (south-west) corner.
- All invalid commands are ignored silently.
- Input is case-insensitive but should follow the expected format.

---

**Author:** Sina Haghani
