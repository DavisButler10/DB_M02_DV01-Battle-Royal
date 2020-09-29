using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class GameUI : MonoBehaviour
{
    public Slider healthBar;
    public TextMeshProUGUI playerInfoText;
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI winText;
    public Image winBackground;
    public GameObject tabMenu;
    public TextMeshProUGUI tabPlayerInfoText;
    private PlayerController player;

    public static GameUI instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        tabMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            tabMenu.SetActive(true);
        }
        else
        {
            tabMenu.SetActive(false);
        }
        SetPlayerInfoTab();
    }

    public void Initialize(PlayerController localPlayer)
    {
        player = localPlayer;
        healthBar.maxValue = player.maxHp;
        healthBar.value = player.curHp;

        UpdatePlayerInfoText();
        UpdateAmmoText();
    }

    public void UpdateHealthBar()
    {
        healthBar.value = player.curHp;
    }

    public void UpdatePlayerInfoText()
    {
        playerInfoText.text = "<b>Alive:</b> " + GameManager.instance.alivePlayers;
    }

    public void UpdateAmmoText()
    {
        ammoText.text = player.weapon.curAmmo + "/" + player.weapon.maxAmmo;
    }

    public void SetWinText(string winnerName)
    {
        winBackground.gameObject.SetActive(true);
        winText.text = winnerName + " wins!";
    }

    public void SetPlayerInfoTab()
    {
        tabPlayerInfoText.text = "";
        for (int i = 0; i < GameManager.instance.players.Length; i++)
        {
            if(GameManager.instance.players[i] != null)
            {
                Debug.Log(GameManager.instance.players[i].photonPlayer.NickName);
                tabPlayerInfoText.text += GameManager.instance.players[i].photonPlayer.NickName.PadRight(26) + GameManager.instance.players[i].kills.ToString().PadRight(26) + GameManager.instance.players[i].curHp.ToString().PadRight(26) + "\n";
            }
        }
    }
}