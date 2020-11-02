using enemy;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace player
{
    public class Gun : MonoBehaviour
    {
        public float damage = 10f;
        public float range = 100f;
        public Camera fpsCam;
        public ParticleSystem ps;
        public ParticleSystem ps2;
        public float iforce = 10f;
        public float fireRate = 15f;
        private float nextToFire = 0f;
        public AudioSource A_s;
        
        void Start()
        {
           
        }


        void Update()
        {
            
            if (Input.GetButton("Fire1") && Time.time >= nextToFire)
            {
                nextToFire = Time.time + 1f / fireRate;
                Shoot();
                A_s.Play();
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
                    Instantiate(ps, hit.point, Quaternion.LookRotation(hit.normal));
                    Instantiate(ps2, hit.point, Quaternion.LookRotation(hit.normal));
                    target.TakeDamage(damage);
                }
                else if(target == null)
                {
                    Instantiate(ps2, hit.point, Quaternion.LookRotation(hit.normal));
                }
                if(hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * iforce);   
                }
            }
        }
        
    }
}
