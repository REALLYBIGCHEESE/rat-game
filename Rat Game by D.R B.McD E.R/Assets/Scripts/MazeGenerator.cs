using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MazeGenerator : MonoBehaviour
{
    //SERIALIZE FIELDS TO STORE PREFAB OF MAZE CELL, WIDTH, AND DEPTH
    //Prefab
    [SerializeField] 
    private MazeCell mazeCellPrefab;
    
    //Width
    [SerializeField]
    private int mazeWidth;
    
    //Depth
    [SerializeField] 
    private int mazeDepth;
    
    
    //2D ARRAY TO STORE GRID OF CELLS
    private MazeCell[,] mazeGrid;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //Empty GameObject as parent for maze cells
        GameObject mazeCloneStorage = new GameObject("Maze Clone Storage");
        
        //Initialise Array
        mazeGrid = new MazeCell[mazeWidth, mazeDepth];
        
        //Loop from 0 to width of maze
        for (int x = 0; x < mazeWidth; x++)
        {
            //Nested loop from 0 to depth of maze
            for (int z = 0; z < mazeDepth; z++)
            {
                //Instantiate instance of maze cell
                mazeGrid[x,z] = Instantiate(mazeCellPrefab, new Vector3(x, 0, z), Quaternion.identity);
                
                // Set the newly created empty GameObject as the parent for each maze cell
                mazeGrid[x, z].transform.parent = mazeCloneStorage.transform;
            }
        }
        //Null as 1st param because no previous cells exist, 2nd param is first grid in mazeGrid array
        GenerateMaze(null, mazeGrid[0,0]);

        //Calls method to spawn rat
        SpawnRatInMaze();
    }

    private void GenerateMaze(MazeCell previousCell, MazeCell currentCell)
    {

        //Use visit method on current cell
        currentCell.Visit();
        //Call on clear walls method
        ClearWalls(currentCell, previousCell);
        
        //Declare nextCell of type MazeCell
        MazeCell nextCell;
        
        //do generate maze while nextCell is not null
        do
        {
            //variable nextCell is equal to value returned from GetNextUnvisitedCell method
            nextCell = GetNextUnvisitedCell(currentCell);

            //If next cell is not null
            if (nextCell != null)
            {
                //Yield return to call coroutine
                GenerateMaze(currentCell, nextCell);
            }
        } while (nextCell != null);
    }
    
    
    //METHOD TO GET NEXT UNVISITED CELL
    private MazeCell GetNextUnvisitedCell(MazeCell currentCell)
    {
        //unvisitedCells is = to the values returned by GetUnvisitedCells method
        var unvisitedCells = GetUnvisitedCells(currentCell);
        
        //Order unvisited cells by random number (Linq library) and return first value (null otherwise)
        return unvisitedCells.OrderBy(_ => Random.Range(1, 10)).FirstOrDefault();
    }
    
    
    //METHOD TO RETURN ALL UNVISITED NEIGHBOURS
    private IEnumerable<MazeCell> GetUnvisitedCells(MazeCell currentCell)
    {
        //Store x and z positions of current cell
        int x = (int)currentCell.transform.position.x;
        int z = (int)currentCell.transform.position.z; 
        
        //Check if next CELL TO THE RIGHT is within bounds of grid
        if (x + 1 < mazeWidth)
        {
            //Create cellToRight variable
            var cellToRight = mazeGrid[x + 1, z];
            
            //If cell to right is not visited, return as potential option
            if (cellToRight.IsVisited == false)
            {
                //Returns cellToRight without exiting GetUnvisitedCells
                yield return cellToRight;
            }
        }
        
        //Check if next CELL TO THE LEFT is within bounds of grid
        if (x - 1 >= 0)
        {
            //Create cellToLeft variable
            var cellToLeft = mazeGrid[x - 1, z];
                
            //If cell to left is not visited, return as potential option
            if (cellToLeft.IsVisited == false)
            {
                //Returns cellToLeft without exiting GetUnvisitedCells
                yield return cellToLeft;
            }
        }
        
        //Check if next CELL TO THE FRONT is within bounds of grid
        if (z + 1 < mazeDepth)
        {
            //Create cellToFront variable
            var cellToFront = mazeGrid[x, z + 1];
                
            //If cell to front is not visited, return as potential option
            if (cellToFront.IsVisited == false)
            {
                //Returns cellToFront without exiting GetUnvisitedCells
                yield return cellToFront;
            }
        }
        
        //Check if next CELL TO THE BACK is within bounds of grid
        if (z - 1 >= 0)
        {
            //Create cellToBack variable
            var cellToBack = mazeGrid[x, z - 1];
                
            //If cell to back is not visited, return as potential option
            if (cellToBack.IsVisited == false)
            {
                //Returns cellToBack without exiting GetUnvisitedCells
                yield return cellToBack;
            }
        }
    }


    //METHOD FOR CLEARING MAZE WALLS
    private void ClearWalls(MazeCell previousCell, MazeCell currentCell)
    {
        //Check for previous cell
        if (previousCell == null || currentCell == null)
        {
            return;
        }
        
        //If previous cell is to left of current cell (Algorithm moved from left to right)
        if (previousCell.transform.position.x < currentCell.transform.position.x)
        {
            previousCell.ClearRightWall();
            currentCell.ClearLeftWall();
            return;
        }
        
        //If previous cell is to right of current cell (Algorithm moved from right to left)
        if (previousCell.transform.position.x > currentCell.transform.position.x)
        {
            previousCell.ClearLeftWall();
            currentCell.ClearRightWall();
            return;
        }
        
        //If previous cell is to back of current cell (Algorithm moved back to front)
        if (previousCell.transform.position.z < currentCell.transform.position.z)
        {
            previousCell.ClearFrontWall();
            currentCell.ClearBackWall();
            return;
        }
        
        //If previous cell is to front of current cell (Algorithm moved front to back)
        if (previousCell.transform.position.z > currentCell.transform.position.z)
        {
            previousCell.ClearBackWall();
            currentCell.ClearFrontWall();
        }
    }

    private void SpawnRatInMaze()
    {
        Vector3 spawnPosition = FindValidSpawnPosition();

        Instantiate(rat, spawnPosition, Quaternion.identity);

    }

    private Vector3 FindValidSpawnPosition()
    {
        int centerX = mazeWidth / 2;
        int centerZ = mazeDepth / 2;

        return new Vector3(centerX, 0.5f, centerZ);
    }

}
