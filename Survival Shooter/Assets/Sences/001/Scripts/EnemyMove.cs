using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private Transform _player;
    private Animator _animator;
    void Awake()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        _animator = this.GetComponent<Animator>();
    }

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag(Tags.player).transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, _player.position) < 1.45f)
        {
            _navMeshAgent.Stop();
            _animator.SetBool("Move", false);
        }
        else
        {
            _navMeshAgent.Resume();
            _navMeshAgent.SetDestination(_player.position);
            _animator.SetBool("Move", true);
        }
    }
}
