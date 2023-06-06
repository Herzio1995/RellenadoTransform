using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using Unity.VisualScripting;
using UnityEngine;
using static GeneralEventsListeners;

public class CircleScript : MonoBehaviour
{
    private int x = 0;
    private int xc = 0;
    private int yc = 0;
    private int y = 0;
    private int e = 0;
    private int radio = 0;
    List<Tuple<int, int>> pos = new List<Tuple<int, int>>();
    List<Tuple<int, int>> posRelleno = new List<Tuple<int, int>>();
    private int[][] matrix;
    private Color color;
    private int start, end;
    private void Start()
    {
        CircleBresenham(20);
    }

    public void ScalePlus() {
        ClearFigure();
        radio += 10;
        circle(radio, y, e, xc, yc);
    }
    public void ScaleMinus()
    {
        ClearFigure();
        radio -= 5;
        circle(radio, y, e, xc, yc);
    }

    public void MoveUp() {
        ClearFigure();
        yc -= 5;
        circle(radio, y, e, xc, yc);
    }
    public void MoveDown()
    {
        ClearFigure();
        yc += 5;
        circle(radio, y, e, xc, yc);
    }
    public void MoveL()
    {
        ClearFigure();
        xc -= 5;
        circle(radio, y, e, xc, yc);
    }
    public void MoveR()
    {
        ClearFigure();
        xc += 5;
        circle(radio, y, e, xc, yc);
    }
    public void CircleBresenham(int radio)
    {
        xc = 106;
        yc = 72;
        this.radio = radio;
        circle(radio, y, e, xc, yc);
    }
    private void circle(int radio, int y, int e, int xc, int yc)
    {
        x = radio;
        this.xc = xc;
        this.yc = yc;
        matrix = new int[radio+1][];
        for (int i = 0; i < radio; i++) {
            int[] aux = new int[radio];
            matrix[i]= aux;
        }
        this.y = y;
        this.e = e;
        while (y <= x)
        {
            putPixel(x, y, xc, yc);
            //putMatrix(x, y);
            putPixel(y, x, xc, yc);
            //putMatrix(y, x);
            putPixel(-x, y, xc, yc);
            //putMatrix(-x, y);
            putPixel(-y, x, xc, yc);
            //putMatrix(-y, x);
            putPixel(x, -y, xc, yc);
            //putMatrix(x, -y);
            putPixel(y, -x, xc, yc);
            //putMatrix(y, -x);
            putPixel(-x, -y, xc, yc);
            //putMatrix(-x, -y);
            putPixel(-y, -x, xc, yc);
            //putMatrix(-y, -x);
            e = e + 2 * y + 1;
            y = y + 1;
            if (2 * e > (2 * x - 1))
            {
                x = x - 1;
                e = e - 2 * x + 1;
            }
        }
        //ScanLine(xc, yc);
    }

    private void putPixel(int x, int y, int xc, int yc)
    {
        int x1 = x + xc;
        int y1 = y + yc;

        if (x1 >= 0 && x1 < 212 && y1 >= 0 && y1 < 144)
        {
            pos.Add(new Tuple<int, int>(y1, x1));
            GameEvents.Current.DrawAPointOnScreen(y1, x1);
        }

    }
    /*
    private void putMatrix(int x, int y) {
        int x1 = x + matrix.Length / 2;
        int y1 = y + matrix[0].Length / 2;

        if (x1 >= 0 && x1 < matrix[0].Length && y1 >= 0 && y1 < matrix.Length)
        {
            matrix[y1][x1] = 1;
        }
    }
    */
    public void ClearFigure() {
        foreach ((int x, int y) in pos) {
            GameEvents.Current.EreaseAPointOnScreen(x, y);
        }
    }

    public void PutPixel(int x, int y)
    {
        GameEvents.Current.DrawAPointOnScreen(x, y);
    }

    public void DestroyGameObject() {
        Destroy(gameObject, 0.5f);
    }

    public void GetColorOnGameEvent() {
        color = GameEvents.Current.GetColorOnFiller();
    }

    public void FillFigure()
    {
        ScanLine(xc, yc);
    }

    private void ScanLine(int xc, int yc)
    {
        bool iDet = false;
        for (int i = yc - radio - 5; i < yc + radio + 1; i++)
        {
            for (int j = xc - radio - 5; j < xc + radio + 1; j++)
            {
                if (GameEvents.Current.GetColorOnPixel(i, j))
                {
                    if (!iDet)
                    {
                        start = j;
                        iDet = true;
                    }
                    else {
                        end = j;
                    }
                }
            }
            Print(i, start, end);
        }
    }
    private void Print(int i, int start, int end)
    {
        for (int j = start + 1; j < end; j++)
        {
            GameEvents.Current.DrawAPointOnScreenOnFill(i, j);
        }
    }


    private bool dashed = true;
    
    public void CircleLine2()
    {
        ClearFigure();
        x = radio;
        y = 0;
        e = 0;
        while (y <= x)
        {
            if (dashed)
            {
                if (y % 2 == 0)
                {
                    putPixel(x, y, xc, yc);
                    putPixel(y, x, xc, yc);
                    putPixel(-x, y, xc, yc);
                    putPixel(-y, x, xc, yc);
                    putPixel(x, -y, xc, yc);
                    putPixel(y, -x, xc, yc);
                    putPixel(-x, -y, xc, yc);
                    putPixel(-y, -x, xc, yc);
                }
            }
            else
            {
                putPixel(x, y, xc, yc);
                putPixel(y, x, xc, yc);
                putPixel(-x, y, xc, yc);
                putPixel(-y, x, xc, yc);
                putPixel(x, -y, xc, yc);
                putPixel(y, -x, xc, yc);
                putPixel(-x, -y, xc, yc);
                putPixel(-y, -x, xc, yc);
            }
            e = e + 2 * y + 1;
            y = y + 1;
            if (2 * e > (2 * x - 1))
            {
                x = x - 1;
                e = e - 2 * x + 1;
            }
        }
    }

}
