using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;
using UnityEngine.UI;

public class NetworkPlayer : MonoBehaviour
{

    public Transform Head;
    public Transform LHand;
    public Transform RHand;

    public Animator leftHandAnimator;
    public Animator rightHandAnimator;

    private Transform headRig;
    private Transform LHandRig;
    private Transform RHandRig;
    
    private PhotonView photonView;


    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        OVRCameraRig rig = FindObjectOfType<OVRCameraRig>();
        headRig = rig.transform.Find("TrackingSpace/CenterEyeAnchor");
        LHandRig = rig.transform.Find("TrackingSpace/LeftHandAnchor");
        RHandRig = rig.transform.Find("TrackingSpace/RightHandAnchor");

        if (photonView.IsMine)
        {
            foreach (var item in GetComponentsInChildren<Renderer>())
            {
                item.enabled = false;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            RHand.gameObject.SetActive(false);
            LHand.gameObject.SetActive(false);
            Head.gameObject.SetActive(false);

            MapPosition(Head, headRig);
            MapPosition(LHand, LHandRig);
            MapPosition(RHand, RHandRig);

            UpdateHandAnim(InputDevices.GetDeviceAtXRNode(XRNode.LeftHand), leftHandAnimator);
            UpdateHandAnim(InputDevices.GetDeviceAtXRNode(XRNode.RightHand), rightHandAnimator);
        }
    }

    void UpdateHandAnim(InputDevice targetDevice, Animator handAnimator)
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Flex", triggerValue);
        }
        else 
        {
            handAnimator.SetFloat("Flex", 0);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Pinch", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Pinch", 0);
        }

    }

    void MapPosition(Transform target,Transform rigTransform) 
    { 
        target.position = rigTransform.position;
        target.rotation = rigTransform.rotation;
    }
}
