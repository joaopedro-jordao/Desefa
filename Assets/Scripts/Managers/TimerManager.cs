using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public CountdownTimer timerWhite, timerBlack;
    public TextMeshProUGUI actualPlayer;
    
    public void SwitchTimer(){
        if(GameManager.Instance.GetTurnPlayer() == GameManager.TurnPlayer.white){
            timerWhite.StartTimer();
            timerBlack.StopTimer();
            actualPlayer.text = "White";
        }else{
            timerWhite.StopTimer();
            timerBlack.StartTimer();
            actualPlayer.text = "Black";
        }
    }
}
