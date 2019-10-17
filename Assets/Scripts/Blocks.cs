﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Blocks : MonoBehaviour
{
    public GameObject p;
    public Material[] materials = new Material[8];
    public List<Material> materialsList = new List<Material>();
    public Material temp;
    public GameObject first, second;

    public Dictionary<Material, Name> dic = new Dictionary<Material, Name>();

    public TextMeshProUGUI timer;

    private bool player1 = true;
    private TextMeshProUGUI player;
    private TextMeshProUGUI _player1;
    private TextMeshProUGUI _player2;

    private void Awake()
    {
        References();
        timer = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
        player = GameObject.Find("Player").GetComponent<TextMeshProUGUI>();
        _player1 = GameObject.Find("Player1").GetComponent<TextMeshProUGUI>();
        _player2 = GameObject.Find("Player2").GetComponent<TextMeshProUGUI>();
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

        InvokeRepeating("TimeCounter", 0, 1f);
    }

    int time = 0;
    int counter1 = 0;
    int counter2 = 0;
    private void Update()
    {
        timer.text = "Time: " + time;
        _player1.text = "Player 1 points: " + counter1;
        _player2.text = "Player 2 points: " + counter2;

        if (player1)
        {
            player.text = "Go ahead player 1";
        }

        else
            player.text = "Go ahead player 2";

        if(aMatch == true && player1 == true)
        {
            counter2 = counter2 + 5;
            aMatch = false;
        }

        else if (aMatch == true && player1 == false)
        {
            counter1 = counter1 + 5;
            aMatch = false;
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
            player1 = !player1;
        }
    }

    bool aMatch;
    private void CheckIfMatch()
    {
        if(first.GetComponent<Manager>().myType == second.GetComponent<Manager>().myType)
        {
            Invoke("Match", 2.0f);
            aMatch = true;
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

    private void TimeCounter()
    {        
        time++;
    }

}

public enum Name { Llama, Waves, Sunflower, Sun, Flower, Macaroon, Hand, Lenny}
