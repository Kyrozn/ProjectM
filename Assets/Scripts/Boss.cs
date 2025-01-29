using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Boss : MonoBehaviour
{
    private Dictionary<Action, int> RangedAttacks = new Dictionary<Action, int>()
    {
        {NormalAttack , 50}, // 50
        {ChargedAttack , 25}, // 75
        {ArrowStorm , 15}, // 90
        {ChangeArrow , 10}, // 100
    };
    private bool IsTriggered = false;
    private bool IsDistance = false;
    public float Height = 3.0f;

    // Start is called before the first frame update
    void Awake()
    {
        transform.localScale = new Vector3(Height, Height, Height);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((GameObject.Find("X Bot").transform.position - this.transform.position).magnitude < new Vector3(10, 10, 10).magnitude && !IsTriggered)
        {
            IsTriggered = true;
        }
        if (IsTriggered)
        {
            transform.LookAt(GameObject.Find("X Bot").transform);
            CheckDistance();
            if (IsDistance)
            {
                Action action = ChooseRangeAttack();
                action?.Invoke();
            }
            else
            {
                Debug.Log("Move Closer");
            }
        }
    }
    private void CheckDistance()
    {
        if ((GameObject.Find("X Bot").transform.position - this.transform.position).magnitude < new Vector3(10, 10, 10).magnitude)
        {
            IsDistance = true;
        }
        IsDistance = false;
    }

    private Action ChooseRangeAttack()
    {
        int totalWeight = 0;
        foreach (var action in RangedAttacks.Values)
        {
            totalWeight += action;
        }

        int randomNumber = new System.Random().Next(0, totalWeight);
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

    private static void NormalAttack()
    {
        Debug.Log("Normal Attack");
    }

    private static void ChargedAttack()
    {
        Debug.Log("Charged Attack");
    }

    private static void ArrowStorm()
    {
        Debug.Log("Arrow Storm");
    }

    private static void ChangeArrow()
    {
        Debug.Log("Change Arrow");
    }



}
