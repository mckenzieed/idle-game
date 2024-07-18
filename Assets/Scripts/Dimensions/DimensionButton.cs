using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class DimensionButton : MonoBehaviour
{
    public Button Button;

    private bool buttonIsPressed = false;
    private float cooldownInSeconds = 0.1f;
    private bool isCoolingDown = false;

    void Update()
    {
        if (ButtonIsLocked())
        {
            Button.interactable = false;
        }
        else
        {
            Button.interactable = true;
        }

        if (GetButtonIsPressed()) OnButtonPressed();
    }

    public abstract bool ButtonIsLocked();

    public bool GetButtonIsPressed()
    {
        return buttonIsPressed;
    }

    public abstract void OnButtonPressed();

    public float GetCooldownInSeconds() { return cooldownInSeconds; }
    public bool GetIsCoolingDown() { return isCoolingDown; }

    public IEnumerator Cooldown()
    {
        isCoolingDown = true;
        yield return new WaitForSeconds(cooldownInSeconds);
        isCoolingDown = false;
    }

    public void OnButtonPress()
    {
        buttonIsPressed = true;
    }

    public void OnButtonRelease()
    {
        buttonIsPressed = false;
    }
}
