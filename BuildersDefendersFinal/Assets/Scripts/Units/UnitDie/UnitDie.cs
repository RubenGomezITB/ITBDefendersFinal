﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDie : MonoBehaviour
{
    public event EventHandler OnDefenseUnitDied;
    public UnitLife unitLife;
    public Animator animator;

    private void Start()
    {
        unitLife = GetComponent<UnitLife>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (unitLife.life<=0) {
            animator.SetBool("death", true);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        OnDefenseUnitDied?.Invoke(this, EventArgs.Empty);
    }
    
}

