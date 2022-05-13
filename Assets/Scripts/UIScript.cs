using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{

    public static UIScript Instance{ set; get; }
    
    [SerializeField] private Animator menuAnimator;

    private void Awake(){
        Instance = this;
    }

    public void OnHostGameButton(){
        Debug.Log("OnHost");
        menuAnimator.SetTrigger("HostMenuAnimation");
    }

    public void OnEnterGameButton(){
        menuAnimator.SetTrigger("ClientMenu");
    }

    public void OnHostBackButton(){
        menuAnimator.SetTrigger("MenuAnimation");
    }

    public void OnEnterGameBackButton(){
        menuAnimator.SetTrigger("MenuAnimation");
    }

    public void OnEnterGameConnectButton(){
        menuAnimator.SetTrigger("OnEnterGameConnectButton");//$$
    }

}
