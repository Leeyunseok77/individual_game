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

    private Animator animator; // 애니메이터 컴포넌트

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

        // 애니메이터 컴포넌트 가져오기
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
        // "Die" 애니메이션을 재생
        animator.SetBool("Die", true);

        // 일정 시간 후 몬스터 제거
        StartCoroutine(DestroyAfterAnimation());
    }

    private IEnumerator DestroyAfterAnimation()
    {
        // 애니메이션 길이를 기다린 후 몬스터 제거
        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0).Length);
        Destroy(gameObject);
    }

    private void Update()
    {
        if (isMonsterDead)
        {
            // 몬스터가 죽었을 때 "Die" 애니메이션 실행
            animator.SetBool("Die", true);
            animator.SetBool("Run", false); // 추적 중단
        }
        else
        {
            if (navMeshAgent && playerTransform)
            {
                // 몬스터가 살아 있고 플레이어가 살아 있으면 "Run" 애니메이션 실행
                navMeshAgent.SetDestination(playerTransform.position);
                animator.SetBool("Die", false);
                animator.SetBool("Run", true);
            }
        }
    }
}