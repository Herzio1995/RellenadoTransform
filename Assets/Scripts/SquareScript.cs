using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using Unity.VisualScripting;
using UnityEngine;
using static GeneralEventsListeners;

public class SquareScript : MonoBehaviour
{
    int x1 = 40;
    int y1 = 40;
    int x2 = 40;
    int y2 = 60;
    int x3 = 60;
    int y3 = 40;
    int x4 = 60;
    int y4 = 60;

    int rx1;
    int ry1;
    int rx2;
    int ry2;
    int rx3;
    int ry3;
    int rx4;
    int ry4;

    private int ry; 
    private int rx;

    int c;

    private void Start()
    {
        CuadradoB();
    }
    public void CuadradoB()
    {
        cuadrado(x1, y1, x2, y2);
        cuadrado(x3, y3, x4, y4);
        cuadrado(x1, y1, x3, y3);
        cuadrado(x2, y2, x4, y4);
        c = x1 + (int)((y4 - x1) / 2);
    }


    private void cuadrado(int x0, int y0, int x1, int y1)
    {

        int x, y, dx, dy, p, incE, incNE, stepx, stepy;
        dx = (x1 - x0);
        dy = (y1 - y0);
        /* determinar que punto usar para empezar, cual para terminar */
        if (dy < 0)
        {
            dy = -dy; stepy = -1;
        }
        else
            stepy = 1;
        if (dx < 0)
        {
            dx = -dx; stepx = -1;
        }
        else
            stepx = 1;
        x = x0;
        y = y0;
        GameEvents.Current.DrawAPointOnScreen((int)y,(int)x);
        pos.Add(new Tuple<int, int>((int)y, (int)x));

        //matriz[(int)y][(int)x] = 1;
        /* se cicla hasta llegar al extremo de la lnea */
        if (dx > dy)
        {
            p = 2 * dy - dx;
            incE = 2 * dy;
            incNE = 2 * (dy - dx);
            while (x != x1)
            {
                x = x + stepx;
                if (p < 0)
                {
                    p = p + incE;
                }
                else
                {
                    y = y + stepy;
                    p = p + incNE;
                }
                //matriz[(int)y][(int)x] = 1;
                GameEvents.Current.DrawAPointOnScreen((int)y, (int)x);
                pos.Add(new Tuple<int, int>((int)y, (int)x));
            }
        }
        else
        {
            p = 2 * dx - dy;
            incE = 2 * dx;
            incNE = 2 * (dx - dy);
            while (y != y1)
            {
                y = y + stepy;
                if (p < 0)
                {
                    p = p + incE;
                }
                else
                {
                    x = x + stepx;
                    p = p + incNE;
                }
                //matriz[(int)y][(int)x] = 1;
                GameEvents.Current.DrawAPointOnScreen((int)y, (int)x);
                pos.Add(new Tuple<int, int>((int)y, (int)x));
            }
        }
    }

    /*
    private void rotacion(float x, float y, int c, float angulo)
    {
        angulo = (float)(Math.PI * angulo) / 180.0f;
        rx = c + Math.round((x - c) * (float)Math.cos(angulo) - (y - c) * (float)Math.sin(angulo));
        ry = c + Math.round((x - c) * (float)Math.sin(angulo) + (y - c) * (float)Math.cos(angulo));
        System.out.println(rx + "," + ry);
    }

     */ 



    List<Tuple<int, int>> pos = new List<Tuple<int, int>>();
    List<Tuple<int, int>> posRelleno = new List<Tuple<int, int>>();
    private Color color;
    private int start, end;
    

    public void ScalePlus() {
        ClearFigure();
        x1 -= 2;
        y1 -= 2;
        x2 -= 2;
        y2 += 2;
        x3 += 2;
        y3 -= 2;
        x4 += 2;
        y4 += 2;
        CuadradoB();
        

    }
    public void ScaleMinus()
    {
        ClearFigure();
        x1 += 2;
        y1 += 2;
        x2 += 2;
        y2 -= 2;
        x3 -= 2;
        y3 += 2;
        x4 -= 2;
        y4 -= 2;
        CuadradoB();
    }

    public void MoveUp() {
        ClearFigure();
        //yc -= 5;
    }
    public void MoveDown()
    {
        ClearFigure();
        //yc += 5;
        //circle(radio, y, e, xc, yc);
    }
    public void MoveL()
    {
        ClearFigure();
        //xc -= 5;
        //circle(radio, y, e, xc, yc);
    }
    public void MoveR()
    {
        ClearFigure();
        //xc += 5;
        //circle(radio, y, e, xc, yc);
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

    public void Rotar(float angle) {
        ClearFigure();
        rotacion((float)x1, (float)y1, c, angle);
        rx1 = rx;
        ry1 = ry;
        rotacion((float)x2, (float)y2, c, angle);
        rx2 = rx;
        ry2 = ry;
        rotacion((float)x3, (float)y3, c, angle);
        rx3 = rx;
        ry3 = ry;
        rotacion((float)x4, (float)y4, c, angle);
        rx4 = rx;
        ry4 = ry;
        cuadrado(rx1, ry1, rx2, ry2);
        cuadrado(rx3, ry3, rx4, ry4);
        cuadrado(rx1, ry1, rx3, ry3);
        cuadrado(rx2, ry2, rx4, ry4);
    }
   

    private void rotacion(float x, float y, int c, float angulo)
    {
        angulo = (float)(Math.PI * angulo) / 180.0f;
        rx = c + (int)((x - c) * (float)Math.Cos(angulo) - (y - c) * (float)Math.Sin(angulo));
        ry = c + (int)((x - c) * (float)Math.Sin(angulo) + (y - c) * (float)Math.Cos(angulo));
        //System.out.println(rx + "," + ry);
    }





    /*
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

    */

}
