using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[CreateAssetMenu (menuName = "Scriptables/Units")]
public class UnitsScriptable : ScriptableObject
{
    public string Name;
    public int Life;
    public float Damage;
    public float Range;
    public int cost;
    public float attSpeed;
    public float movSpeed;
    public int lvl;
    public Sprite cardArt;
    public UnitsScriptable nextLvlCard;
    public int upgradeGoldCost;
    
}
