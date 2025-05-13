using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemieMove : MonoBehaviour
{

    protected GameObject Player;
    public float distancefrom;
    public NavMeshAgent agentNav;
    public Raycast raycast;
    public float speed = 1f;

    // Update is called once per frame
    void Awake()
    {




    }
    void Update()
    {
        agentNav.SetDestination(GameObject.Find("X Bot").transform.position - new Vector3(distancefrom, distancefrom, distancefrom));
        agentNav.speed = speed;
    }

}
