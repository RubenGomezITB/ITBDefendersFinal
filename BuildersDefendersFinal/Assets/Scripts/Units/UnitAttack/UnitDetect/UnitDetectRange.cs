﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class UnitDetectRange : MonoBehaviour
{
    private CapsuleCollider CapsuleCollider;
    public String DefenseTag = "defense";
    private UnitDie _unitDie;
    public GameObject target;

    [SerializeField]
    public bool isOnDetectRange = false;
    
    // Start is called before the first frame update
    void Start()
    {
        CapsuleCollider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(DefenseTag) && _unitDie == null)
        {
            isOnDetectRange = true;
            _unitDie = other.GetComponent<UnitDie>();
            _unitDie.OnDefenseUnitDied += OnOnDefenseUnitDied;
            target = other.gameObject;
        }
    }

    private void OnOnDefenseUnitDied(object sender, EventArgs e)
    {
        isOnDetectRange = false;
        _unitDie = null;
        target = null;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(DefenseTag))
        {
            _unitDie.OnDefenseUnitDied -= OnOnDefenseUnitDied;
            _unitDie = null;
            isOnDetectRange = false;
            target = null;
        }
    }
}
