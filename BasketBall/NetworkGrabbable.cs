﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class NetworkGrabbable : OVRGrabbable
{
    private PhotonView photonView;
    // Start is called before the first frame update
    new void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        photonView.RequestOwnership();
        base.GrabBegin(hand, grabPoint);
    }
}
