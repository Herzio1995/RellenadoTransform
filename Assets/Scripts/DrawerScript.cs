using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerScript : MonoBehaviour
{
    private int x = 0;
    private int y = 0;
    private int e = 0;
    [SerializeField] UniversalRenderMatrixScript Screen;
    //Bresenham Circle
    private int[][] matrix;
    public void CircleBresenham(int radio) {
        int xc = 100;
        int yc = 100;
        //matrix = new int[2 * radio + 1][2 * radio + 1];
        circle(radio, y, e, xc, yc);
    }
    private void circle(int radio, int y, int e, int xc, int yc) {
        x = radio;
        this.y = y;
        this.e = e;
        while (y <= x)
        {
            putPixel(x, y, xc, yc);
            putPixel(y, x, xc, yc);
            putPixel(-x, y, xc, yc);
            putPixel(-y, x, xc, yc);
            putPixel(x, -y, xc, yc);
            putPixel(y, -x, xc, yc);
            putPixel(-x, -y, xc, yc);
            putPixel(-y, -x, xc, yc);
            e = e + 2 * y + 1;
            y = y + 1;
            if (2 * e > (2 * x - 1))
            {
                x = x - 1;
                e = e - 2 * x + 1;
            }
        }
    }


    private void putPixel(int x, int y, int xc, int yc)
    {
        int x1 = x + xc;
        int y1 = y + yc;

        if (x1 >= 0 && x1 < 212 && y1 >= 0 && y1 < 144)
        {
            Debug.Log("pixel at"+y1+","+x1);
            Screen.DrawAPixel(y1,x1);
            //matrix[y1][x1] = 1;
        }

    }

    public void PutPixel(int x, int y)
    {
        Screen.DrawAPixel(x, y);
    }
}
