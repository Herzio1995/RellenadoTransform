using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject Parent;
    [SerializeField] GameObject CirclePrefab;
    [SerializeField] GameObject SquarePrefab;
    [SerializeField] GameObject TrianglePrefab;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;   
    }

    public void InstantiateCircle() {
        GameObject circleObject = Instantiate(CirclePrefab) as GameObject;
        circleObject.transform.SetParent(Parent.transform);
        circleObject.transform.position = Parent.transform.position;

    }

    public void InstantiateSquare()
    {
        GameObject circleObject = Instantiate(SquarePrefab) as GameObject;
        circleObject.transform.SetParent(Parent.transform);
        circleObject.transform.position = Parent.transform.position;

    }
    // Update is called once per frame

}
