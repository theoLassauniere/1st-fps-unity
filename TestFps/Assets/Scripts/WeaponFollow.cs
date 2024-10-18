using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFollow : MonoBehaviour
{
    public Transform playerCamera;
    public float smoothSpeed = 10f; // Adjust for smoothing effect

    void Update()
    {
        // Smoothly rotate the weapon to match the camera's rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, playerCamera.rotation, smoothSpeed * Time.deltaTime);
    }
}
