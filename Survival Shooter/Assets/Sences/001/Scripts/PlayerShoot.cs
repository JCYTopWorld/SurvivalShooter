using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float ShootRate = 2;
    private float Timer = 0;
    private ParticleSystem _particleSystem;
    private LineRenderer _lineRenderer;
    public float Attack = 30;
    void Start()
    {
        _particleSystem = this.GetComponentInChildren<ParticleSystem>();
        _lineRenderer = this.GetComponentInChildren<LineRenderer>();
    }

    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > 1 / ShootRate)
        {
            Timer -= 1 / ShootRate;
            Shoot();
        }
    }

    private void Shoot()
    {
        _particleSystem.Play();
        this.GetComponent<Light>().enabled = true;
        this._lineRenderer.enabled = true;
        _lineRenderer.SetPosition(0, transform.position);
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            _lineRenderer.SetPosition(1, hitInfo.point);
            //判断当前的设计有没有碰撞到敌人
            if (hitInfo.collider.tag == Tags.enemy)
            {
                hitInfo.collider.GetComponent<EnemyHealth>().TakeDamage(Attack, hitInfo.point);
            }
        }
        else
        {
            _lineRenderer.SetPosition(1, transform.position + transform.forward * 100);
        }
        this.GetComponent<AudioSource>().Play();
        Invoke("ClearEffect", 0.05f);
    }

    void ClearEffect()
    {
        this.GetComponent<Light>().enabled = false;
        this.GetComponent<LineRenderer>().enabled = false;
    }
}
