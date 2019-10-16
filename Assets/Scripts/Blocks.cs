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
                int y = 0;
                temp = materialsList[y];
                y++;                
            }
            p.transform.GetChild(i).GetChild(0).GetComponent<MeshRenderer>().material = temp;
            materialsList.Remove(temp);
        }        
    }

    private void OnMouseDown()
    {
        CheckIfMatch();       
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

    public void CheckIfMatch()
    {
        if(Manager.coincidence[0].gameObject.GetComponent<MeshRenderer>().material == Manager.coincidence[1].gameObject.GetComponent<MeshRenderer>().material)
        {
            Debug.Log("nel");
        }
    }
}
