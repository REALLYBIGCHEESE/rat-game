using UnityEngine;

public class Cheese : MonoBehaviour
{
    //CLASS LEVEL VARIABLES
    //Cheese score
    private static int cheeseScore;

    //Exit object
    private GameObject exitObject;



    //START AND PLAYER/CHEESE COLLISION 
    private void Start()
    {
        //Check for exit object at start
        exitObject = GameObject.FindWithTag("Exit");
    }

    //CODE TO EXECUTE WHEN PLAYER AND CHEESE COLLIDE
    void OnTriggerEnter(Collider other)
    {
        //Check if the collider is the player
        if (other.CompareTag("Player"))
        {
            //Increase cheese score
            cheeseScore++;

            //Update score display cheese collected to console
            Debug.Log("Cheese collected! Current score: " + cheeseScore);

            //Destroy the collected cheese object
            Destroy(gameObject);

            //If cheese score reaches 3
            if (cheeseScore == 3)
            {
                //Print Find the exit to console
                Debug.Log("You Found All The Cheese! You Win!");
            }
        }
    }
}