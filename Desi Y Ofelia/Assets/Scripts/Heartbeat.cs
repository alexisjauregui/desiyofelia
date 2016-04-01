using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Heartbeat : MonoBehaviour {
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obstaclesMask;

    public AudioClip beats;
    private AudioSource audiosource;


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

    }

    void FindVisTarget()
    {
        audiosource = GetComponent<AudioSource>();
        visibleTargets.Clear();
        audiosource.Pause();
        Collider[] targetVisibleRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        //Heartbeats
       

        for (int i = 0; i < targetVisibleRadius.Length; i++)
        {

            Transform target = targetVisibleRadius[i].transform;
            Vector3 dirtoTarget = (target.position - transform.position).normalized;

            //if it is in the small circle
            if (Vector3.Angle(transform.forward, dirtoTarget) < viewAngle / 2)
            {
                float dsttoTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, dirtoTarget, dsttoTarget, obstaclesMask))
                {
                    Debug.Log("Target found!!!");
                    // Add Code Here Stella 
                    visibleTargets.Add(target);
                    audiosource.loop = true;
                    audiosource.Play();

            
                }
                else
                {
                  

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
