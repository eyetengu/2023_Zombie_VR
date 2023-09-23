using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy_BasicBehavior_V2 : MonoBehaviour
{
    [SerializeField] private GameObject _standardCharacterModel, _zombieCharacterModel;
    [SerializeField] private Transform _target;
    [SerializeField] private Animator _npcAnimator, _zombieAnimator;

    [SerializeField] private float _speed;
    private bool _isInfected;
    private AudioSource _zombieAudioSource;

    void Start()
    {

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            _isInfected = !_isInfected;

            if(_isInfected)
            {
                InfectCharacter();
            }
            else
            {
                CureCharacter();
            }
        }


        AvoidPlayer();
    }

    private void AvoidPlayer()
    {
        MoveAwayFromPlayer();
        TurnAwayFromPlayer();
    }

    //ENEMY MOVEMENT
    private void MoveAwayFromPlayer()
    {
        var step = _speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _target.position, -step);
    }
    
    private void TurnAwayFromPlayer()
    {
        Vector3 targetDirection = _target.position - transform.position;
        float singleStep = -_speed * Time.deltaTime;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        Debug.DrawRay(transform.position, newDirection, Color.red);

        transform.rotation = Quaternion.LookRotation(newDirection);
    }


    
    //NPC STATUS
    private void InfectCharacter()
    {
        _npcAnimator.SetBool("Spasming", true);

        //play animation of epilepsy or similar reactions
        //play appropriate audio
        StartCoroutine(ZombieTurningRate());
    }

    private void CureCharacter()
    {
        _standardCharacterModel.SetActive(true);
        _zombieCharacterModel.SetActive(false);
    }


    //COROUTINES
    IEnumerator ZombieTurningRate()
    {
        yield return new WaitForSeconds(5);
        
        ZombieTakesControl();
    }

    private void ZombieTakesControl()
    {
        //play zombie standup animation
        //_npcAnimator.SetBool("Spasming", false);
        //play zombie roar/growl/snarl/or other as appropriate
        //_audioSource.PlayOneShot(_zombieAudio[1]);

        //Switch Characters
        _standardCharacterModel.SetActive(false);
        _zombieCharacterModel.SetActive(true);        
    }
}
