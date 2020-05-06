﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private GameObject nexus;

    public float velocity = 5;

    public NavMeshAgent agent;

    private UnitDetectRange _unitAttackRange;
    // Start is called before the first frame update
    void Start()
    {
        velocity *= Time.deltaTime;
        _unitAttackRange = GetComponentInChildren<UnitDetectRange>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_unitAttackRange.isOnDetectRange)
        {
            agent.isStopped = true;
            /*if (expr)
            {
                
            }*/
        }
        else
        { 
            agent.isStopped = false;
            agent.SetDestination(nexus.transform.position);
        }

    }
}
