using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAttackDetecter : MonoBehaviour
{
    private BoxCollider _boxCollider;

    public bool isOnAttackRange = false;
    [SerializeField] private UnitsScriptable _us;
    private UnitDie _unitDie;
    public UnitLife _life;

    public UnitDetectRange DetectRange;

    public bool attackOnCooldown = false;

 
    void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void FixedUpdate()
    {
        
        if (DetectRange.isOnDetectRange && !isOnAttackRange)
        {
            transform.parent.position =
                Vector3.MoveTowards(transform.parent.position, DetectRange.target.transform.position, .01f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (DetectRange.isOnDetectRange && other.tag == (DetectRange.DefenseTag))
        {
            isOnAttackRange = true;
            _unitDie = other.GetComponent<UnitDie>();
            _unitDie.OnDefenseUnitDied += OnOnDefenseUnitDied;
            _life = other.transform.gameObject.GetComponent<UnitLife>();
        }
    }

    private void OnOnDefenseUnitDied(object sender, EventArgs e)
    {
        _life = null;
    }

    private void OnTriggerStay(Collider other)
    {
        if (DetectRange.isOnDetectRange && other.tag == (DetectRange.DefenseTag))
        {
            if (!attackOnCooldown)
            {
                if (_life != null)
                {
                     StartCoroutine(attacking());
                }
               
            }
        }
    }

    private IEnumerator attacking()
    {
        _life.recibeDamage(_us.Damage);
        attackOnCooldown = true;
        yield return new WaitForSeconds(_us.attSpeed);
        attackOnCooldown = false;
    }

    private IEnumerator attack()
    {
        
        yield return new WaitForSeconds(_us.attSpeed);
        attackOnCooldown = false;
    }

    private void OnTriggerExit(Collider other)
    {
        isOnAttackRange = false;
        _life = null;
    }
}