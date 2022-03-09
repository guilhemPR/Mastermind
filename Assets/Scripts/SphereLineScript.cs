using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereLineScript : GameScript
{
    [SerializeField] private GameObject[] _localSphereList;
    
    void Start()
    {
        LocalSphereAssignation();
        LocalSphereEnhancement();
    }

    private void LocalSphereAssignation()
    {
        _localSphereList = new GameObject[colorList.Length]; 
        
        for (int i = 0; i < _localSphereList.Length; i++)
        {
            _localSphereList[i] = this.gameObject.transform.GetChild(i).gameObject;
            
            SphereList = _localSphereList; 
        }
    }

    private void LocalSphereEnhancement()
    {
        for (int i = 0; i < SphereList.Length; i++)
        {
            SphereList[i].GetComponent<Renderer>().material.color = Color.white;

        }
    }
}
