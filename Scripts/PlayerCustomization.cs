using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCustomization : MonoBehaviour
{
    public int clicks = 0;
    public GameObject player;
    public GameObject playerPrefab;
    public static PlayerCustomization instance;
    public Material playerColor;

    private void Start()
    {
        instance = this;
        playerColor = Resources.Load("Player_Blue", typeof(Material)) as Material;
    }

    private void Update()
    {
        switch (clicks)
        {
            case -1:
                clicks = 6;
                break;
            case 0:
                playerColor = Resources.Load("Player_Blue", typeof(Material)) as Material;
                break;
            case 1:
                playerColor = Resources.Load("Player_Orange", typeof(Material)) as Material;
                break;
            case 2:
                playerColor = Resources.Load("Player_Yellow", typeof(Material)) as Material;
                break;
            case 3:
                playerColor = Resources.Load("Player_Green", typeof(Material)) as Material;
                break;
            case 4:
                playerColor = Resources.Load("Player_Purple", typeof(Material)) as Material;
                break;
            case 5:
                playerColor = Resources.Load("Player_Pink", typeof(Material)) as Material;
                break;
            case 6:
                playerColor = Resources.Load("Player_Red", typeof(Material)) as Material;
                break;
            case 7:
                clicks = 0;
                break;
        }
        player.GetComponent<MeshRenderer>().material = playerColor;
        playerPrefab.GetComponent<MeshRenderer>().material = playerColor;
    }

    public void NextColor()
    {
        clicks++;
    }

    public void LastColor()
    {
        clicks--;
    }

}

