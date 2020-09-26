using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains the different sprites that make a character's body
/// </summary>
[CreateAssetMenu(fileName = "NewBodyVisual", menuName = "Character Visuals/Body Visual")]
public class BodyVisuals : ScriptableObject
{
    public Sprite line;
    public List<Sprite> infills;
}
