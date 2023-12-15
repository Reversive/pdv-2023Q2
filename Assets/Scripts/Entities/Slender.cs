using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Slender : MonoBehaviour
{
    #region PRIVATE_FIELDS
    private Transform _target;
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;

    [SerializeField] private float spawnEffectTime = 2;
    [SerializeField] private float pause = 1;
    [SerializeField] private AnimationCurve fadeIn;
    [SerializeField] private GameObject _materialGameObject;

    int shaderProperty;
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
    private float timer = 0;
    private Renderer _renderer;
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
        shaderProperty = Shader.PropertyToID("_cutoff");
        _renderer = _materialGameObject.GetComponent<Renderer>();
    }

    private bool shouldTeleport = false;
    private bool isFadeOver = false;
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

        if (shouldTeleport)
        {
            if (timer < spawnEffectTime + pause)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0;
                shouldTeleport = false;
                isFadeOver = true;
            }
            
            _renderer.materials.ToList().ForEach(m => m.SetFloat(shaderProperty, fadeIn.Evaluate(Mathf.InverseLerp(0, spawnEffectTime, timer))));

            if (isFadeOver && !_isReturning)
            {
                Vector3 randomPos = Random.insideUnitSphere * _teleportDistance;
                randomPos.y = transform.position.y;
                transform.position = _target.position + randomPos;
                isFadeOver = false;
            } else if (isFadeOver && _isReturning)
            {
                transform.position = _basePos;
                isFadeOver = false;
                _isReturning = false;
            }
        }
        
        _animator.SetBool("isFollowing", true);
        _teleportTimer -= Time.deltaTime;
        if(_teleportTimer <= 0f)
        {
            if(_isReturning)
            {
                _teleportTimer = _teleportCooldown;
                shouldTeleport = true;
            } else
            { 
                float random = Random.value;
                if(random < _chaseProbability)
                {
                    shouldTeleport = true;
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
