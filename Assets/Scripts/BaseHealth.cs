using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour
{
    [SerializeField] float baseLives = 3f;
    private float lives;
    private Text livesText;

    private void Start()
    {
        livesText = GetComponent<Text>();
        lives = baseLives - PlayerPrefsController.GetMasterDifficulty();
        Debug.Log("Difficulty setting currently is " + PlayerPrefsController.GetMasterDifficulty());
        UpdateHealth();
    }

    private void UpdateHealth()
    {
        livesText.text = lives.ToString();
    }

    public void GetHit()
    {
        lives -= 1f;
        UpdateHealth();

        if (lives <= 0f)
        {
            lives = 0f;
            FindObjectOfType<LevelController>().HandleLoseCondition();
        }
    }

}
