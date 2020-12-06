using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FirstFloor;
public class LedButtonScript_First : MonoBehaviour
{
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "GrabVolumeBig" || other.gameObject.name == "RightHandAnchor")
        {
            if (InstanceJikjiScript.G_GameCount == 0 && InstanceJikjiScript.StartGame)
            {
                InstanceJikjiScript.CreateJikji(InstanceJikjiScript.G_GameCount);
                InstanceJikjiScript.StartGame = false;
            }
            else
            {
                for (int i = 0; i < InstanceJikjiScript.RandomJikjies.Count; i++)
                {
                    InstanceJikjiScript.RandomJikjies[i].transform.position = InstanceJikjiScript.JikjisTag[i].transform.position;
                    InstanceJikjiScript.RandomJikjies[i].transform.rotation = Quaternion.Euler(0, -20, 0);
                }
            }
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

}
