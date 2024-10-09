module Main
open Grid
open System
// Recreated my first C project in F# because why not?

let mutable SandPiece = new Sand()
SandPiece.Position_ROW <- 1
SandPiece.Position_COLUMN <- 5

let grid = create_grid()
grid[SandPiece.Position_ROW][SandPiece.Position_COLUMN] <- SandBlock // Puts the sand block in the grid
grid[5][5] <- Wall
grid[4][6] <- Wall

let print() = // Prints out the grid accordingly
    grid |> Array.iter(fun A ->
        A |> Array.iter(fun B -> printf $"{B} "); printf "\n")
    printf "\n"

let update() =
    try
        let canGoDown = 
            grid[SandPiece.Position_ROW + 1][SandPiece.Position_COLUMN] = Empty

        let canGoLeft = 
            grid[SandPiece.Position_ROW + 1][SandPiece.Position_COLUMN + 1] = Empty &&
            grid[SandPiece.Position_ROW][SandPiece.Position_COLUMN + 1] = Empty

        let canGoRight = 
            grid[SandPiece.Position_ROW + 1][SandPiece.Position_COLUMN - 1] = Empty &&
            grid[SandPiece.Position_ROW][SandPiece.Position_COLUMN - 1] = Empty

        if canGoDown then
            grid[SandPiece.Position_ROW + 1][SandPiece.Position_COLUMN] <- SandBlock
            grid[SandPiece.Position_ROW][SandPiece.Position_COLUMN] <- Empty
            SandPiece.Position_ROW <- SandPiece.Position_ROW + 1
        elif canGoLeft then
            grid[SandPiece.Position_ROW + 1][SandPiece.Position_COLUMN + 1] <- SandBlock
            grid[SandPiece.Position_ROW][SandPiece.Position_COLUMN] <- Empty
            SandPiece.Position_COLUMN <- SandPiece.Position_COLUMN + 1
            SandPiece.Position_ROW <- SandPiece.Position_ROW + 1
        elif canGoRight then
            grid[SandPiece.Position_ROW + 1][SandPiece.Position_COLUMN - 1] <- SandBlock
            grid[SandPiece.Position_ROW][SandPiece.Position_COLUMN] <- Empty
            SandPiece.Position_COLUMN <- SandPiece.Position_COLUMN - 1
            SandPiece.Position_ROW <- SandPiece.Position_ROW + 1
        else ()
    with
    | :? IndexOutOfRangeException -> ()
    print()

for i in 0..10 do
    update()

Console.ReadLine() |> ignore // Console keeps closing for me so I added this so it won't close unless I press enter.