using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGames : MonoBehaviour
{
    // ✅ Oyunu yeniden başlat
    public void RestartGame()
    {
        Time.timeScale = 1; // Oyun hızını normale döndür
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // ✅ Oyunu kapat
    public void QuitGame()
    {
        Debug.Log("Oyun kapatıldı!");
        Application.Quit();
    }
}
