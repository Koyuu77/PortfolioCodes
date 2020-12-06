using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "RightHandAnchor" || other.gameObject.name == "LeftHandAnchor" || other.gameObject.name == "GrabVolumeBig")
        {
            GameObject.Find("NetworkManeger").GetComponent<NetworkManeger01>().InitializeRoom(0);
        }
    }

}
