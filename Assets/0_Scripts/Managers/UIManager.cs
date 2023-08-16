using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private Image healthIcon; // Maskable, Image Type: Filled

    private bool isPaused = false;

    private void Update()
    {
        // Toggle pause when the "Pause" key is pressed (e.g., ESC key)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            pauseScreen.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            pauseScreen.SetActive(false);
        }
    }

    private void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

    public void UpdateHealth(int currentHealth, int maxHealth)
    {
        healthText.text = currentHealth + " / " + maxHealth;
        healthIcon.fillAmount = currentHealth / maxHealth;
    }
}
