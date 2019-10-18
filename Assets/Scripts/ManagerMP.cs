using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerMP : MonoBehaviour
{
    public bool show = false;
    public static bool lockMouse;

    public Name myType;

    public MultiplayerGame multiplayerP;

    void Start()
    {
        multiplayerP = FindObjectOfType<MultiplayerGame>();
    }

    void Update()
    {
        if (show)
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
        if (!lockMouse)
        {
            multiplayerP.AddCube(this.gameObject);
            show = true;
        }
    }
}
