using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageButtons : MonoBehaviour
{
    public void OnClickLoad()
    {
        Debug.Log("game start");

        //change what scene you want to load
        SceneManager.LoadScene("Game");
    }

    public void OnClickQuit()
    {
        //disable this function if we think it is unusable
        Debug.Log("game quit");
        Application.Quit();
    }
}
