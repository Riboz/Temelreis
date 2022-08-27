using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int skor=-1;
    temelmovement Temelmovement;
    public GameObject Restartpanel;
    public GameObject[] kalps;
    int a=0;
    public void Start()
    {
        Temelmovement=GameObject.FindGameObjectWithTag("Player").GetComponent<temelmovement>();
    }
    public void FixedUpdate()
    {
        if(Temelmovement.isdead&&a==0)
        {
           StartCoroutine(restartpanelactivator());
           a=1;
        }
        else return;
    }

    // Update is called once per frame
   public void gamepoint(bool balonyakalandi)
   {
     if(balonyakalandi && skor<11)
     {
      skor+=1;
      if(skor>=0)
      {
        kalps[skor].SetActive(true);
      }
     
     }
     if(skor==11)
     {
        //kazanma enumuna al
        
     }
     
   }
   IEnumerator restartpanelactivator()
   {
    yield return new WaitForSeconds(2f);
    Restartpanel.SetActive(true); 
    yield break;
   }
}
