using UnityEngine;
using System.Collections;

public class grabndrop : MonoBehaviour {
    GameObject grabbedObject;
    float grabbedObjectSize;
    Renderer yo;

    GameObject GetMouseHoverObject(float range)
    {
        Vector3 position = gameObject.transform.position;
        RaycastHit raycastHit;
        Vector3 target = position + Camera.main.transform.forward * range;
        if (Physics.Linecast(position, target, out raycastHit))
            return raycastHit.collider.gameObject;
        return null;
    }

    void TryGrabObject(GameObject grabObject)
    {
        if (gameObject == null )
            return;

        if (grabObject.tag == "Candle")
        {
            grabbedObject = grabObject;
            yo = grabbedObject.GetComponent<Renderer>();
            grabbedObjectSize = yo.bounds.size.magnitude;
            
        }
    }

    void DropObject()
    {
        if (gameObject == null)
            return;

        
        grabbedObject = null;

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GetMouseHoverObject(10));

        if (Input.GetMouseButtonDown(0))
        {
            if (grabbedObject == null)
                TryGrabObject(GetMouseHoverObject(10));
            else
                DropObject();

        }

        if(grabbedObject != null)
        {
            Vector3 newPositon = gameObject.transform.position + Camera.main.transform.forward * grabbedObjectSize;
            grabbedObject.transform.position = newPositon;

        }
    }
}
