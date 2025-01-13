using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour
{
    public Transform pointer;
 
    void Start()
    {
        
    }

    
    void Update()
    {

     Ray ray= new Ray(transform.position,transform.forward);
     RaycastHit hit;
     Debug.DrawRay(transform.position, transform.forward*100f,Color.green);
        if (Physics.Raycast(ray,out hit))
            pointer.position = hit.point;
            hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.red;
            Debug.Log(hit.collider.ToString());
    }
}
