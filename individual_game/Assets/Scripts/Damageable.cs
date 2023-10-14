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

        // NavMeshAgent ������Ʈ ��������
        navMeshAgent = GetComponent<NavMeshAgent>();

        // �÷��̾� ������Ʈ �Ǵ� �÷��̾� Ʈ������ ��������
        playerTransform = GameObject.FindWithTag("Player").transform;

        // NavMeshAgent�� ��ǥ�� �÷��̾�� ����
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