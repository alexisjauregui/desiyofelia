using UnityEngine;
using System.Collections;

public class levelProg : MonoBehaviour {
    bool level0;
    bool level1;
    bool level2;
    bool level3;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
