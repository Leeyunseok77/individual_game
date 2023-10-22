using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    // 몬스터가 출현할 위치를 저장할 List 타입 변수
    public List<Transform> points = new List<Transform>();
    // 몬스터 프리팹을 연결할 변수
    public GameObject monster;
    // 몬스터의 생성 간격
    public float createTime = 3.0f;
    // 게임의 종료 여부를 저장할 멤버 변수
    private bool isGameOver;
    // 게임의 종료 여부를 저장할 프로퍼티
    public bool IsGameOver
    {
        get { return isGameOver; }
        set
        {
            isGameOver = value;
            if (isGameOver)
            {
                CancelInvoke("CreateMonster");
            }
        }

    }

    public GameObject monster1Prefab; // 첫 번째 몬스터 프리팹
    public GameObject monster2Prefab; // 두 번째 몬스터 프리팹
    public GameObject monster3Prefab; // 세 번째 몬스터 프리팹

    // 싱글턴 인스턴스 선언
    public static GameManager instance = null;

    // 스크립트가 실행되면 가장 먼저 호출되는 유니티 이벤트 함수
    void Awake()
    {
        // instance가 할당되지 않았을 경우
        if (instance == null)
        {
            instance = this;
        }
        // instance에 할당된 클래스의 인스턴스가 다를 경우 새로 생성된 클래스를 의미함
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        // 다른 씬으로 넘어가더라도 삭제하지 않고 유지함
       // DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        // SpawnPointGroup 게임오브젝트의 Transform 컴포넌트 추출
        Transform spawnPointGroup = GameObject.Find("SpawnPointGroup")?.transform;
        // SpawnPointGroup 하위에 있는 모든 차일드 게임오브젝트의 Transform 컴포넌트 추출
        foreach (Transform point in spawnPointGroup)
        {
            points.Add(point);
        }
        // 일정한 시간 간격으로 함수를 호출
        InvokeRepeating("CreateMonster", 2.0f, createTime);
    }

    void CreateMonster()
    {
        int monsterType = Random.Range(1, 4); // 1, 2, 3 중 하나를 무작위로 선택

        GameObject monsterPrefab;

        if (monsterType == 1)
        {
            monsterPrefab = monster1Prefab;
        }
        else if (monsterType == 2)
        {
            monsterPrefab = monster2Prefab;
        }
        else
        {
            monsterPrefab = monster3Prefab;
        }

        int idx = Random.Range(0, points.Count);
        Instantiate(monsterPrefab, points[idx].position, points[idx].rotation);
    }
}
