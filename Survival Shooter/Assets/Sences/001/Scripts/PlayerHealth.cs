using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float Hp = 100;
    private Animator _anim;
    private PlayerMove _playerMove;
    private SkinnedMeshRenderer _skinnedMeshRenderer;
    public float Smoothing = 5;
    private PlayerShoot _playerShoot;
    void Awake()
    {
        _anim = this.GetComponent<Animator>();
        _playerMove = this.GetComponent<PlayerMove>();
        _skinnedMeshRenderer = this.transform.Find("Player").GetComponent<SkinnedMeshRenderer>();
        _playerShoot = this.GetComponentInChildren<PlayerShoot>();
    }

    void Update()
    {
        //if (Input.GetMouseButtonDown(1))
        //{
        //    TakeDamage(30);
        //}
        _skinnedMeshRenderer.material.color = Color.Lerp(_skinnedMeshRenderer.material.color, Color.white, Smoothing * Time.deltaTime);
    }

    public void TakeDamage(float damage)
    {
        if (Hp <= 0) return;
        this.Hp -= damage;
        _skinnedMeshRenderer.material.color = Color.red;
        if (this.Hp <= 0)
        {
            _anim.SetBool("Dead", true);
            Dead();
        }
    }

    void Dead()
    {
        this._playerMove.enabled = false;
        this._playerShoot.enabled = false;
    }
}
