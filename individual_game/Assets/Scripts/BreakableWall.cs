using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreakableWall : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f; // 최대 체력
    private float currentHealth; // 현재 체력

    private bool isBroken = false; // 벽이 이미 부서졌는지 여부

    public Slider hpBar; // BreakableWallUI 스크립트에서 Slider를 할당할 변수

    private void Start()
    {
        currentHealth = maxHealth;
    }

    // 벽 부수기
    public void BreakWall(float damage)
    {
        if (!isBroken)
        {
            // 데미지를 현재 체력에서 빼기
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                // 벽 부수기
                isBroken = true;

                // 벽 제거
                Destroy(gameObject);

                // HP UI를 숨김 (Alpha를 0으로 설정)
                UpdateWallHealth(0, maxHealth);
            }
            else
            {
                // 아직 남은 경우 HP UI를 표시 (Alpha를 1로 설정)
                UpdateWallHealth(currentHealth, maxHealth);
            }
        }
    }

    // 벽의 체력을 업데이트하는 메서드  //업데이트를 해줘야 HP ui가 인식하고 피가 감소하나봐요
    public void UpdateWallHealth(float currentHealth, float maxHealth)
    {
        if (hpBar != null)
        {
            // 벽의 체력을 최대 체력에 대한 비율로 설정하여 Slider를 업데이트
            hpBar.value = currentHealth / maxHealth;
        }
    }
}