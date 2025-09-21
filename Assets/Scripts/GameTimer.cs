using UnityEngine;
using TMPro;                     // TextMeshPro i�in gerekli
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public float totalTime = 60f;      // Oyun s�resi
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
            timerText.text = "S�re: " + Mathf.Ceil(remainingTime).ToString();
        }

        if (remainingTime <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        Debug.Log("Oyun Bitti!");
        // �rnek: sahneyi yeniden ba�lat
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        Time.timeScale = 0; // Oyun durdurulabilir
    }
}
