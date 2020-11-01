using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponSwitch : MonoBehaviour
{
    
    public GameObject[] guns;
    public int weponnumber = 0;
    private int curwepon;
    
    void Start()
    {
        
    }

    
    void Update()
    {
            if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                weponnumber = weponnumber + 1;
            if(weponnumber == 5)
            {
                weponnumber = 0;
            }
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                weponnumber = weponnumber - 1;
            if (weponnumber == -5)
            {
                weponnumber = 0;
            }
        }
        if (weponnumber == 0)
        {
            guns[0].SetActive(true);
            guns[1].SetActive(false);
            guns[2].SetActive(false);
            guns[3].SetActive(false);
        }
        else if (weponnumber == 1 || weponnumber == -1)
        {
            guns[0].SetActive(false);
            guns[1].SetActive(true);
            guns[2].SetActive(false);
            guns[3].SetActive(false);
        }
        else if (weponnumber == 2 || weponnumber == -2)
        {
            guns[0].SetActive(false);
            guns[1].SetActive(false);
            guns[2].SetActive(true);
            guns[3].SetActive(false);
        }
        else if (weponnumber == 3 || weponnumber == -3)
        {
            guns[0].SetActive(false);
            guns[1].SetActive(false);
            guns[2].SetActive(false);
            guns[3].SetActive(true);
        }

    }
}
