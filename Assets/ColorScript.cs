using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorScript : MonoBehaviour
{
    [SerializeField] Color colorActual = Color.white;
    [SerializeField] Image display;

    public float red = 0f;
    public float green = 0f;
    public float blue = 0f;
    public void setRed(float red) {
        this.red = red;
        colorActual = new Color(red, green, blue);
        display.color = colorActual;
        GameEvents.Current.SetColorOnFiller(colorActual);
    }

    public void setBlue(float blue)
    {
        this.blue = blue;
        colorActual = new Color(red, green, blue);
        display.color = colorActual;
        GameEvents.Current.SetColorOnFiller(colorActual);
    }

    public void setGreen(float green)
    {
        this.green = green;
        colorActual = new Color(red, green, blue);
        display.color = colorActual;
        GameEvents.Current.SetColorOnFiller(colorActual);
    }
}
