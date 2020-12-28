using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;

    [SerializeField] ParticleSystem flashEfx;

    [SerializeField] Transform ParticleParenTransform;

    [SerializeField] GameObject hitEffect;
    


    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        HandleVfx();
        ProcessRaycast();

    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null)  return; 
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        var vfx = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(vfx, 0.5f);

    }

    private void HandleVfx()
    {
        flashEfx.Play();
    }
}
