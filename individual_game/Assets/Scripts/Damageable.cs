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

    private bool isMonsterDead = false;

    private Animator animator; // �ִϸ����� ������Ʈ

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

        // �ִϸ����� ������Ʈ ��������
        animator = GetComponent<Animator>();
    }

    public void ApplyDamage(float damage)
    {
        if (_currentHealth <= 0) return;

        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            isMonsterDead = true;
            Destruct();
        }
    }

    private void Destruct()
    {
        // "Die" �ִϸ��̼��� ���
        animator.SetBool("Die", true);

        // ���� �ð� �� ���� ����
        StartCoroutine(DestroyAfterAnimation());
    }

    private IEnumerator DestroyAfterAnimation()
    {
        // �ִϸ��̼� ���̸� ��ٸ� �� ���� ����
        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0).Length);
        Destroy(gameObject);
    }

    private void Update()
    {
        if (isMonsterDead)
        {
            // ���Ͱ� �׾��� �� "Die" �ִϸ��̼� ����
            animator.SetBool("Die", true);
            animator.SetBool("Run", false); // ���� �ߴ�
        }
        else
        {
            if (navMeshAgent && playerTransform)
            {
                // ���Ͱ� ��� �ְ� �÷��̾ ��� ������ "Run" �ִϸ��̼� ����
                navMeshAgent.SetDestination(playerTransform.position);
                animator.SetBool("Die", false);
                animator.SetBool("Run", true);
            }
        }
    }
}