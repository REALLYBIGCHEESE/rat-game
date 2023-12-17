using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //Serializable field to contain components
    [System.Serializable]
    
    //Class containing our x,y and z coordinate variables
    public class Point
    {
        public float x;
        public float y;
        public float z;
    }
    
    //The starting point of the corridor
    public Point startPoint;
    
    //The ending point of the corridor
    public Point endPoint;
    
    //The speed the enemy moves
    public float speed = 2.0f;   
    
    //Create variable movingTowardsEnd and set to true
    private bool movingTowardsEnd = true;

    void Update()
    {
        //Create vector for start point
        Vector3 start = new Vector3(startPoint.x, startPoint.y, startPoint.z);
        
        //Create vector for end point
        Vector3 end = new Vector3(endPoint.x, endPoint.y, endPoint.z);
    
        //Create float to store speed of movement
        float step = speed * Time.deltaTime;

        //Move the enemy between the start and end points
        if (movingTowardsEnd)
        {
            transform.position = Vector3.MoveTowards(transform.position, end, step);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, start, step);
        }

        //Check if the enemy reaches the end point or start point, then reverse direction
        if (Vector3.Distance(transform.position, end) < 0.1f && movingTowardsEnd)
        {
            movingTowardsEnd = false;
            Rotate180Degrees();
        }
        else if (Vector3.Distance(transform.position, start) < 0.1f && !movingTowardsEnd)
        {
            movingTowardsEnd = true;
            Rotate180Degrees();
        }
    }
    
    //Function to rotate enemy 180 degrees, called upon above
    void Rotate180Degrees()
    {
        transform.Rotate(Vector3.up, 180f);
    }
}