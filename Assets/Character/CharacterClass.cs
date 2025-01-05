using UnityEngine;
public class CharacterClass : MonoBehaviour
{
    private Movement MoveScript;
    private CharacterController controller;
    protected string Name {get; set;}
    protected float MaxHealth {get; set;}
    protected float ActHealth {get; set;}
    protected float Armor {get; set;}
    protected float DamageBase {get; set;}
    protected float Level {get; set;}
    protected int? Mana {get; set;}
    protected string Description {get; set;}
    //ajouter le type d'arme

    void Start(){
        // Récupère le script `Move` attaché au même GameObject
        MoveScript = GetComponent<Movement>();

        if (MoveScript == null)
        {
            Debug.LogError("Le script Move n'est pas attaché à ce GameObject !");
        }
        controller = GetComponent<CharacterController>();
    }
    void Update(){
        Move();
    }
    public virtual void Move(){
        MoveScript.Shift(controller);
    }
}
