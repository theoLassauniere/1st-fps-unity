using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovements : MonoBehaviour
{
    
    public float mouseSensitivity = 500f;
    public float topClamp = -90f;
    public float bottomClamp = 90f;
    
    float _xRotation = 0f;
    float _yRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        // Locking the cursor to the middle of the screen + invisible
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Getting mouse inputs
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        // Rotation around the x-axis
        _xRotation -= mouseY;
        
        // Rotation around y-axis
        _yRotation += mouseX;
        
        // Clamp the rotation
        _xRotation = Mathf.Clamp(_xRotation, topClamp, bottomClamp);
        
        // Apply rotations to our transform
        transform.localRotation = Quaternion.Euler(_xRotation, _yRotation, 0f);
    }
}
