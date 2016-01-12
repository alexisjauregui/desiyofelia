using UnityEngine;
using System.Collections;

public class Quit : MonoBehaviour {

    public void EndGame()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Button pressed!");
                Application.Quit();
            }
        }
}
