using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    public Rigidbody2D playerRigidBody;

    public float moveSpeed = 5f;

    
    //Vector for player movement (wasd)
    private Vector2 moveInput;

    //Vector for the player moving the mouse and looking around (mouse movement)
    private Vector2 mouseInput;
    public float mouseSens = 1f;

    public Transform playerCam;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        // wasd movement 
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        // fixes horizontal movement to move horizontally relative to where we are facing
        Vector3 moveHorizontal = transform.up * -moveInput.x;
        // fixes vertical movement to move horizontally relative to where we are facing
        Vector3 moveVertical = transform.right * moveInput.y;
        playerRigidBody.velocity = (moveHorizontal + moveVertical) * moveSpeed;
        
        
        // camera movement
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSens;
        // Our player rotation only affects the z value, not the x and y values
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,
            transform.eulerAngles.y, transform.rotation.eulerAngles.z - mouseInput.x);
        // local rotation rotates just the Camera itself, and not the player.
        // if we rotate the player it makes movement wonky.
        // moving camera up/down only changes y-axis.
        playerCam.localRotation = Quaternion.Euler(playerCam.localRotation.eulerAngles +
                                                   new Vector3(0f, mouseInput.y, 0f));
    }
}
