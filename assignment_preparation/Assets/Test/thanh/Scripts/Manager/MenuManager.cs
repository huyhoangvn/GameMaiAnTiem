using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panelMenu;
    private bool isShow = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowMenu()
    {
        if (isShow)
        {
            panelMenu.SetActive(true);
            Time.timeScale = 0;
            isShow = false;
        }
        else
        {
            panelMenu.SetActive(false);
            Time.timeScale = 1;
            isShow = true;
        }
    }
    public void Continue()
    {
        Time.timeScale = 1;
        panelMenu.SetActive(false);

    }
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
