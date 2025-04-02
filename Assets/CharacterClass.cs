using UnityEngine;
public class CharacterClass : MonoBehaviour
{
    private PlayerController MoveScript;
    private CharacterController controller;
    protected string Name {get; set;}
    protected float MaxHealth {get; set;}
    protected float ActHealth {get; set;}
    protected float Armor {get; set;}
    protected float DamageBase {get; set;}
    protected float Level {get; set;}
    protected int? Mana {get; set;}
    protected string Description {get; set;}

    [SerializeField]
    private Camera cam;

    private Vector3 velocity;
    private Vector3 rotation;
    private Vector3 cameraRotation;

    private Rigidbody rb;
    //ajouter le type d'arme

    void Start(){
        // Récupère le script `Move` attaché au même GameObject
        MoveScript = GetComponent<PlayerController>();

        if (MoveScript == null)
        {
            Debug.LogError("Le script Move n'est pas attaché à ce GameObject !");
        }
        controller = GetComponent<CharacterController>();
    }
    
    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    public void RotateCamera(Vector3 _cameraRotation)
    {
        cameraRotation = _cameraRotation;
    }

    private void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    private void PerformMovement()
    {
        if(velocity != Vector3.zero)
        {
            //rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
            controller.Move(velocity * Time.deltaTime);
        }
    }

    private void PerformRotation()
    {
        //rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        controller.transform.Rotate(rotation);
        cam.transform.Rotate(-cameraRotation);
    }
}
