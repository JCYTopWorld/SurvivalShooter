using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float Attack = 5;
    public float AttackTime = 1;
    private float Timer;
    private EnemyHealth _enemyHealth;

    void Awake()
    {
        _enemyHealth = this.GetComponent<EnemyHealth>();
    }

    void Start()
    {
        Timer = AttackTime;
    }

    public void OnTriggerStay(Collider collider)
    {
        if (collider.tag == Tags.player && _enemyHealth.Hp > 0)
        {
            Timer += Time.deltaTime;
            if (Timer >= AttackTime)
            {
                Timer -= AttackTime;
                collider.GetComponent<PlayerHealth>().TakeDamage(Attack);
            }
        }
    }
}
