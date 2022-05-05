using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AtkStatus : MonoBehaviour
{
    private string atk;
    private TextMeshProUGUI ui; 

    void Start()
    {
        atk = "?";
        ui = gameObject.GetComponent<TextMeshProUGUI>();
        ui.text = atk;
    }

    private Board board;

    void Update(){
        GameObject boardManager = GameObject.Find("Start");
        board = boardManager.GetComponent<Board>();
        ui.text = board.pieceAtk;
    }
}
