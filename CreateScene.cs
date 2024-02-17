using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateScene : MonoBehaviour
{
    [SerializeField] private int sizeOfForest;
    [SerializeField] private int layers;


    void Start()
    {
        CreateGround();
        CreateRandomForest();
        CreatePyramid();
    }

    void CreateGround()
    {
        GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Plane);
        ground.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
        ground.transform.localScale = new Vector3(3, 1, 3);

        GameObject Ground = GameObject.Find("Ground");
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

        for (int layer = 0; layer < layers; layer++)
        {
            for (int posX = 0; posX <= layer; posX++)
            {
                for (int posZ = 0; posZ <= layer; posZ++)
                {
                    Vector3 positionOffset = new Vector3(posX - layer / 2.0f, -layer, posZ - layer / 2.0f);
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.position = transform.position + positionOffset;

                    cube.GetComponent<Renderer>().material.color = new Color((float)layer, (float)layer * 2, (float)layer * 3, 1);
                    cube.transform.parent = GameObject.Find("Pyramid").transform;
                }
            }
        }
    }
}
