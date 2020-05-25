using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obeliscoAnimScript : MonoBehaviour
{
    public Animator animator;
    public UnitDie unitDie;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        unitDie = GetComponent<UnitDie>();
        unitDie.OnDefenseUnitDied += onUnitDied;
    }

    private void onUnitDied(object sender, EventArgs e)
    {
        //animator.SetBool("death", true);
        animator.SetTrigger("death");
    }

}
