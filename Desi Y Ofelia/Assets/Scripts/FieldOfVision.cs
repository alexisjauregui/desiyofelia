using UnityEngine;
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
        Debug.Log("start ");
        StartCoroutine("FindTargetsWithDelay", .2f);
    }


    IEnumerator FindTargetsWithDelay(float delay)
    {

        Debug.Log(" Find Target with delay ");
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisTarget();
        }
    }

    void FindVisTarget()
    {
        Debug.Log(" Find Vis Called ");
        visibleTargets.Clear();
        Collider[] targetVisibleRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        for(int i = 0; i <targetVisibleRadius.Length; i++)
        {
            Debug.Log(" in for loop ");
            Transform target = targetVisibleRadius[i].transform;
            Vector3 dirtoTarget = (target.position - transform.position).normalized;
            if(Vector3.Angle(transform.forward,dirtoTarget)< viewAngle / 2)
            {
                float dsttoTarget = Vector3.Distance(transform.position, target.position);

                if(!Physics.Raycast(transform.position, dirtoTarget, dsttoTarget, obstaclesMask))
                {
                    Debug.Log("Target found!!!");
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
