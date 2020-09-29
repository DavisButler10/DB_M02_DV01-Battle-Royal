using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class ColorChange : MonoBehaviourPun
{
    public MeshRenderer mr;
    public int id;
    public TextMesh name;

    [PunRPC]
    public void Initialize(Player player)
    {
        mr.material = PlayerCustomization.instance.playerColor;
        name.text = player.NickName;
    }
}
