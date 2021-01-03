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
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float timeBetweenShots;

    bool canShoot = true;

    Animator animator;

    private void Start()
    {
       animator = GetComponent<Animator>();

    }

    private void OnEnable()
    {
        StartCoroutine(CoolWeapon());
    }


    void Update()
    {
        HandleMovement();
        HandleSight();
        if (Input.GetButtonDown("Fire") && ammoSlot.GetCurrentAmmo(ammoType) > 0 && canShoot)
        {
            StartCoroutine(Shoot());
        }
        else
        {
            animator.SetInteger("Fire", -1);
        }

    }

 
    IEnumerator Shoot()
    {
        canShoot = false;
        HandleVfx();
        ProcessRaycast();
        ammoSlot.ReduceCurrentAmmo(ammoType);
        animator.SetInteger("Fire", 2);
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    IEnumerator CoolWeapon()
    {
        if (!canShoot)
        {
            yield return new WaitForSeconds(timeBetweenShots);
            canShoot = true;
        }
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
        print("vfx play bitchhh");
    }

    private void HandleMovement()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            animator.SetInteger("Movement", 1);
        }
        else
        {
            animator.SetInteger("Movement", 0);
        }

        if (Input.GetButton("Run"))
        {
            animator.SetInteger("Movement", 2);
        }
    }

    private void HandleSight()
    {
       if (Input.GetButton("Zoom"))
        {
            animator.SetBool("Sight", true);
            //animator.SetInteger("Movement", 0);
        }
       else
        {
            animator.SetBool("Sight", false);

        }
    }



}
