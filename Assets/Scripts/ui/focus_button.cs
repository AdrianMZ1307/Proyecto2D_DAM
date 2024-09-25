using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class focus_button : MonoBehaviour
{
    [SerializeField]
    private bool configMenuStatus = false;
    public void isFocus(bool val)
    {
        if (!configMenuStatus)
        {
            GetComponent<Animator>().SetBool("isFocus", val);
        }
        else
        {
            GetComponent<Animator>().SetBool("isFocus", false);
        }
    }

    public void configMenu(bool val)
    {
        configMenuStatus = val;
        GameObject.FindGameObjectWithTag("ConfigPane").GetComponent<Animator>().SetBool("show", val);
    }

    public void newGame()
    {
        Debug.Log("AAAAA");
        if (!configMenuStatus)
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    public void mainMenu()
    {
        Debug.Log("AAAAA");
        if (!configMenuStatus)
        {
            SceneManager.LoadScene("TitleScreenScene");
        }
    }
}
