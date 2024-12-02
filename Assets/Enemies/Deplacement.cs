using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Deplacement : MonoBehaviour
{
protected GameObject Player;
public int distance;
public NavMeshAgent agent;

    // Update is called once per frame
    void Update()
    {
        
    agent.SetDestination(GameObject.Find("X Bot").transform.position - new Vector3(distance,distance,0));
        // if (Input.GetMouseButtonDown(1)) 
        // {
        //     Ray movePosition = Camera.main.ScreenPointToRay(Input.mousePosition);
        //     if(Physics.Raycast(movePosition, out var hitInfo))
        //     {
                
                
        //     }
        // }

    }
}
