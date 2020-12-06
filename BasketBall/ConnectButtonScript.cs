using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class ConnectButtonScript : MonoBehaviour
{
    public GameObject ConbuttonGroup;
    public GameObject NikbuttonGroup;
    public GameObject RombuttonGroup;
    public Text progress;
    // Start is called before the first frame update
    void Start()
    {
        ConbuttonGroup = GetComponent<GameObject>();
        NikbuttonGroup = GetComponent<GameObject>();
        RombuttonGroup = GetComponent<GameObject>();
        progress = GetComponent<Text>();
        ConbuttonGroup.SetActive(true);
        NikbuttonGroup.SetActive(false);
        RombuttonGroup.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "RightHandAnchor" || other.gameObject.name == "LeftHandAnchor" || other.gameObject.name == "GrabVolumeBig")
        {
            SceneManager.LoadScene("Scene Type 1");
            GameObject.Find("NetworkManeger").GetComponent<NetworkManeger01>().ConnectToServer();
            GameObject.Find("NetworkManeger").GetComponent<NetworkManeger01>().InitializeRoom(0);

        }
    }
}
