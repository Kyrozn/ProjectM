using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed = 6f;
    public float jumpSpeed = 8f;
    public float gravity = 20f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            // Prendre en compte les mouvements horizontaux et verticaux
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            moveDirection = new Vector3(moveHorizontal, 0, moveVertical);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            

            // Sauter si le bouton "Jump" est pressé
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Appliquer la gravité
        moveDirection.y -= gravity * Time.deltaTime;

        controller.transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * 0.6f);
        // Appliquer le mouvement
        controller.Move(moveDirection * Time.deltaTime);
    }
}
