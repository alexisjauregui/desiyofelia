using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class FOVAlpha : MonoBehaviour
{

    public float viewRadius;
    [Range(0, 360)]
    public float bigViewAngle;
    public float smallViewAngle;

    public LayerMask targetMask;
    public LayerMask obstaclesMask;



    [HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();

    public GameObject look;

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

    void dontLook(Vector3 dirtoTarget, Transform target)
    {
        float dsttoTarget = Vector3.Distance(transform.position, target.position);

        if (!Physics.Raycast(transform.position, dirtoTarget, dsttoTarget, obstaclesMask))
        {
            Debug.Log("Target found!!!");
            // Add Code Here Stella 
            look.GetComponentInChildren<CanvasGroup>().alpha = 1;
            visibleTargets.Add(target);

        }
        else
        {
            look.GetComponentInChildren<CanvasGroup>().alpha = 0;
        }
    }

    void FindVisTarget()
    {
        visibleTargets.Clear();
        look.GetComponentInChildren<CanvasGroup>().alpha = 0;
        Collider[] targetVisibleRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        for (int i = 0; i < targetVisibleRadius.Length; i++)
        {

            Transform target = targetVisibleRadius[i].transform;
            Vector3 dirtoTarget = (target.position - transform.position).normalized;

            //if it is in the small circle
            if (Vector3.Angle(transform.forward, dirtoTarget) < smallViewAngle / 2)
            {
                dontLook(dirtoTarget, target);
            }
            //if it is in the big circle
            else if (Vector3.Angle(transform.forward, dirtoTarget) < bigViewAngle / 2)
            {
                //if the object is not in the "red zone"
                if (true)
                {
                    dontLook(dirtoTarget, target);
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
