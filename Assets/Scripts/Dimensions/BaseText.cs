using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class BaseText : MonoBehaviour
{
    public TMP_Text Text;

    // Update is called once per frame
    void Update()
    {
        UpdateText();
    }

    public abstract void UpdateText();
}
