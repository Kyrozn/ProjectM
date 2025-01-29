using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Deplacement : MonoBehaviour
{
    protected GameObject Player;
    public float distance;
    public NavMeshAgent agent;
    public float speed = 1f;

    // Update is called once per frame
    void Awake()
    {
        Transform childTransform = transform.Find("Beta_Joints");

        if (childTransform != null)
        {
            Renderer childRenderer = childTransform.GetComponent<Renderer>();

            if (childRenderer != null)
            {
                childRenderer.material.color = Color.red;
            }
        }
        else
        {
            Debug.LogError("Aucun enfant nommé 'Beta_Joints' trouvé !");
        }
    }
    void Update()
    {
        agent.SetDestination(GameObject.Find("X Bot").transform.position - new Vector3(distance, distance, distance));
        agent.speed = speed;
    }
}
