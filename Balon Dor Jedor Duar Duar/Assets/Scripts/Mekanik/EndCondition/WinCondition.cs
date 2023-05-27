using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour
{
    public ControlManager ctrl;
    private GameObject isWinningPanel;
    public Animator animator;
    public WaveSpawner wave;
    public Text scoreText;
    public Text failText;
    public StarHolder starHolder;
    public ads ads;
    public int currentLevel = 1;

    private string currentState;

    const string BINTANG0 = "bintang0";
    const string BINTANG1 = "bintang1";
    const string BINTANG2 = "bintang2";
    const string BINTANG3 = "bintang3"; 

    void Start(){
        ads.LoadInterstitialAd();  
        isWinningPanel = GameObject.Find("Win");
    }

    void Update(){
        hitung();
        scoreText.text = ctrl.score.ToString();
        failText.text = ctrl.fail.ToString();   

        if(isWinningPanel.activeSelf){
            EventManager.LevelComplete(currentLevel - 1);
            EventManager.LevelLock(currentLevel - 1);
        }

    }

    void hitung(){

        if(wave.totalEnemy % 2 == 0){
            if(ctrl.score == wave.totalEnemy){
                ChangeAnimationState(BINTANG3);
                starHolder.totalStar += 3;
                ads.ShowAd();
                
            }else
            if(ctrl.score >= (wave.totalEnemy / 2)){
                ChangeAnimationState(BINTANG2);
                starHolder.totalStar += 2;
                ads.ShowAd();
                
            }else
            if(ctrl.score < (wave.totalEnemy / 2)){
                ChangeAnimationState(BINTANG1);
                starHolder.totalStar += 1;
                ads.ShowAd();
                
            }
        }else
        {
            if(ctrl.score == wave.totalEnemy){
                ChangeAnimationState(BINTANG3);
                starHolder.totalStar += 3;
                ads.ShowAd();
                
            }else
            if(ctrl.score >= ((wave.totalEnemy + 1) / 2)){
                ChangeAnimationState(BINTANG2);
                starHolder.totalStar += 2;
                ads.ShowAd();
                
            }else
            if(ctrl.score < ((wave.totalEnemy + 1) / 2)){
                ChangeAnimationState(BINTANG1);
                starHolder.totalStar += 1;
                ads.ShowAd();
                
            }
        }
    }

    void ChangeAnimationState(string newState)
    {
        if(currentState == newState) return;

        animator.Play(newState);

        currentState = newState;
    }

    void Ads(){
        // ads.LoadInterstitialAd();     
        ads.ShowAd();
    }
}
