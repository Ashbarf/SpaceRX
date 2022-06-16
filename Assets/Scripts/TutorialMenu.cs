using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMenu : MonoBehaviour
{
    public GameObject tutorialUI;

    // Start is called before the first frame update
    void Start()
    {
        
        if (MainMenu.instance.isFirstTime)
        {
            tutorialUI.SetActive(true);
            Time.timeScale = 0f;

        } 
        else
        {
            tutorialUI.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void Skip ()
    {
        Time.timeScale = 1f;
    }
}
