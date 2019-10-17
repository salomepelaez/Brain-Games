using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    public GameObject p;
    public Material[] materials = new Material[8];
    public List<Material> materialsList = new List<Material>();
    public Material temp;
    public GameObject first, second;

    public Dictionary<Material, Name> dic = new Dictionary<Material, Name>();

    private void Awake()
    {
        References();
    }

    void Start()
    {
        for (int i = 0; i < materials.Length; i++)
        {
            materialsList.Add(materials[i]);
            materialsList.Add(materials[i]);
        }

        Shuffle(ref materialsList);

        for (int i = 0; i <= 15; i++)
        {
            p.transform.GetChild(i).GetChild(0).GetComponent<MeshRenderer>().material = materialsList[i];
            p.transform.GetChild(i).GetChild(0).GetComponent<Manager>().myType = dic[materialsList[i]];

        }
    }

    public void References()
    {
        dic.Add(materials[0], Name.Llama);
        dic.Add(materials[1], Name.Waves);
        dic.Add(materials[2], Name.Sunflower);
        dic.Add(materials[3], Name.Sun);
        dic.Add(materials[4], Name.Flower);
        dic.Add(materials[5], Name.Macaroon);
        dic.Add(materials[6], Name.Hand);
        dic.Add(materials[7], Name.Lenny);
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

    public void AddCube(GameObject cube)
    {
        if (first == null)
        {
            first = cube; 
        }
        else if (first != cube)
        {
            second = cube;
            CheckIfMatch();
        }
    }

    private void CheckIfMatch()
    {
        if(first.GetComponent<Manager>().myType == second.GetComponent<Manager>().myType)
        {
            Invoke("Match", 2.0f);
        }

        else if (first.GetComponent<Manager>().myType != second.GetComponent<Manager>().myType)
        {
            Invoke("DoesNotMatch", 2.0f);
        }
    }

    private void DoesNotMatch()
    {        
        first.GetComponent<Manager>().show = false;
        second.GetComponent<Manager>().show = false;
        first = null;
        second = null;
    }

    private void Match()
    {
        Destroy(first);
        Destroy(second);
    }

}

public enum Name { Llama, Waves, Sunflower, Sun, Flower, Macaroon, Hand, Lenny}
