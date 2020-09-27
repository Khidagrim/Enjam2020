using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains the different sprites that make a character's hair
/// </summary>
[CreateAssetMenu(fileName = "NewHairVisual", menuName = "Character Visuals/Hair Visual")]
public class HairVisuals : ScriptableObject
{
    public Sprite frontHair;
    public Sprite backHair;
}
