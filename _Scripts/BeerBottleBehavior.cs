using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerBottleBehavior : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] AudioClip[] _bottleAudio;




    // Start is called before the first frame update
    void Start()
    {
        _audioSource= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Player" && collision.gameObject.tag != "Zombie")
        {
            _audioSource.PlayOneShot(_bottleAudio[0]);

        }
        else
        {
        }
    }


}
