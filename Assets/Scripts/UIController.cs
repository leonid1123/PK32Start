using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    TMP_Text HPtext;
    [SerializeField]
    Image HPImage;
    [SerializeField]
    GameObject player;
    PlayerController playerController;
    void Start()
    {
        playerController= player.GetComponent<PlayerController>();
    }
    void Update()
    {
        HPtext.text = "HP:" + playerController.GetHP();
        HPImage.fillAmount = (float)playerController.GetHP() / 100;
    }
}
