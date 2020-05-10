﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDie : MonoBehaviour
{
    public event EventHandler OnDefenseUnitDied;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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

