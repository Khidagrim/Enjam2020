using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewCharacterVisualsSet", menuName = "Character Visuals/Character Visuals Set")]
public class CharacterVisuals : ScriptableObject
{
    [Header("Hair")]
    public List<HairVisuals> hairList;
    public List<Color> hairColors;

    [Header("Eyes")]
    public List<EyesVisuals> eyesList;
    public List<Color> eyesColors;

    [Header("Mouth")]
    public List<MouthVisuals> mouthList;
    public List<Color> mouthColors;

    [Header("Face")]
    public List<FaceVisuals> faceList;
    public List<Color> skinColors;

    [Header("Body")]
    public List<BodyVisuals> bodyList;
    public List<Color> clothesColors;


    public List<SpriteColorPair> GenerateCharacter()
    {
        // Generate hair
        var hairVisual = Helpers.GetRandomObjectFromList<HairVisuals>(hairList);
        var hairColor = Helpers.GetRandomObjectFromList<Color>(hairColors);

        SpriteColorPair frontHair = new SpriteColorPair(hairVisual.frontHair, hairColor);
        SpriteColorPair backHair = new SpriteColorPair(hairVisual.backHair, hairColor);


        // Generate eyes
        var eyesVisual = Helpers.GetRandomObjectFromList<EyesVisuals>(eyesList);
        var eyesColor = Helpers.GetRandomObjectFromList<Color>(eyesColors);

        SpriteColorPair eyes = new SpriteColorPair(eyesVisual.line, Color.black);
        SpriteColorPair eyesInfill = new SpriteColorPair(eyesVisual.infill, Color.white);
        SpriteColorPair eyebrows = new SpriteColorPair(eyesVisual.eyebrows, Color.black);
        SpriteColorPair pupils = new SpriteColorPair(eyesVisual.pupils, eyesColor);


        // Generate mouth
        var mouthVisual = Helpers.GetRandomObjectFromList<MouthVisuals>(mouthList);

        SpriteColorPair mouth = new SpriteColorPair(mouthVisual.line, Color.black);


        // Generate face
        var faceVisual = Helpers.GetRandomObjectFromList<FaceVisuals>(faceList);
        var skinColor = Helpers.GetRandomObjectFromList<Color>(skinColors);

        SpriteColorPair face = new SpriteColorPair(faceVisual.line, skinColor);

        // Generate body and all its infills. A body can have N different colors
        var bodyVisual = Helpers.GetRandomObjectFromList<BodyVisuals>(bodyList);
        var body = new SpriteColorPair(bodyVisual.line, Color.black);
        var bodyInfills = new List<SpriteColorPair>();
        foreach(var sprite in bodyVisual.infills)
        {
            Color rndColor = Helpers.GetRandomObjectFromList<Color>(clothesColors);
            bodyInfills.Add(new SpriteColorPair(sprite, rndColor));
        }


        // Construct the final return List
        // Smaller indexes are in front
        List<SpriteColorPair> returnList = new List<SpriteColorPair>() { 
            frontHair,
            eyebrows, eyes, pupils, eyesInfill, 
            mouth, 
            face, 
            body
        };


        // Finally, add the body colors
        returnList.AddRange(bodyInfills);

        // And don't forget the back hair
        returnList.Add(backHair);

        returnList.Reverse();

        //Cleanup returne list
        foreach(SpriteColorPair elt in returnList)
        {
            if (elt.sprite == null)
                elt.color = Color.clear;
        }

        return returnList;
    }



    public void RandomMethodeLol()
    {

    }
}

#region Special array class

/// <summary>
/// Simple class that contains a sprite and its associated color
/// </summary>
public class SpriteColorPair
{
    public Sprite sprite;
    public Color color;

    public SpriteColorPair(Sprite s, Color c)
    {
        this.sprite = s;
        this.color = c;
    }
}

#endregion