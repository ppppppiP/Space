using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] int _playerHP;

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
        if(_playerHP <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
