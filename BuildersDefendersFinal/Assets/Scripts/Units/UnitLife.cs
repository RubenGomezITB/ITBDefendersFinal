using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitLife : MonoBehaviour
{
    public float life;

    [SerializeField] private UnitsScriptable _us;

    private void Start()
    {
        life = _us.Life;
    }

    public void recibeDamage(float damage)
    {
        life -= damage;
        if (life <= 0)
        {
            destroyThisObject();
        }
    }

    private void destroyThisObject()
    {
        Destroy(gameObject);
    }
}