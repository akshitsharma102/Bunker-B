using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using Enemy;

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
        public AudioSource[] A_s;
        public int ammo;
        int temp;
        int virtualammo;
        public int MaxAmmo;
        public int temp2;
        public Animator anim;
        public float timetoreload = 2f;
        void Start()
        {
            temp = ammo;
            virtualammo = ammo;
        }


        void Update()
        {
            
            if (MaxAmmo > 0)
            {
                if (ammo > 0)
                {
                    if (Input.GetButton("Fire1") && Time.time >= nextToFire)
                    {
                        nextToFire = Time.time + 1f / fireRate;
                        Shoot();
                        A_s[0].Play();
                    }
                }
                else if (ammo == 0 && virtualammo != ammo)
                {
                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        Reload();
                        anim.SetBool("reloading", true);
                    }

                }
            }
            else if(MaxAmmo <= 0)
            {
                Debug.Log("Find some ammo!");
            }
            
            if(ammo > 0 && virtualammo != ammo)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    anim.SetBool("reloading", true);
                    Reload();
                    
                }
            }

        }

        void Shoot()
        {
            
            ammo = ammo - 1;
            int st = -1 * (ammo - temp);
            int stored = st;
            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                

                EnemyComponent target = hit.transform.GetComponent<EnemyComponent>();
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
                temp2 = stored;
                
            }
        }
        void Reload()
        {
            ammo = temp;
            A_s[1].Play();
            MaxAmmo = MaxAmmo - temp2;
            temp2 = 0;
            anim.SetBool("reloading", false);
        }
        
    }
}
