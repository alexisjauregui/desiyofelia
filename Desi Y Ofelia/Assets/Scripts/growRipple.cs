using UnityEngine;
using System.Collections;

public class growRipple : MonoBehaviour {

    private float growthRate;
    private float maxSize;
    private float scale;

    void Start()
    {
        growthRate = 1.0f;
        maxSize = 2.5f;
        scale = 1.0f;

    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(1 * scale, 1 * scale, 0.5f);
        scale += growthRate * Time.deltaTime;
        if (scale > maxSize) Destroy(gameObject);
    }
}