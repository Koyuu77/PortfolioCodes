using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkGrabber : OVRGrabber
{
    private PhotonView photonView;
    // Start is called before the first frame update
    new void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    new void Update()
    {
        
    }

    protected override void GrabBegin()
    {
        photonView.RequestOwnership();
        base.GrabBegin();
    }
}
