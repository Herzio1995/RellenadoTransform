using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PixelScript : MonoBehaviour
{
    [SerializeField] private SpriteRenderer image;
    //[SerializeField] private float time;
    public bool isOn;
    private int id;
    private int x;
    private int y;
    private Color auxColor = Color.white;
    public void SetCoordinates(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public void OffLed()
    {
        isOn = false;
        image.color = Color.white;
    }
    public void OffLedOnClean()
    {
        if (isOn) image.color = Color.black;
        else
        {
            image.color = Color.white;
        }
    }

    public void LightLed() {
        isOn = true;
        image.color = Color.black;   
    }

    public void LightLedOnFill(Color color)
    {
        isOn = true;
        image.color = color;
    }

    public void OnMouseOver()
    {
        GameEvents.Current.MouseOnPixel(x.ToString() + "," + y.ToString());
        //LedMesh.material.SetColor("_Color", Color.red);
        //LedMesh.material.SetColor("_EmissionColor", new Vector4(255f, 0f, 0) * 1.0f);

    }
    public void OnMouseExit()
    {
        GameEvents.Current.MouseOnPixel("");
        //image.color = Color.white;
    }
}
