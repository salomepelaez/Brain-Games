using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{    
    private bool show = false;
        
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
        Invoke("Turn", 5);        
    }

    private void Turn()
    {
        show = false;
    }

    
}
