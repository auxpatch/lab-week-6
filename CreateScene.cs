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
        ground.transform.localScale = new Vector3(3, 1, 3);

        GameObject Ground = GameObject.Find("Pyramid");
        ground.transform.parent = Ground.transform;
        
    }

    void CreateRandomForest()
    {
        GameObject trees = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        trees.GetComponent<Renderer>().material.color = new Color(0, 1, 0, 1);
        Destroy(trees);
        
        for (int treeNum = 0; treeNum <= sizeOfForest; treeNum++)
        {
            GameObject forestTrees = Instantiate(trees, new Vector3(Random.Range(-4, 4), Random.Range(0.2f, 1), Random.Range(1, 4)), Quaternion.identity);
            forestTrees.transform.localScale = new Vector3(Random.Range(0.5f, 2f), 1, Random.Range(0.2f, 1.3f));

            GameObject Forest = GameObject.Find("Forest");
            forestTrees.transform.parent = Forest.transform;

        }
    }

    void CreatePyramid()
    {
        GameObject stones = GameObject.CreatePrimitive(PrimitiveType.Cube);
        stones.GetComponent<Renderer>().material.color = new Color(1, 0.92f, 0.016f, 1);
        Destroy(stones);

        for(int stoneNum = 0; stoneNum <= stonesRequired; stoneNum++)
        {
            GameObject pyramidStone = Instantiate(stones, new Vector3(-3, 0.5f, -3), Quaternion.identity);
            pyramidStone.transform.localScale = new Vector3(1, 1, 1);

            GameObject Pyramid = GameObject.Find("Pyramid");
            pyramidStone.transform.parent = Pyramid.transform;

        }
    }
}
