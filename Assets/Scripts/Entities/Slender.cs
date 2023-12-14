using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Slender : MonoBehaviour
{
    #region PRIVATE_FIELDS
    private Transform _target;
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private Animator _transition;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _static;
    [SerializeField] private float _caughtDistance;
    [SerializeField] private float _staticDistance;
    [SerializeField, Range(0f, 1f)] private float _chaseProbability;
    [SerializeField] private float _teleportDistance;
    [SerializeField] private float _teleportCooldown;
    [SerializeField] private float _returnCooldown;
    [SerializeField] private Cinemachine.CinemachineVirtualCamera _playerCamera;
    private MenuManager _menuManager;
    private bool _isCaught = false;
    private Vector3 _basePos;
    private float _teleportTimer;
    private bool _isReturning;
    #endregion

    #region UNITY_METHODS
    private void Awake()
    {
        _basePos = transform.position;
        _teleportTimer = _teleportCooldown;
        _target = GameObject.FindGameObjectWithTag("Player").transform;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.speed = _speed;
        _animator = GetComponent<Animator>();
        if(_static != null)
        {
            _static.SetActive(false);
        }
    }

    private void Start()
    {
        _menuManager = GetComponent<MenuManager>();
    }

    IEnumerator LoadGameOver()
    {
        yield return new WaitForSeconds(2.5f);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _transition.SetTrigger("start");
        yield return new WaitForSeconds(1f);
        _menuManager.LoadLoseGameScene();
    }

    private void Update()
    {
        if (_isCaught) return;
        _animator.SetBool("isFollowing", true);
        _teleportTimer -= Time.deltaTime;
        if(_teleportTimer <= 0f)
        {
            if(_isReturning)
            {
                transform.position = _basePos;
                _teleportTimer = _teleportCooldown;
                _isReturning = false;
            } else
            {
                float random = Random.value;
                if(random < _chaseProbability)
                {
                    Vector3 randomPos = Random.insideUnitSphere * _teleportDistance;
                    randomPos.y = transform.position.y;
                    transform.position = _target.position + randomPos;
                    _audioManager.ChangePlayerAudio(_audioClip);
                } else
                {
                    _isReturning = true;
                    _teleportTimer = _returnCooldown;
                }
                _teleportTimer = _teleportCooldown;
            }
        }
        float distance = Vector3.Distance(transform.position, _target.position);
        if (distance < _caughtDistance)
        {
            _animator.SetBool("isCaught", true);
            _animator.SetBool("isFollowing", false);
            _navMeshAgent.isStopped = true;
            _isCaught = true;
            _static.SetActive(false);
            _playerCamera.enabled = false;
            StartCoroutine(LoadGameOver());
        }
        else
        {
            _navMeshAgent.SetDestination(_target.position);
            if (distance < _staticDistance)
            {
                _static.SetActive(true);
            }  else
            {
                _static.SetActive(false);
            }
        }
        
    }
    #endregion
}
