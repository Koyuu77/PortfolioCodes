using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class BasketScript : MonoBehaviourPunCallbacks
{
    public Vector3 a01;
    public Vector3 a02;
    public Vector3 a03;
    public Vector3 a04;
    public GameObject screenObj;
    public Image image;
    public int answer;
    // Start is called before the first frame update
    void Start()
    {
        a01 = new Vector3(-13.4f, 8.2f, -3.0f);
        a02 = new Vector3(-13.4f, 8.2f, -1.0f);
        a03 = new Vector3(-13.4f, 8.2f, 1.0f);
        a04 = new Vector3(-13.4f, 8.2f, 3.0f);
        screenObj = GameObject.FindGameObjectWithTag("Screen");
        image = screenObj.GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        if (screenObj.GetComponent<Image>().sprite.name == "01")
        {
            answer = 1;
        }
        else if (screenObj.GetComponent<Image>().sprite.name == "02img")
        {
            answer = 2;
        }
        else if (screenObj.GetComponent<Image>().sprite.name == "03img")
        {
            answer = 3;
        }
    }

    public void OnTriggerEnter(Collider photonView)
    {

        if (photonView.gameObject.tag == "Hanja")
        {
                if (photonView.gameObject.name == "01-1 Variant(Clone)" || photonView.gameObject.name == "01-2 Variant(Clone)" || photonView.gameObject.name == "01-3 Variant(Clone)" || photonView.gameObject.name == "01-4 Variant(Clone)")
                {
                    if (photonView.gameObject.name == "01-1 Variant(Clone)")
                    {
                        Answer1_01();
                    }
                    else if (photonView.gameObject.name == "01-2 Variant(Clone)")
                    {
                        Answer1_02();
                    }
                    else if (photonView.gameObject.name == "01-3 Variant(Clone)")
                    {
                        Answer1_03();
                    }
                    else if (photonView.gameObject.name == "01-4 Variant(Clone)")
                    {
                        Answer1_04();
                    }
                }
                PhotonNetwork.Destroy(photonView.gameObject);

         
             if(answer == 2)
            {
                if (photonView.gameObject.name == "02-1 Variant(Clone)" || photonView.gameObject.name == "02-2 Variant(Clone)" || photonView.gameObject.name == "02-3 Variant(Clone)" || photonView.gameObject.name == "02-4 Variant(Clone)")
                {
                    if (photonView.gameObject.name == "02-1 Variant(Clone)")
                    {
                        Answer2_01();
                    }
                    else if (photonView.gameObject.name == "02-2 Variant(Clone)")
                    {
                        Answer2_02();
                    }
                    else if (photonView.gameObject.name == "02-3 Variant(Clone)")
                    {
                        Answer2_03();
                    }
                    else if (photonView.gameObject.name == "02-4 Variant(Clone)")
                    {
                        Answer2_04();
                    }
                }
                PhotonNetwork.Destroy(photonView.gameObject);
            }
            else if (answer == 3)
            {
                if (photonView.gameObject.name == "03-1 Variant(Clone)" || photonView.gameObject.name == "03-2 Variant(Clone)" || photonView.gameObject.name == "03-3 Variant(Clone)" || photonView.gameObject.name == "03-4 Variant(Clone)")
                {
                    if (photonView.gameObject.name == "03-1 Variant(Clone)")
                    {
                        Answer3_01();
                    }
                    else if (photonView.gameObject.name == "03-2 Variant(Clone)")
                    {
                        Answer3_02();
                    }
                    else if (photonView.gameObject.name == "03-3 Variant(Clone)")
                    {
                        Answer3_03();
                    }
                    else if (photonView.gameObject.name == "03-4 Variant(Clone)")
                    {
                        Answer3_04();
                    }
                }
                PhotonNetwork.Destroy(photonView.gameObject);
            }
        }
    }

    
    //정답일때 이미지 위에 정답생성
    public void Answer1_01()
    {
        PhotonNetwork.Instantiate("01-1 Variant", a01, Quaternion.Euler(0,90,0));
    }
    public void Answer1_02()
    {
        PhotonNetwork.Instantiate("01-2 Variant", a02, Quaternion.Euler(0, 90, 0));
    }
    public void Answer1_03()
    {
        PhotonNetwork.Instantiate("01-3 Variant", a03, Quaternion.Euler(0, 90, 0));
    }
    public void Answer1_04()
    {
        PhotonNetwork.Instantiate("01-4 Variant", a04, Quaternion.Euler(0, 90, 0));
    }
    public void Answer2_01()
    {
        PhotonNetwork.Instantiate("02-1 Variant", a01, Quaternion.Euler(0, 90, 0));
    }
    public void Answer2_02()
    {
        PhotonNetwork.Instantiate("02-2 Variant", a02, Quaternion.Euler(0, 90, 0));
    }
    public void Answer2_03()
    {
        PhotonNetwork.Instantiate("02-3 Variant", a03, Quaternion.Euler(0, 90, 0));
    }
    public void Answer2_04()
    {
        PhotonNetwork.Instantiate("02-4 Variant", a04, Quaternion.Euler(0, 90, 0));
    }
    public void Answer3_01()
    {
        PhotonNetwork.Instantiate("03-1 Variant", a01, Quaternion.Euler(0, 90, 0));
    }
    public void Answer3_02()
    {
        PhotonNetwork.Instantiate("03-2 Variant", a02, Quaternion.Euler(0, 90, 0));
    }
    public void Answer3_03()
    {
        PhotonNetwork.Instantiate("03-3 Variant", a03, Quaternion.Euler(0, 90, 0));
    }
    public void Answer3_04()
    {
        PhotonNetwork.Instantiate("03-4 Variant", a04, Quaternion.Euler(0, 90, 0));
    }
}
