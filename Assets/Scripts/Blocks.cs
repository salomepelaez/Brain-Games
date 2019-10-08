using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    public GameObject p; 
    public Material[] materials = new Material[8];
    //public GameObject[] pieces = new GameObject[6];
    public List<Material> materialsList = new List<Material>();
    //GameObject[] piece;

    void Start()
    {
        Shuffle(ref materialsList);
        //GameObject p = new GameObject();
        for (int i = 0; i < materials.Length; i++)
        {
            p.transform.GetChild(i).GetChild(0).GetComponent<MeshRenderer>().material = materials[Random.Range(0, materials.Length)];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Shuffle(ref List<Material> members)
    {
        int n = members.Count;

        while(n > 1)
        {
            n--;
            int x = Random.Range(0, n + 1);
            Material value = members[x];
            members[x] = members[n];
            members[n] = value;
        }
    }
}
