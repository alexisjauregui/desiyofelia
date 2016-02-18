using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class checkChords : MonoBehaviour {

    public string pass;
    private string chords;
    private Text newText;
    private GameObject Ofelia;
    private GameObject Cage;
    public AudioSource audio;
    bool hasPlayed = false;


    // Use this for initialization
    void Start()
    {
   
        Ofelia = GameObject.FindGameObjectWithTag("Switch");

       
        audio = GetComponent<AudioSource>();
    }
	// Update is called once per frame
	void Update () {

        if (GameObject.FindGameObjectWithTag("Cage"))
        {
            Debug.Log("Cage Found");
        }

        Cage = GameObject.FindGameObjectWithTag("Cage");



        newText = Ofelia.GetComponent<Text>();

        chords = newText.text;



        if (chords== pass)
        {
            Debug.Log("Got to pass");
            Destroy(Cage, 0);
            if (hasPlayed == false)
            {
                hasPlayed = true;
                audio.Play();
            }
        }
        
	}
}
