﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class UnitDetectRange : MonoBehaviour
{
    private SphereCollider SphereCollider;
    public String DefenseTag;
    private UnitDie _unitDie;
    public GameObject target;

    [SerializeField]
    public bool isOnDetectRange = false;
    
    // Start is called before the first frame update
    void Start()
    {
        SphereCollider = GetComponent<SphereCollider>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(DefenseTag) && _unitDie == null)
        {
            isOnDetectRange = true;
            _unitDie = other.GetComponent<UnitDie>();
            _unitDie.OnDefenseUnitDied += OnDefenseUnitDied;
            target = other.gameObject;
        }
    }

    private void OnDefenseUnitDied(object sender, EventArgs e)
    {
        isOnDetectRange = false;
        _unitDie = null;
        target = null;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(DefenseTag))
        {
            _unitDie.OnDefenseUnitDied -= OnDefenseUnitDied;
            _unitDie = null;
            isOnDetectRange = false;
            target = null;
        }
    }
}
