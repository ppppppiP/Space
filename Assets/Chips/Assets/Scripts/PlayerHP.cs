using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] int _playerHP;
    [SerializeField] TextMeshProUGUI _playerHPText;

    private void Start()
    {
        _playerHPText.text = _playerHP.ToString();
    }

    public void TakeDamage(int damage)
    {
        if(damage > _playerHP)
        {
            _playerHP = 0;
        }
        if(damage < 0)
        {
            return;
        }
        _playerHP -= damage;
        _playerHPText.text = _playerHP.ToString();
        if(_playerHP <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
