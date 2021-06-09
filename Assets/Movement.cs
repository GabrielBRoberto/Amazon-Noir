using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float rotateSpeed;

    float horizontalInput;
    float verticalInput;

    [SerializeField]
    CharacterController controller;

    [SerializeField]
    AudioSource passos;

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal") * rotateSpeed * Time.deltaTime;
        verticalInput = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0, horizontalInput, 0);

        Vector3 forward = transform.TransformDirection(Vector3.forward);

        controller.SimpleMove(forward * verticalInput);

        if(controller.SimpleMove(forward * verticalInput))
        {
            passos.volume = 1;
        }
        else
        {
            passos.volume = 0;
        }
    }
}
