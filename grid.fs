module Grid

let public rows : int = 10
let public columns : int = 11

let public Empty = ' ' // What an empty space looks like
let public SandBlock = '0' // What sand looks like
let public Wall = '9' // What a wall looks like

type public Sand = // Struct for the Sandpiece
    struct
        val mutable Position_ROW : int
        val mutable Position_COLUMN : int
    end

let public create_grid() =
    let grid : array<array<char>> =
        [| for _ in 1..rows + 2 -> [| for _ in 1..columns + 2 -> Empty |] |] // The whole grid.
        
    for i in 0..columns + 1 do
        grid[rows + 1][i] <- Wall
        grid[0][i] <- Wall
    
    for i in 0..rows do
        grid[i][columns + 1] <- Wall
        grid[i][0] <- Wall
    grid