using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private bool show = false;

    void Update()
    {
        if(show == true)
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
