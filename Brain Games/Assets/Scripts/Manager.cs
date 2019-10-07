using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Material[] materials = new Material[8];
    public GameObject[] pieces = new GameObject[6];
    private bool show = false;
    int numTextures = 0;

    private void Start()
    {
        for(int i = 0; i < pieces.Length; i++)
        {
            GameObject piece = new GameObject();
            piece.transform.GetChild(numTextures).gameObject.GetComponent<MeshRenderer>();
            piece.transform.GetChild(numTextures).gameObject.AddComponent<MeshRenderer>().material = materials[Random.Range(0, materials.Length)];
        }

        numTextures++;
    }

    void Update()
    {
        if (show == true)
        {
            transform.rotation = Quaternion.Euler(Vector3.Lerp(transform.rotation.eulerAngles, Vector3.up * 180, 2 * Time.deltaTime));
        }

        else
        {
            transform.rotation = Quaternion.Euler(Vector3.Lerp(transform.rotation.eulerAngles, Vector3.zero, 2 * Time.deltaTime));
        }
    }

    private void OnMouseDown()
    {
        show = true;
        Debug.Log("ahhhh");
        Invoke("TurnAround", 3);
    }

    private void TurnAround()
    {
        show = false;
    }
}
