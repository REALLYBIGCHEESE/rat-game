using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Speed of the player movement
    public float speed = 5f;
    
    //Rigidbody component of the player
    private Rigidbody rb; 

    void Start()
    {
        //Get the Rigidbody component and freeze its rotation
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        //Get the horizontal and vertical input using GetAxisRaw for snappier response
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //Create a movement vector based on the input
        Vector3 movement = new Vector3(horizontal, 0f, vertical).normalized;

        //Move and instantly rotate the player if there is any input
        if (movement.magnitude > 0)
        {
            MovePlayer(movement);
            InstantRotatePlayer(movement);
        }
    }

    void MovePlayer(Vector3 movement)
    {
        //Calculate the new position based on the input movement
        Vector3 newPosition = rb.position + movement * speed * Time.fixedDeltaTime;
        
        //Move the Rigidbody to the new position
        rb.MovePosition(newPosition);
    }

    void InstantRotatePlayer(Vector3 movement)
    {
        //Determine the direction to rotate based on the movement vector
        if (movement != Vector3.zero)
        {
            //Calculate the target rotation based on the direction
            Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);
            
            //Set the player's rotation instantly to the target rotation
            rb.rotation = targetRotation;
        }
    }
}