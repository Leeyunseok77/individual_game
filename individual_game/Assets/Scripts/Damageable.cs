using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Damageable : MonoBehaviour
{
    [SerializeField] private float _initialHealth;
    private float _currentHealth;

    private NavMeshAgent navMeshAgent;
    private Transform playerTransform;

    private void Awake()
    {
        _currentHealth = _initialHealth;

        // NavMeshAgent 컴포넌트 가져오기
        navMeshAgent = GetComponent<NavMeshAgent>();

        // 플레이어 오브젝트 또는 플레이어 트랜스폼 가져오기
        playerTransform = GameObject.FindWithTag("Player").transform;

        // NavMeshAgent의 목표를 플레이어로 설정
        if (navMeshAgent && playerTransform)
        {
            navMeshAgent.SetDestination(playerTransform.position);
        }
    }

    public void ApplyDamage(float damage)
    {
        if (_currentHealth <= 0) return;

        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            Destruct();
        }
    }

    private void Destruct()
    {
        Destroy(gameObject);
    }
}