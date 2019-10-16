using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{    
    public bool show = false;
    public Blocks myBlocks;
    public Name myType;
   
    void Start()
    {
        myBlocks = FindObjectOfType<Blocks>();    
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
        myBlocks.AddCube(this.gameObject);
        show = true;
    }
}
