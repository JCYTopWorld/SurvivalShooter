using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float Hp = 100;
    private Animator _animator;
    private NavMeshAgent _navMeshAgent;
    private EnemyMove _enemyMove;
    private CapsuleCollider _capsuleCollider;
    public AudioClip DeadAudioClip;
    private ParticleSystem _particleSystem;

    void Awake()
    {
        _animator = this.GetComponent<Animator>();
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        _enemyMove = this.GetComponent<EnemyMove>();
        _capsuleCollider = this.GetComponent<CapsuleCollider>();
        _particleSystem = this.GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        if (this.Hp <= 0)
        {
            transform.Translate(Vector3.down * Time.deltaTime * 0.6f);
            if (transform.position.y <= -5)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void TakeDamage(float damage, Vector3 hitPoint)
    {
        if (this.Hp <= 0) return;
        this.Hp -= damage;
        this.GetComponent<AudioSource>().Play();
        _particleSystem.transform.position = hitPoint;
        _particleSystem.Play();
        if (this.Hp <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        AudioSource.PlayClipAtPoint(DeadAudioClip, transform.position);
        _animator.SetBool("Dead", true);
        _navMeshAgent.enabled = false;
        _enemyMove.enabled = false;
        _capsuleCollider.enabled = false;
    }
}
