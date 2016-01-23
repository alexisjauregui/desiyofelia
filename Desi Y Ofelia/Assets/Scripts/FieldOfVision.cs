﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FieldOfVision : MonoBehaviour {

    public float viewRadius;
    [Range (0,360)]
    public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obstaclesMask;

    [HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();

    void Start()
    {
       
        StartCoroutine("FindTargetsWithDelay", .2f);
    }


    IEnumerator FindTargetsWithDelay(float delay)
    {

       
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisTarget();
        }
    }

    void FindVisTarget()
    {
       
        visibleTargets.Clear();
        Collider[] targetVisibleRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        for(int i = 0; i <targetVisibleRadius.Length; i++)
        {
            
            Transform target = targetVisibleRadius[i].transform;
            Vector3 dirtoTarget = (target.position - transform.position).normalized;
            if(Vector3.Angle(transform.forward,dirtoTarget)< viewAngle / 2)
            {
                float dsttoTarget = Vector3.Distance(transform.position, target.position);

                if(!Physics.Raycast(transform.position, dirtoTarget, dsttoTarget, obstaclesMask))
                {
                    Debug.Log("Target found!!!");
                    // Add Code Here Stella 


                    visibleTargets.Add(target);
                }
            }
        }
    }


	// Update is called once per frame
	public Vector3 DirFromAngle(float angleinDeg, bool angleisGlobal)
    {
        if (!angleisGlobal)
        {
            angleinDeg += transform.eulerAngles.y;
        
        }
        return new Vector3(Mathf.Sin(angleinDeg * Mathf.Deg2Rad), 0, Mathf.Cos(angleinDeg * Mathf.Deg2Rad));
    }
}
