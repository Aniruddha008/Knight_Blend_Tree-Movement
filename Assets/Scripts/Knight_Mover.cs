using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Knight_Mover : MonoBehaviour
{
    
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            MoveToCursor();
        }
        UpdateAnimator();
        
    }

    private void UpdateAnimator()
    {
        Vector3 globalVelocity = GetComponent<NavMeshAgent>().velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(globalVelocity);

        float speed = localVelocity.z;
        GetComponent<Animator>().SetFloat("knightSpeed", speed);
    }

    private void MoveToCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit);

        if(hasHit)
        {
            GetComponent<NavMeshAgent>().destination = hit.point;
        }
        
    }
}
