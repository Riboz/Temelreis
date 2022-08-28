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
}
public void exit()
{
    Application.Quit();
}

}
