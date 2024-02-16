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

        for (int treeNum = 0; treeNum <= Random.Range(9, 15); treeNum++)
        {
            GameObject forestTrees = Instantiate(trees, new Vector3(Random.Range(1, 5), 1, Random.Range(1, 5)), Quaternion.identity) as GameObject;
            GameObject Forest = GameObject.Find("Forest");
            forestTrees.transform.parent = Forest.transform;

        }
    }

    void CreatePyramid()
    {
        GameObject stones = GameObject.CreatePrimitive(PrimitiveType.Cube);
        stones.GetComponent<Renderer>().material.color = new Color(1, 0.92f, 0.016f, 1);
        stones.transform.position = new Vector3(0, 0.5f, -2);


    }
}
