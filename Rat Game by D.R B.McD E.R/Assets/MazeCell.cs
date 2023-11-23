using UnityEngine;

public class MazeCell : MonoBehaviour
{
     //CREATE SERIALIZED FIELD AND OBJECT FOR EACH MAZE CELL WALL
     //Left wall
     [SerializeField]
     private GameObject leftWall;
     
     //Right wall
     [SerializeField]
     private GameObject rightWall;
     
     //Front wall
     [SerializeField]
     private GameObject frontWall;
     
     //Back wall
     [SerializeField]
     private GameObject backWall;
     
     //Unvisited block
     [SerializeField]
     private GameObject unvisitedBlock;
     
     
     //DECLARE BOOLEAN VARIABLE TO TRACK VISITED CELLS
     //public getter and private setter make IsVisited 'read only'
     public bool IsVisited { get; private set; }
     
     
     //HELPER METHODS
     //Visit
     public void Visit() 
     {
          //set IsVisited to true
          IsVisited = true;
          //Deactivates unvisited block
          unvisitedBlock.SetActive(false);
     }
     
     //Clear left wall
     public void ClearLeftWall() 
     {
          leftWall.SetActive(false);
     }
     
     //Clear right wall
     public void ClearRightWall() 
     {
          rightWall.SetActive(false);
     }
     
     //Clear front wall
     public void ClearFrontWall() 
     {
          frontWall.SetActive(false);
     }
     
     //Clear back wall
     public void ClearBackWall() 
     {
          backWall.SetActive(false);
     }
}
