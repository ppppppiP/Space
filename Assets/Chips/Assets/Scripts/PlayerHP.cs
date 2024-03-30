using DG.Tweening;
using Lean.Pool;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    Tween _tween;
    [SerializeField] int _playerHP;
    [SerializeField] TextMeshProUGUI _playerHPText;
    [SerializeField] GameObject _VFX;
    [SerializeField] GameObject _playerHPUI;
    [SerializeField] GameObject _loseMenu;

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
        LeanPool.Spawn(_VFX, transform.position + Vector3.up * 2, Quaternion.identity);
        _tween = _playerHPUI.transform.DOShakePosition(0.5f, 10, 20, 90);
        _playerHPText.text = _playerHP.ToString();
        if(_playerHP <= 0)
        {
            _loseMenu.SetActive(true);
        }
    }
}
