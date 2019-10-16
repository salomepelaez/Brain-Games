using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{    
    public bool show = false;
    public static GameObject[] coincidence = new GameObject[2];
    //GameObject first;
    //GameObject second;

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

        if(coincidence[0] == null)
        {
            coincidence[0] = gameObject;            
        }

        else if (coincidence[1] == null)
        {
            coincidence[1] = gameObject;
        }
    }

    private void Turn()
    {
        show = false;
    }

    
}
