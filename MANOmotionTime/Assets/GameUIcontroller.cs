using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIcontroller : MonoBehaviour
{
    bool menuflag;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        menuflag = true;
        panel.SetActive(menuflag);

    }
    public void EXITtoHome()
    {
        SceneManager.LoadScene("HOMEui");
        Time.timeScale = 1;
    }
    public void Arcade()
    {
        SceneManager.LoadScene("ARCADE");

    }
    public void PRACTICE()
    {
        SceneManager.LoadScene("PRACTICE");

    }
    public void exit()
    {
        Application.Quit();
    }
    public void Menu()
    {
        menuflag = !menuflag;
        panel.SetActive(menuflag);
        if(menuflag)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
