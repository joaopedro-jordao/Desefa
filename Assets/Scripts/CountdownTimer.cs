using UnityEngine;
using System;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    private float currentTime;
    private float startingTime;
    private bool isRunning;
    
    private TextMeshProUGUI timer;

    public void StartTimer(){
        isRunning = true;
    }

    public void StopTimer(){
        isRunning = false;
        updateTimer();
    }

    private void updateTimer(){
        timer.text = TimeSpan.FromSeconds(currentTime).ToString(@"h\:mm\:ss");
    }

    void Start() {
        startingTime = 60;
        currentTime = startingTime*60;
        isRunning = false;
        timer = gameObject.GetComponent<TextMeshProUGUI>();
        updateTimer();
    }

    void Update(){
        if(!isRunning) return;
        currentTime -= 1*Time.deltaTime;
        updateTimer();

        if(currentTime <= 0){
            currentTime = 0;
            StopTimer();
            GameManager.Instance.TurnPlayerLose();
        }
    }
}
