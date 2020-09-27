using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Sprite normalSprite;
    public Sprite pressedSprite;
    public float yShift = 20;

    Button btn;
    Image btnImage;
    RectTransform rt;
    RectTransform oldRt;

    // Start is called before the first frame update
    void Awake()
    {
        btnImage = GetComponent<Image>();
        btn = GetComponent<Button>();
        rt = GetComponent<RectTransform>();

        Debug.Assert(normalSprite != null);
        Debug.Assert(pressedSprite != null);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        btnImage.sprite = pressedSprite;
        oldRt = rt;

        rt.position = new Vector3(0, -yShift, 0) + rt.position;
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, rt.rect.height - yShift * 2);

        // Change children position
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).transform.position -= new Vector3(0, yShift, 0);
        }
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        btnImage.sprite = normalSprite;
        rt.position = new Vector3(0, +yShift, 0) + rt.position;
        rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, rt.rect.height + yShift * 2);

        // Change children position
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).transform.position += new Vector3(0, yShift, 0);
        }
    }
}
