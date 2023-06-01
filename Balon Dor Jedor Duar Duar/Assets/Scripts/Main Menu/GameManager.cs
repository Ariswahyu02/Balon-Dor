using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isCompleted = true;

    private void OnEnable() {
        Debug.Log("level enaasdadble");
        EventManager.OnLevelCompleted += CompleteLevel;
        EventManager.OnLevelUnlocked += UnlockLevel;
    }

    private void OnDisable() {
        EventManager.OnLevelCompleted -= CompleteLevel;
        EventManager.OnLevelUnlocked -= UnlockLevel;
    }

    public void CompleteLevel(int level)
    {
        Debug.Log("Level " + (level + 1) + " is completed!");
        DataPersistence.instance.AddLevelCompleted(level);
    }

    public void UnlockLevel(int level)
    {
        Debug.Log("Level " + (level + 2) + " is unlocked!");
        DataPersistence.instance.AddUnlockedLevel(level);
    }


    public void GetAchievment(){
        if (isCompleted)
        {
            Debug.Log("Level " + " is completed and you got an achievment!");
        }
    }

    

    

}
