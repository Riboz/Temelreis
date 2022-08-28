using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class buttoncode : MonoBehaviour
{

public void oyungir()
{
    SceneManager.LoadScene("level");
    badfatboy.gamestart=false;
    Time.timeScale=1;
}
public void exit()
{
    Application.Quit();
}

}
