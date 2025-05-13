using System.Collections;
using UnityEngine;

[CreateAssetMenu]
public class Sprint : Ability
{
    public override void Activate(GameObject parent)
    {
        Movement movement = parent.GetComponent<Movement>();
        if (movement != null)
        {
            movement.StartCoroutine(SprintForSeconds(movement, 60, 5f));
        }
    }

    private IEnumerator SprintForSeconds(Movement movement, float sprintSpeed, float duration)
    {
        float originalSpeed = movement.speed;
        movement.speed = sprintSpeed;
        yield return new WaitForSeconds(duration);
        movement.speed = originalSpeed;
    }
}
