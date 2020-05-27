using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[CreateAssetMenu (menuName = "Scriptables/Units")]
public class UnitsScriptable : ScriptableObject
{
    public UnitsTranslation.Unit Name;
    public int Life;
    public float Damage;
    public float Range;
    public int cost;
    public float attSpeed;
    public float movSpeed;
    public int lvl;
    public Sprite cardArt;
    public UnitsScriptable nextLvlCard;

    public String GetUnitNamePerLenguage(UnitsTranslation.Languages lenguages)
    {
        return UnitsTranslation.getUnitNamePerLenguage(Name, lenguages);
    }
}
