using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu]
public class AttackBasic : Ability
{
        public override void Activate(GameObject parent)
    {
        float AttackRange = parent.GetComponent<Reaper>().MyWeapon.range;
        Collider swordCollider = parent.GetComponent<Reaper>().MyWeapon.GetComponent<CapsuleCollider>();
        Collider[] colliders = Physics.OverlapSphere(parent.transform.position, AttackRange);
        // foreach (Collider collider in colliders)
        // {
        //     if (collider.CompareTag("Ennemy") && swordCollider.bounds.Intersects(collider.bounds))
        //     {
        //         var enemy = collider.GetComponent<Ennemy>();
        //         if (enemy != null)
        //         {
        //             enemy.TakeDamage(50);
        //         }
        //     }
        // } // a decommenter apres le merge
    }
}
