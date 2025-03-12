using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private float arrowStormCooldown = 8f;
    private float lastArrowStormTime = -Mathf.Infinity;
    private int arrowCount = 10;
    private float stormRadius = 5f;

    private bool attackOngoing = false;
    private Dictionary<Action, int> RangedAttacks;
    private enum ArrowType
    {
        Normal,
        Fire,
        Ice,
        Poison
    }
    private ArrowType currentArrowType = ArrowType.Normal;
    private bool IsTriggered = false;
    private bool IsDistance = false;
    public float Height = 3.0f;
    public GameObject projectilePrefab; // Assigne un prefab de cube dans l'inspecteur
    public float projectileSpeed = 10f;

    private float lastAttackTime = -Mathf.Infinity;

    void Awake()
    {
        transform.localScale = new Vector3(Height, Height, Height);
        RangedAttacks = new Dictionary<Action, int>()
        {
            {NormalAttack , 50},
            {ChargedAttack , 25},
            {ArrowStorm , 15},
            {ChangeArrow , 10},
        };
    }

    void Update()
    {
        GameObject player = GameObject.Find("X Bot");
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

        if (distanceToPlayer < 10f && !IsTriggered)
        {
            IsTriggered = true;
        }

        if (IsTriggered && !attackOngoing)
        {
            attackOngoing = true;
            transform.LookAt(player.transform);
            CheckDistance(distanceToPlayer);
            if (IsDistance)
            {
                Action action = ChooseRangeAttack();
                action?.Invoke();
            }
            else
            {
                Debug.Log("Move Closer");
            }
            attackOngoing = false;
        }
    }

    private void CheckDistance(float distance)
    {
        if (distance < 10f)
        {
            IsDistance = false;
        }
        else
        {
            IsDistance = true;
        }
        ;
    }

    private Action ChooseRangeAttack()
    {
        int totalWeight = 0;
        foreach (var action in RangedAttacks.Values)
        {
            totalWeight += action;
        }

        int randomNumber = UnityEngine.Random.Range(0, totalWeight);
        int cumulativeWeight = 0;

        foreach (var action in RangedAttacks)
        {
            cumulativeWeight += action.Value;
            if (randomNumber <= cumulativeWeight)
            {
                return action.Key;
            }
        }

        return null;
    }

    private void NormalAttack()
    {
        float cooldownTime = 2f; // Cooldown de 2 secondes

        if (Time.time - lastAttackTime < cooldownTime) return; // Vérifie si le cooldown est écoulé
        lastAttackTime = Time.time; // Met à jour le temps de la dernière attaque

        Debug.Log("Normal Attack");
        GameObject player = GameObject.Find("X Bot");
        if (player == null || projectilePrefab == null) return;

        Vector3 spawnPosition = transform.position + Vector3.up * (Height / 1.1f);
        GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
        Rigidbody rb = projectile.AddComponent<Rigidbody>();
        rb.useGravity = false;

        Vector3 targetPosition = player.transform.position;
        targetPosition.y += 0.5f; // Ajuste cette valeur pour tirer plus vers le bas
        Vector3 direction = (targetPosition - spawnPosition).normalized;

        rb.velocity = direction * projectileSpeed;

        float maxDistance = Vector3.Distance(player.transform.position, transform.position) * 1.5f;
        StartCoroutine(DestroyProjectileAfterDistance(projectile, maxDistance));
    }

    private IEnumerator DestroyProjectileAfterDistance(GameObject projectile, float maxDistance)
    {
        Vector3 startPos = projectile.transform.position;
        while (Vector3.Distance(startPos, projectile.transform.position) < maxDistance)
        {
            yield return null;
        }
        Destroy(projectile);
    }

    private float chargedAttackCooldown = 5f; // Cooldown de l'attaque chargée
    private float lastChargedAttackTime = -Mathf.Infinity;
    private float chargeTime = 2f; // Temps de charge avant le tir

    private void ChargedAttack()
    {
        StartCoroutine(ChargedAttackRoutine());
    }

    private IEnumerator ChargedAttackRoutine()
    {
        if (Time.time - lastChargedAttackTime < chargedAttackCooldown) yield break; // Vérifie le cooldown
        lastChargedAttackTime = Time.time;

        Debug.Log("Charging Attack...");

        // Effet visuel de charge (optionnel)
        yield return new WaitForSeconds(chargeTime); // Attente du temps de charge

        Debug.Log("Charged Attack!");

        GameObject player = GameObject.Find("X Bot");
        if (player == null || projectilePrefab == null) yield break;

        Vector3 spawnPosition = transform.position + Vector3.up * (Height / 1.1f);
        GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
        projectile.transform.localScale *= 2; // Rend le projectile plus gros
        Rigidbody rb = projectile.AddComponent<Rigidbody>();
        rb.useGravity = false;

        Vector3 targetPosition = player.transform.position;
        targetPosition.y -= 1.0f; // Inclinaison vers le bas
        Vector3 direction = (targetPosition - spawnPosition).normalized;

        rb.velocity = direction * (projectileSpeed * 1.5f); // Projectile plus rapide

        float maxDistance = Vector3.Distance(player.transform.position, transform.position) * 2f;
        StartCoroutine(DestroyProjectileAfterDistance(projectile, maxDistance));
    }



    private void ArrowStorm()
    {
        if (Time.time - lastArrowStormTime < arrowStormCooldown) return; // Vérifie le cooldown
        lastArrowStormTime = Time.time;
        StartCoroutine(ArrowStormRoutine());
    }

    private IEnumerator ArrowStormRoutine()
    {
        Debug.Log("Arrow Storm!");

        GameObject player = GameObject.Find("X Bot");
        if (player == null || projectilePrefab == null) yield break;

        for (int i = 0; i < arrowCount; i++)
        {
            Vector3 randomOffset = new Vector3(
                UnityEngine.Random.Range(-stormRadius, stormRadius),
                10f, // Hauteur de spawn
                UnityEngine.Random.Range(-stormRadius, stormRadius)
            );

            Vector3 spawnPosition = player.transform.position + randomOffset;
            GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
            Rigidbody rb = projectile.AddComponent<Rigidbody>();
            rb.useGravity = true; // Active la gravité pour qu'elles tombent

            yield return new WaitForSeconds(0.1f); // Laisse un léger délai entre chaque tir
        }
    }


    private void ChangeArrow()
    {
        int randomNumber = UnityEngine.Random.Range(0, ArrowType.GetNames(typeof(ArrowType)).Length);
        ChangingArrowType(randomNumber);
        Debug.Log("Change Arrow to " + (ArrowType)randomNumber);
    }

    private void ChangingArrowType(int randomNumber)
    {
        currentArrowType = (ArrowType)randomNumber;
    }
}
