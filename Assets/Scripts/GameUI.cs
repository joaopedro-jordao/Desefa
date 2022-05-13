using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{

    public static UIScript Instance {set; get;}

    private void Awake(){
        Instance = this;
    }

}
