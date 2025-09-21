using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class DCoins : MonoBehaviour
{
    [Header("Karakter")]
    public GameObject player;

    [Header("Zümrütler")]
    public GameObject normalCoinPrefab;
    public GameObject dangerousCoinPrefab;
    public Vector2 spawnMin;
    public Vector2 spawnMax;

    [Header("Oyun Süresi")]
    public float totalTime = 60f;
    public TMP_Text timerText;

    [Header("Skor ve Hedef")]
    public TMP_Text coinText;
    public int targetCoinCount = 25;

    [Header("UI Panelleri")]
    public GameObject winPanel;
    public GameObject losePanel;

    private float remainingTime;
    private int collectedCoins = 0;
    private bool gameEnded = false;

    void Start()
    {
        remainingTime = totalTime;

        SpawnCoin(normalCoinPrefab);

        StartCoroutine(SpawnDangerousCoins());

        UpdateCoinText();

        if (winPanel != null) winPanel.SetActive(false);
        if (losePanel != null) losePanel.SetActive(false);

        Time.timeScale = 1; // Sahne yeniden başladığında oyun devam etsin
    }

    void Update()
    {
        if (gameEnded) return;

        remainingTime -= Time.deltaTime;

        if (timerText != null)
            timerText.text = "Süre: " + Mathf.Ceil(remainingTime).ToString();

        if (remainingTime <= 0)
            EndGame("Süre doldu!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameEnded) return;

        if (collision.CompareTag("Coins"))
        {
            Destroy(collision.gameObject);
            collectedCoins++;
            SpawnCoin(normalCoinPrefab);

            UpdateCoinText();

            if (collectedCoins >= targetCoinCount)
                WinGame();
        }
        else if (collision.CompareTag("Dangerius"))
        {
            EndGame("Tehlikeli zümrüte değdin!");
        }
    }

    void SpawnCoin(GameObject coinPrefab)
    {
        float x = Random.Range(spawnMin.x, spawnMax.x);
        float y = Random.Range(spawnMin.y, spawnMax.y);

        Instantiate(coinPrefab, new Vector3(x, y, 0), Quaternion.identity);
    }

    IEnumerator SpawnDangerousCoins()
    {
        while (!gameEnded)
        {
            yield return new WaitForSeconds(5f);
            SpawnCoin(dangerousCoinPrefab);
        }
    }

    void EndGame(string message)
    {
        if (gameEnded) return;
        gameEnded = true;

        Debug.Log(message);
        Time.timeScale = 0;

        if (losePanel != null) losePanel.SetActive(true);
    }

    void WinGame()
    {
        if (gameEnded) return;
        gameEnded = true;

        Debug.Log("Tebrikler! 25 zümrüt topladın, kazandın!");
        Time.timeScale = 0;

        if (winPanel != null) winPanel.SetActive(true);
    }

    void UpdateCoinText()
    {
        if (coinText != null)
            coinText.text = $":{collectedCoins} / {targetCoinCount}";
    }

}
