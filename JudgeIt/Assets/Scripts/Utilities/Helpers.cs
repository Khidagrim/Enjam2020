using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helpers
{

    public static T GetRandomObjectFromList<T>(List<T> list)
    {
        // Safe check
        if (list.Count < 1) return default(T);

        var rnd = Mathf.RoundToInt(Random.Range(0, list.Count - 1));
        return list[rnd];
    }
}
