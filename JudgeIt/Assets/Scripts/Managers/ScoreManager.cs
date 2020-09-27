using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    /// <summary>
    /// The audience score, on top
    /// </summary>
    public float curAudience = 50;
    public float maxAudience = 100;

    /// <summary>
    /// The "morality" score, to see if the player is a good or bad judge
    /// </summary>
    public int curScore = 50;
    public int maxScore = 100;
}
