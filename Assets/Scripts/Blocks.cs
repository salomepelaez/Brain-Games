using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    public GameObject p; 
    public List<Material> materialsList = new List<Material>();
    public Material temp;

    void Start()
    {
        Shuffle(ref materialsList);

        for (int i = 0; i < 15; i++)
        {
            foreach (var item in materialsList)
            {
                int index = 0;
                temp = materialsList[index];
                index++;                
            }
            p.transform.GetChild(i).GetChild(0).GetComponent<MeshRenderer>().material = temp;
            materialsList.Remove(temp);
        }        
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
