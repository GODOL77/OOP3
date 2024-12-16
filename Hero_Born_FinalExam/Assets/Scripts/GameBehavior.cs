using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameBehavior : MonoBehaviour
{
    private int _enemiesLeft = 10;
    private int _playerHP = 10;
    public int _bullets = 30;
    public int _money = 0;
    public TMP_Text HealthText;
    public TMP_Text ItemText;
    public TMP_Text BulletsText;
    public TMP_Text ProgressText;
    public TMP_Text MoneyText;
    public Button WinButton;
    public Button LossButton;

    public int Enemies
    {
        get { return _enemiesLeft; }

        set
        {
            _enemiesLeft = value;
            ItemText.text = "Enemies : " + Enemies;
            if (_enemiesLeft == 0)
            {
                ProgressText.text = "You've found all the items!";
                WinButton.gameObject.SetActive(true);
                Time.timeScale = 0f;
                UpdateScene("You've kill all the enemies!");
            }
            Debug.LogFormat("Items : {0}", _enemiesLeft);
        }
    }

    public int HP
    {
        get { return _playerHP; }

        set
        {
            _playerHP = value;
            HealthText.text = "Health : " + HP;

            if (_playerHP <= 0)
            {
                ProgressText.text = "You want another life with that?";
                LossButton.gameObject.SetActive(true);
                UpdateScene("You want another life with that?");
                Time.timeScale = 0;
            }
            else
            {
                ProgressText.text = "Ouch... that's got hurt.";
            }
            Debug.LogFormat("Lives : {0}", _playerHP);
        }
    }

    public int Bullets
    {
        get { return _bullets; }

        set
        {
            _bullets = value;
            BulletsText.text = "Bullets : " + Bullets;
        }
    }

    public int Money
    {
        get { return _money; }

        set
        {
            _money = value;
            MoneyText.text = "Money : " + Money;
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void UpdateScene(string updatedText)
    {
        ProgressText. text = updatedText;
        Time.timeScale = 0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        ItemText.text += _enemiesLeft;
        HealthText.text += _playerHP;
        BulletsText.text += _bullets;
        MoneyText.text += _money;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
