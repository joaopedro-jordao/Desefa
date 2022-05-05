using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MaxHPStatus : MonoBehaviour
{

    private string maxHP;
    private TextMeshProUGUI ui; 

    void Start()
    {
        maxHP = "?";
        ui = gameObject.GetComponent<TextMeshProUGUI>();
        ui.text = maxHP;
    }

    private Board board;

    void Update(){
        GameObject boardManager = GameObject.Find("Start");
        board = boardManager.GetComponent<Board>();
        ui.text = board.pieceMaxHP;
    }
}
