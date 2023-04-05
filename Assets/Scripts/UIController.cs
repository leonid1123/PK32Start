using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;

public class UIController : MonoBehaviour
{
    [SerializeField]
    TMP_Text HPtext;
    [SerializeField]
    Image HPImage;
    [SerializeField]
    GameObject player;
    void Start()
    {
        
    }
    void Update()
    {
        HPtext.text = "HP:" + player.GetComponent<PlayerController>().GetHP();
        //HPImage.fillAmount = 
    }
}
