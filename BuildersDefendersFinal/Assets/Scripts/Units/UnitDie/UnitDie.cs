﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDie : MonoBehaviour
{
    public event EventHandler OnDefenseUnitDied;
    
    void Update()
    {
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

