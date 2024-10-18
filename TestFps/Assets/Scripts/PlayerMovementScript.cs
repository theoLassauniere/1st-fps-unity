using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    CharacterController _characterController;

    public new Transform camera;
    public float speed = 12f;
    public float jumpHeight = 3f;
    public float gravity = -9.81f * 2f;
    
    public Transform groundCheck;
    public float groundDistance = 3f;
    public LayerMask groundMask;
    
    Vector3 _velocity;
    
    bool _isGrounded;
    bool _isMoving;
    
    Vector3 _lastPosition = new Vector3(0f, 0f, 0f);
    
    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Ground check
        _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        // Resetting the default velocity
        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }
        
        // Getting the inputs
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        // Creating the moving vector
        Vector3 move = camera.transform.right * x + camera.transform.forward * z;
        
        // Moving the player
        _characterController.Move(move * (speed * Time.deltaTime));
        
        // Player's jump def
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        
        // Falling down
        _velocity.y += gravity * Time.deltaTime;
        
        // Executing the jump
        _characterController.Move(_velocity * Time.deltaTime);

        if (_lastPosition != gameObject.transform.position && _isGrounded)
        {
            _isMoving = true; // See this later
        }
        else
        {
            _isMoving = false;
        }
        
        _lastPosition = gameObject.transform.position;
    }
}
