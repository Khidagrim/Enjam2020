using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DebugColor
{
    public static void Red(string txt)
    {
        Debug.Log("<Color=#E27D60>"+txt+"</color>");
    }

    public static void Blue(string txt)
    {
        Debug.Log("<Color=#85DCB>"+txt+"</color>");
    }

    public static void Orange(string txt)
    {
        Debug.Log("<Color=#E8A87C>"+txt+"</color>");
    }

    public static void Purple(string txt)
    {
        Debug.Log("<Color=#C38D9E>"+txt+"</color>");
    }
    public static void Green(string txt)
    {
        Debug.Log("<Color=#41B3A3"+txt+"</color>");
    }
}
