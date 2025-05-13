using System.Collections;
using UnityEngine;

[CreateAssetMenu]
public class NoctureSpiral : Ability
{
    private float rotationSpeed = 360f; // 360° en 1 sec
    public override void Activate(GameObject parent)
    {
        float AttackRange = parent.GetComponent<Reaper>().MyWeapon.range;

        Collider[] colliders = Physics.OverlapSphere(parent.transform.position, AttackRange);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Ennemy"))
            {
                Debug.Log("Hit ennemy");
            }
        }
        // Démarrer la rotation
        parent.GetComponent<MonoBehaviour>().StartCoroutine(RotateOverTime(parent));
    }
    private IEnumerator RotateOverTime(GameObject parent)
    {
        float rotationAmount = 0f;
        while (rotationAmount < 360f)
        {
            float rotationStep = rotationSpeed * Time.deltaTime;
            parent.transform.Rotate(0, rotationStep, 0);
            rotationAmount += rotationStep;
            yield return null; // Attendre la prochaine frame
        }
    }
}
