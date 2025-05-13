using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public int damageAmount = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("The player lost" + damageAmount + "hp");
             
        }
    }
}