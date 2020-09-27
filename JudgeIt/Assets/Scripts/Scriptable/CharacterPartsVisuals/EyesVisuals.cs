using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains the different sprites that make a character's eyes
/// </summary>
[CreateAssetMenu(fileName = "NewEyesVisual", menuName = "Character Visuals/Eyes Visual")]
public class EyesVisuals : ScriptableObject
{
    public Sprite line;
    public Sprite eyebrows;
    public Sprite pupils;
}
