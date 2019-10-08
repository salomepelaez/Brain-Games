using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Material[] materials = new Material[8];
    public GameObject[] pieces = new GameObject[6];
    void Start()
    {
        GameObject pieza = new GameObject();

        for (int i = 0; i < pieces.Length; i++)
        {
            pieza.transform.GetChild(i).GetChild(0).GetComponent<MeshRenderer>().material = materials[Random.Range(0, materials.Length)];
        }
    }

    void Update()
    {
        
    }
}
