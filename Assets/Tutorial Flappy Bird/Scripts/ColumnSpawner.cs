using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnSpawner : MonoBehaviour
{
    public GameObject column;
    public float delay = 3f;
    public float randomDelay = 3f;
    public float spawnX = 4;
    public float spawnYmin = -2;
    public float spawnYmax = 1;

    IEnumerator Start()
    {
        // 3초 간격으로 배치. >> 코루틴
        // 배치 할때 y값은 랜덤.
        // 스폰시키는 x값은 고정.

        while (true) // >>> 무한반복
        {
            Vector3 pos;
            pos.z = 0;
            pos.x = spawnX;
            pos.y = Random.Range(spawnYmin, spawnYmax);
Instantiate(column, pos, column.transform.rotation);

            yield return new WaitForSeconds(delay + Random.Range(-randomDelay, randomDelay));
        }
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
