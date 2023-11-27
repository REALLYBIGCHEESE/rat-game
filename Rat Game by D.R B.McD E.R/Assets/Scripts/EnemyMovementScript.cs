using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    [System.Serializable]
    public class Point
    {
        public float x;
        public float y;
        public float z;
    }


    public Point startPoint;     //The starting point of the corridor
    public Point endPoint;       //The ending point of the corridor
    public float speed = 2.0f;   //The speed the enemy moves

    private bool movingTowardsEnd = true;

    void Update()
    {
        Vector3 start = new Vector3(startPoint.x, startPoint.y, startPoint.z);
        Vector3 end = new Vector3(endPoint.x, endPoint.y, endPoint.z);

        //Move the enemy between the start and end points
        if (movingTowardsEnd)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }

        //Check if the enemy reaches the end point then reverse direction
        if (Vector3.Distance(transform.position, end) < 0.1f)
        {
            movingTowardsEnd = false;
        }
        //Check if the enemy reaches the start point, then reverse direction
        else if (Vector3.Distance(transform.position, start) < 0.1f)
        {
            movingTowardsEnd = true;
        }
    }
}