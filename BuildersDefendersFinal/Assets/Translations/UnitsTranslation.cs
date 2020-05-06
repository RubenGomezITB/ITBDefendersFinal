using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitsTranslation : MonoBehaviour
{
    public enum Unit
    {
        SandWorm,
        Snowman,
        Obelisk
    }

    public enum Languages
    {
        Spanish,
        English
    }

    private static String[] English = new string[]
    {
        "Sand Worm",
        "Snowman",
        "Obelisk"
    };

    private static String[] Spanish = new string[]
    {
        "Gusano de arena",
        "Muñeco de nieve",
        "Obelisco"
    };

    public static String getUnitNamePerLenguage(Unit unit, Languages languages)
    {
        switch (languages)
        {
            case Languages.Spanish:
                return GetUnitInSpanish(unit);

            case Languages.English:
                return GetUnitInEnglish(unit);

            default: return null;
        }
    }

    private static string GetUnitInSpanish(Unit unit)
    {
        switch (unit)
        {
            case Unit.SandWorm:
                return Spanish[0];

            case Unit.Snowman:
                return Spanish[1];

            case Unit.Obelisk:
                return Spanish[2];
            default: return null;
        }
    }

    private static string GetUnitInEnglish(Unit unit)
    {
        switch (unit)
        {
            case Unit.SandWorm:
                return English[0];

            case Unit.Snowman:
                return English[1];
   
            case Unit.Obelisk:
                return English[2];
            default: return null;
        }
    }
}