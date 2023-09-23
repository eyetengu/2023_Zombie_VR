using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouth : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>(); 
    }



    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Food")
        {
            _playerHealth.AddHealth(5);
            _audioSource.PlayOneShot(_audioClip);
        }
        if (other.tag == "Drink")
        {
            _playerHealth.AddHealth(3);
            _audioSource.PlayOneShot(_audioClip);
        }
    }

}
