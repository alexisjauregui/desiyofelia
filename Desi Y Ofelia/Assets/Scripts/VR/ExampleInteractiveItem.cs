using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using VRStandardAssets.Utils;


namespace VRStandardAssets.Examples
{
    // This script is a simple example of how an interactive item can
    // be used to change things on gameobjects by handling events.
    public class ExampleInteractiveItem : MonoBehaviour
    {   
        [SerializeField] private VRInteractiveItem m_InteractiveItem;
        private Text status;

        private void Awake ()
        {
            status = GameObject.Find("Status").GetComponent<Text>();
        }


        private void OnEnable()
        {
            m_InteractiveItem.OnOver += HandleOver;
            m_InteractiveItem.OnOut += HandleOut;
            m_InteractiveItem.OnClick += HandleClick;
            m_InteractiveItem.OnDoubleClick += HandleDoubleClick;
        }


        private void OnDisable()
        {
            m_InteractiveItem.OnOver -= HandleOver;
            m_InteractiveItem.OnOut -= HandleOut;
            m_InteractiveItem.OnClick -= HandleClick;
            m_InteractiveItem.OnDoubleClick -= HandleDoubleClick;
        }


        //Handle the Over event
        private void HandleOver()
        {
        }


        //Handle the Out event
        private void HandleOut()
        {
        }


        //Handle the Click event
        private void HandleClick()
        {
            Debug.Log("Show click state");
            if (this.gameObject.name == "Host")
                status.text = "host";
            else if (this.gameObject.name == "Join")
                status.text = "join";
        }


        //Handle the DoubleClick event
        private void HandleDoubleClick()
        {
        }
    }

}