using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmmitPS : MonoBehaviour
{
    public ParticleSystem mf;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(mf, transform.position, transform.rotation);
        }
    }
}
