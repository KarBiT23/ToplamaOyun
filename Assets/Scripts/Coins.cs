using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public GameObject coinPrefab;      // Z�mr�t prefab'�
    public Vector2 spawnMin;           // Z�mr�tlerin olu�aca�� alan�n sol alt k��esi
    public Vector2 spawnMax;           // Z�mr�tlerin olu�aca�� alan�n sa� �st k��esi

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // E�er �arp�lan nesne z�mr�tse
        if (collision.CompareTag("Coins"))
        {
            Destroy(collision.gameObject); // Sadece z�mr�t yok olsun
            SpawnCoin();                   // Yeni z�mr�t rastgele spawn olsun
        }
    }

    void SpawnCoin()
    {
        float x = Random.Range(spawnMin.x, spawnMax.x);
        float y = Random.Range(spawnMin.y, spawnMax.y);

        Instantiate(coinPrefab, new Vector3(x, y, 0), Quaternion.identity);
    }
}
