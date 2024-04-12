using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] float sensX;
    [SerializeField] float sensY;

    [SerializeField] Transform player;

    float xRotation;
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        HandleRotation();
    }

    private void HandleRotation()
    {
        //gets mouse input
        float mouseX = Input.GetAxis("Mouse X") * sensX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensY * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        yRotation += mouseX;

        //Rotates CAMERA, doing it this way allows us to clamp and doesn't rotate player off of ground
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);

        //Rotates PLAYER around Y axis
        player.Rotate(Vector3.up * mouseX);
    }
}
