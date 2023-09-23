using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    private int _maxHealth = 100;
    private int _health;

    [SerializeField] private Slider _healthBar;





    void Start()
    {
        _healthBar.maxValue= _maxHealth;
        _health = _maxHealth;   
        _healthBar.value = _health;
    }


    void Update()
    {
        
    }

    public void AddHealth(int health)
    {
        _health += health;
        _healthBar.value = _health;
    }

    public void TakeDamage(int damageReceived)
    {
        _health -= damageReceived;
        _healthBar.value = _health;

        if(_health < 1)
        {
            PlayerIsDead();
        }
    }

    private void PlayerIsDead()
    {
        _gameManager.GameOver();
    }

}
