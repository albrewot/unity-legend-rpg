using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonControl : MonoBehaviour
{

    [SerializeField] private RectTransform textObject;


    public void OnButtonClick() {

        textObject.anchorMin = new Vector2(0, 0);
        textObject.anchorMax = new Vector2(1, 0.77f);

    }

    public void OnButtonRelease() {

        textObject.anchorMin = new Vector2(0, 0.23f);
        textObject.anchorMax = new Vector2(1, 1);
 
    }
}
