using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UniversalRenderMatrixScript : MonoBehaviour
{
    [SerializeField] private GameObject PixelPrefab;
    [SerializeField] private List<List<GameObject>> MatrixScreen = new();
    private int x = 0;
    private int y = 0;

    private int auxX = 0;
    private int auxY = 0;
    private float posX = -7.5f;
    private float posY = 3.7f;
    void Start()
    {
        Application.targetFrameRate = 60;
        //InvokeRepeating("ChangeMaterialTest", 0, 0.01f);
        //Tween(); //Color change test
    }

    public void GenerateMatrix(int n)
    {
        ClearMatrixScreen();
        for (int i = 0; i < 144; i++)
        {
            MatrixScreen.Add(new List<GameObject>());
            for (int j = 0; j < 212; j++)
            {
                MatrixScreen[i].Add(Instantiate(PixelPrefab, new Vector3(posX, posY, 0), Quaternion.Euler(0, 0,0)));
                MatrixScreen[i][j].GetComponent<PixelScript>().SetCoordinates(i, j);
               posX += 0.052f; ;
            }
            posY -= 0.052f;
            posX = -7.5f;
        }
    }

    public void DrawAPixel(int x, int y)
    {
        MatrixScreen[x][y].GetComponent<PixelScript>().LightLed();
    }
    public void DrawAPixelOnFill(int x, int y, Color color)
    {
        MatrixScreen[x][y].GetComponent<PixelScript>().LightLedOnFill(color);
    }

    public void EreaseAPixel(int x, int y)
    {
        MatrixScreen[x][y].GetComponent<PixelScript>().OffLed();
    }

    public void EreaseAPixelOnClean(int x, int y)
    {
        MatrixScreen[x][y].GetComponent<PixelScript>().OffLedOnClean();
    }


    public void ClearMatrixScreen()
    {
        for (int i = 0; i < MatrixScreen.Count; i++)
        {
            foreach (GameObject pixel in MatrixScreen[i])
            {
                Destroy(pixel);
            }
        }
        MatrixScreen.Clear();
        auxX = 0;
        auxY = 0;
        x = 0;
        y = 0;

        posX = -7.5f;
        posY = 3.7f;
}

    public PixelScript GetPixelOnPosition(int x, int y)
    {
        return MatrixScreen[x][y].GetComponent<PixelScript>();
    }

}
