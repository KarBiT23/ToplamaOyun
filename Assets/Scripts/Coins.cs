using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public GameObject coinPrefab;      // Zümrüt prefab'ý
    public Vector2 spawnMin;           // Zümrütlerin oluþacaðý alanýn sol alt köþesi
    public Vector2 spawnMax;           // Zümrütlerin oluþacaðý alanýn sað üst köþesi

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Eðer çarpýlan nesne zümrütse
        if (collision.CompareTag("Coins"))
        {
            Destroy(collision.gameObject); // Sadece zümrüt yok olsun
            SpawnCoin();                   // Yeni zümrüt rastgele spawn olsun
        }
    }

    void SpawnCoin()
    {
        float x = Random.Range(spawnMin.x, spawnMax.x);
        float y = Random.Range(spawnMin.y, spawnMax.y);

        Instantiate(coinPrefab, new Vector3(x, y, 0), Quaternion.identity);
    }
}
