using enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace player
{
    public class Gun : MonoBehaviour
    {
        public float damage = 10f;
        public float range = 100f;
        public Camera fpsCam;
        public ParticleSystem ps;
        public bool auto = false;

        void Start()
        {

        }


        void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }

        void Shoot()
        {
            
            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                

                Target target = hit.transform.GetComponent<Target>();
                if(target != null)
                {
                    Instantiate(ps, hit.transform.position, Quaternion.identity);
                    target.TakeDamage(damage);
                }
            }
        }
    }
}
