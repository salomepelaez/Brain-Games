using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Material[] materials = new Material[8];
    public GameObject[] pieces = new GameObject[6];
    private bool show = false;

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
        if(show)
        {
            transform.rotation = Quaternion.Euler(Vector3.Lerp(transform.rotation.eulerAngles, Vector3.up * 180, 2 * Time.deltaTime));
        }

        else
        {
            transform.rotation = Quaternion.Euler(Vector3.Lerp(transform.rotation.eulerAngles, Vector3.zero * 180, 2 * Time.deltaTime));
        }
    }

    private void OnMouseDown()
    {
        show = true;
        Invoke("Turn", 3);
    }

    private void Turn()
    {
        show = false;
    }
}
