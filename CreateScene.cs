using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CreateScene : MonoBehaviour
{
    public int sizeOfForest;
    public int stonesRequired;
    public GameObject[] trees;
    public GameObject[] stones;

    void Start()
    {
        InitializeVariables();
        CreateGround();
        CreateRandomForest();
        CreatePyramid();
    }

    void InitializeVariables()
    {
        sizeOfForest = 15;
        stonesRequired = 55;
        trees = new GameObject[sizeOfForest];
        stones = new GameObject[stonesRequired];
    }

    void CreateGround()
    {
        GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
        ground.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
    }

    void CreateRandomForest()
    {
        GameObject trees = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        trees.GetComponent<Renderer>().material.color = new Color(0, 1, 0, 1);
        trees.transform.position = new Vector3(0, 1, 1);
    }

    void CreatePyramid()
    {
        GameObject stones = GameObject.CreatePrimitive(PrimitiveType.Cube);
        stones.transform.position = new Vector3(0, 0.5f, -2);

    }
}
