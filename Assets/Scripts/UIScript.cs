using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScript : MonoBehaviour
{

    public static UIScript Instance{ set; get; }

    public Server server;
    public Client client;
    
    [SerializeField] private Animator menuAnimator;
    [SerializeField] private TMP_InputField addressInput;

    private void Awake(){
        Instance = this;
    }

    //Buttons transitions

    public void OnHostGameButton(){
        server.Init(8007);
        client.Init("127.0.0.1", 8007);
        menuAnimator.SetTrigger("InGameMenu");
    }

    public void OnEnterGameButton(){
        menuAnimator.SetTrigger("ClientMenu");
    }

    public void OnHostBackButton(){
        server.Shutdown();
        client.Shutdown();
        menuAnimator.SetTrigger("MenuAnimation");
    }

    public void OnEnterGameBackButton(){
        menuAnimator.SetTrigger("MenuAnimation");
    }

    public void OnEnterGameConnectButton(){
        client.Init(addressInput.text, 8007);
        menuAnimator.SetTrigger("InGameMenu");//$$
    }

}
