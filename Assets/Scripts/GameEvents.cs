using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Current;
    // Start is called before the first frame update
    public event Action<String> OnPixel;
    public event Action<int, int> Draw;
    public event Action<int, int> Erease;
    public event Action<Color> SetColor;
    private Color colorEntrance = Color.white;
    [SerializeField] private TextMeshProUGUI coordinatesText;
    [SerializeField] private UniversalRenderMatrixScript Screen;
    private void Awake()
    {
        Current = this;
    }
    private void Start()
    {
        GameEvents.Current.OnPixel += ShowCoordinates;
        GameEvents.Current.Draw += DrawAPointOnScreen;
        GameEvents.Current.Erease += EreaseAPointOnScreen;
    }

    public void MouseOnPixel(String coord)
    {
        if (OnPixel != null)
        {
            OnPixel(coord);
        }
    }
    private void ShowCoordinates(string text)
    {
        coordinatesText.text = text;
    }

    public void DrawAPointOnScreen(int x, int y) {
        Screen.DrawAPixel(x, y);
    }

    public void DrawAPointOnScreenOnFill(int x, int y)
    {
        Screen.DrawAPixelOnFill(x, y, GetColorOnFiller());
    }

    public void EreaseAPointOnScreen(int x, int y)
    {
        Screen.EreaseAPixel(x, y);
    }

    public Color GetColorOnFiller() {
        return colorEntrance;
    }

    public void SetColorOnFiller(Color color)
    {
        colorEntrance = color;
    }

    public bool GetColorOnPixel(int x, int y) {
        return Screen.GetPixelOnPosition(x, y).isOn;
    }
}
