using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

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
    public Image image;

    public String GetUnitNamePerLenguage(UnitsTranslation.Languages lenguages)
    {
        return UnitsTranslation.getUnitNamePerLenguage(Name, lenguages);
    }
}
