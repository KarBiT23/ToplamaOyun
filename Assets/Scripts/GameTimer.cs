using UnityEngine;
using TMPro;                     // TextMeshPro için gerekli
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public float totalTime = 60f;      // Oyun süresi
    public TMP_Text timerText;         // TextMeshPro UI

    private float remainingTime;

    void Start()
    {
        remainingTime = totalTime;
    }

    void Update()
    {
        remainingTime -= Time.deltaTime;

        if (timerText != null)
        {
            timerText.text = "Süre: " + Mathf.Ceil(remainingTime).ToString();
        }

        if (remainingTime <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        Debug.Log("Oyun Bitti!");
        // Örnek: sahneyi yeniden baþlat
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Time.timeScale = 0; // Oyun durdurulabilir
    }
}
