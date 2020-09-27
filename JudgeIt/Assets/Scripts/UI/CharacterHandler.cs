using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHandler : MonoBehaviour
{
    public Transform visualsTransform;

    public void Init()
    {
        if (visualsTransform == null)
            visualsTransform = GameObject.Find("CharacterVisuals").transform;

        CharacterManager.Instance.GenerateNewCharacter(this);
    }


    /// <summary>
    /// Creates the visuals of the characters from an image's ordered list
    /// </summary>
    /// <param name="imageList">The ordered list of character parts. First indexes will be on bottom</param>
    public void SetupCharacter(List<SpriteColorPair> spriteColorList)
    {
        // Remove current character
        for (int i = 0; i < visualsTransform.childCount; i++)
            Destroy(visualsTransform.GetChild(i).gameObject);

        // Create newly generated character
        foreach (SpriteColorPair spriteColor in spriteColorList)
        {
            // Create new GameObject and give it an image component
            var newObj = new GameObject("CurCharacter_Part");
            var rect = newObj.AddComponent<RectTransform>();
            
            var img = newObj.AddComponent<Image>();

            // Assign the sprite from the supplied list and change its color
            img.sprite = spriteColor.sprite;
            img.color = spriteColor.color;

            // Make the full visuals child of this gameobject
            newObj.transform.parent = visualsTransform != null ? visualsTransform : transform;

            // make it fullscreen
            rect.anchorMin = new Vector2(0, 0);
            rect.anchorMax = new Vector2(1, 1);
            rect.offsetMin = new Vector2(0, 0);
            rect.offsetMax = new Vector2(0, 0);
        }
    }
}
