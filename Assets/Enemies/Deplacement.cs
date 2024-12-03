using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Deplacement : MonoBehaviour
{
protected GameObject Player;
public int distance;
public NavMeshAgent agent;
public RaycastHit hit;
private bool EnemyDetected;
public bool IsAlpha; 
public float Height = 1.5f;

    void Awake(){
        if (IsAlpha){
        transform.localScale=new Vector3(Height, Height, Height);
        }
    }

    void Update()
    {
            
            if (RaycastScan()){
                EnemyDetected = true;
            }
            if (EnemyDetected){
            agent.SetDestination(GameObject.Find("X Bot").transform.position - new Vector3(distance,distance,0));
            }

    }


    bool RaycastScan(){

        LayerMask layerMask = LayerMask.GetMask("Default", "X Bot");
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))

        { 
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red); 
            Debug.Log("Did Hit"); 
            return true;
        }
        else
        { 
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.black); 
            Debug.Log("Did not Hit"); 
            return false;
        }

    }

}
