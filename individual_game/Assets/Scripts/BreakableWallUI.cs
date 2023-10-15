using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreakableWallUI : MonoBehaviour
{
    [SerializeField] private Slider hpBar;

    // Start is called before the first frame update
    void Start()
    {
        // 초기화 코드를 여기에 작성할 수 있습니다.
    }

    // Update is called once per frame
    void Update()
    {
        // 매 프레임마다 업데이트 코드를 작성할 수 있습니다.
    }

    // 벽의 체력을 업데이트하는 메서드
    public void UpdateWallHealth(float currentHealth, float maxHealth)
    {
        if (hpBar != null)
        {
            // 벽의 체력을 최대 체력에 대한 비율로 설정하여 Slider를 업데이트
            hpBar.value = currentHealth / maxHealth;
        }
    }
}