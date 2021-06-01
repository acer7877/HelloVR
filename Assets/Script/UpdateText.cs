using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateText : MonoBehaviour
{

    public TMP_Text TextElement;

    public void SetText(string text)
    {
        if (TextElement == null)
        {
            Debug.LogWarning("Text element is null!");
            return;
        }
        TextElement.text = text;
    }

}
