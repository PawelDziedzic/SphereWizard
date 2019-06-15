using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerScript : MonoBehaviour
{
    protected GameObject sentOrb, orbInside;
    public int natureOfOrb;//0 fire, 1 lightning, 2 nothing

    void OnEnable()
    {
        if (natureOfOrb == 0)
        {
            orbInside = Instantiate(OrbManagerScript.getProviderStationaryF(), transform.position + Vector3.up, Quaternion.identity);
            orbInside.transform.SetParent(gameObject.transform);
        }
        else if (natureOfOrb == 1)
        {
            orbInside = Instantiate(OrbManagerScript.getProviderStationaryL(), transform.position + Vector3.up, Quaternion.identity);
            orbInside.transform.SetParent(gameObject.transform);
        }
    }


    void Send()
    {
        switch (natureOfOrb) {
            case 0: 
                sentOrb = Instantiate(OrbManagerScript.getProviderSentF(), transform.position + Vector3.up, Quaternion.identity);
                SetFree();  break;
            case 1:
                sentOrb = Instantiate(OrbManagerScript.getProviderSentL(), transform.position + Vector3.up, Quaternion.identity);
                SetFree(); break;
            default:
                break;
        }
    }

    void SetFree()
    {
        natureOfOrb = 10;
        orbInside.SendMessage("RemoveSelf");
    }

    void GetOrbed(int nature)
    {
        if (natureOfOrb == 10)
        {   //Send();
            natureOfOrb = nature;
            switch (natureOfOrb)
            {
                case 0:
                    orbInside = Instantiate(OrbManagerScript.getProviderStationaryF(),
                transform.position + Vector3.up, Quaternion.identity); break;
                case 1:
                    orbInside = Instantiate(OrbManagerScript.getProviderStationaryL(),
                transform.position + Vector3.up, Quaternion.identity); break;
                default:
                    orbInside = Instantiate(OrbManagerScript.getProviderStationaryF(),
               transform.position + Vector3.up, Quaternion.identity); break;
            }
            orbInside.transform.SetParent(gameObject.transform);
        }
    }
}
