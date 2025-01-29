using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 3f;
    public float jumpSpeed = 8f;
    public float gravity = 20f;
    private Vector3 moveDirection = Vector3.zero;
    public Camera CameraComponent;
    public void Shift(CharacterController controller)
    {
        if (controller.isGrounded)
        {
            // Prendre en compte les mouvements horizontaux et verticaux
            float moveHorizontal = Input.GetAxisRaw("Horizontal");
            float moveVertical = Input.GetAxisRaw("Vertical");

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

        // Appliquer le mouvement
        controller.Move(moveDirection * Time.deltaTime);
    }
    public void SimpleAttack(CharacterController controller) {
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

        // Appliquer le mouvement
        controller.Move(moveDirection * Time.deltaTime);
    }
}