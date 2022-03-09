using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : GameScript
{
    [SerializeField] Camera playerCamera;
  

    private int actualColorInCollorList = 0; 
    // Start is called before the first frame update
    void Start()
    {
       ColorListAssignation();
       TrueColorOrderAssignation();
       SphereListSize();
       LineAssignation();
       ActiveLineSetUp();
       
      
    }

    // Update is called once per frame
    void Update()
    {
        GetMouseWorldPosition(playerCamera);
    }
  
    
    void GetMouseWorldPosition (Camera playerCamera)
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit) && raycastHit.collider.gameObject.CompareTag("Sphere"))
        {
          ChangeSphereColor( raycastHit.collider.gameObject);
        }
    }

    void ChangeSphereColor(GameObject sphereTarget)
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && sphereTarget.transform.parent.gameObject.GetComponent<SphereLineScript>().enabled)
        {
            if (actualColorInCollorList >= colorList.Length)
            {
                actualColorInCollorList = 0; 
            }

            sphereTarget.GetComponent<Renderer>().material.color = colorList[actualColorInCollorList];

            actualColorInCollorList++;


        }
    }


}
