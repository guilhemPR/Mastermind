using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript: MonoBehaviour
{
  public Color32[] colorList = new Color32[4];
  public Color32[] trueColorList;

  public  GameObject[] SphereList;
 
  public GameObject majorLine;
  protected GameObject[] linesList = new GameObject[12];
  public GameObject activeSphereLine;
  protected int activeSphereLineNomber = 0; 
  
  public SphereLineScript SphereLineScript; 

  protected void ColorListAssignation()
  {
    for (int i = 0; i < colorList.Length; i++)
    {
      colorList[i] = new Color32((byte)Random.Range(0, 256), (byte)Random.Range(0, 256), (byte)Random.Range(0, 256), 255);

    }
  }

  protected void TrueColorOrderAssignation()
  {
    trueColorList = new Color32[colorList.Length]; 
    
    for (int i = 0; i < trueColorList.Length; i++)
    {
      int randomNomber = Random.Range(0, trueColorList.Length);

      trueColorList[i] = colorList[randomNomber]; 
      
    }
  }

  public void SphereListSize()
  {
    SphereList = new GameObject[colorList.Length]; 
  }
  
  

  public void LineAssignation()
  {
    for (int i = 0; i < linesList.Length; i++)
    {
      linesList[i] = majorLine.transform.GetChild(i).gameObject;
            
    }
  }

  protected void ActiveLineSetUp()
  {
    linesList[activeSphereLineNomber].GetComponent<SphereLineScript>().enabled = true;
  }

  public void GameChecker() // Important
  {
    activeSphereLine = linesList[activeSphereLineNomber]; 
    SphereLineScript = activeSphereLine.GetComponent<SphereLineScript>();
    SphereList = SphereLineScript.SphereList; 
    
    
    for (int i = 0; i < trueColorList.Length; i++)
    {
      Debug.Log("proute");
      
      if (trueColorList[i] != SphereList[i].GetComponent<Renderer>().material.color)
      {
        i = trueColorList.Length;

        if (activeSphereLineNomber++ >= linesList.Length)
        {
          // c'est perdu
          Debug.Log("c'est perdu");
        }
        else
        {
          activeSphereLineNomber++; // Line change, game coutinuous
          
          ActiveLineSetUp();
          // Interaction de trie des ball pour savoir si :
          // - Elle est au bonne endroit et de la bonne couleur
          // - Elle est au mauvaise endroit mais de la bonne couleur

        }
        
      }
      else if(i++ >= trueColorList.Length)
      {
        i = trueColorList.Length;
        // c'est gagner
        
        Debug.Log("c'est gagner");
      }
    }
    
  }

  protected void SphereChecker()
  {

    for (int i = 0; i < SphereList.Length ; i++)
    {
      
      
      
      
      
    }
  }
  
  
}






























