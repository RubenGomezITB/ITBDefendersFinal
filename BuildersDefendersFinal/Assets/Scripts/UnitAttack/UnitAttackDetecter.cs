﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAttackDetecter : MonoBehaviour
{
    private BoxCollider _boxCollider;

    public bool isOnAttackRange = false;

    public UnitDetectRange DetectRange;
    // Start is called before the first frame update
    void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
   
    }

    private void FixedUpdate()
    {
        if (DetectRange.isOnDetectRange && !isOnAttackRange)
        {
            transform.parent.position = Vector3.MoveTowards(transform.parent.position,DetectRange.target.transform.position, .01f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (DetectRange.isOnDetectRange && other.tag == (DetectRange.DefenseTag))
        {
            isOnAttackRange = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (DetectRange.isOnDetectRange && other.tag ==(DetectRange.DefenseTag))
        {
            //attack
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isOnAttackRange = false;
    }
}
