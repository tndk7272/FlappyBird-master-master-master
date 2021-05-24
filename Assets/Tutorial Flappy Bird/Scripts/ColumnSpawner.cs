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
        // 3�� �������� ��ġ. >> �ڷ�ƾ
        // ��ġ �Ҷ� y���� ����.
        // ������Ű�� x���� ����.

        while (true) // >>> ���ѹݺ�
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
