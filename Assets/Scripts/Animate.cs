using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    Animator PlayerAnimator;

    // Variable pour stocker la position précédente
    private Vector3 previousPosition;

    void Awake()
    {
        // Récupérer l'Animator
        PlayerAnimator = GetComponent<Animator>();

        // Initialiser la position précédente
        previousPosition = transform.position;
    }

    void Update()
    {
        // Calculer la distance parcourue depuis la dernière frame
        float distanceMoved = (transform.position - previousPosition).magnitude;

        // Mettre à jour l'animation en fonction du déplacement
        PlayerAnimator.SetFloat("walk", distanceMoved > 0 ? 1f : 0f);

        // Mettre à jour la position précédente pour la prochaine frame
        previousPosition = transform.position;
    }
}
