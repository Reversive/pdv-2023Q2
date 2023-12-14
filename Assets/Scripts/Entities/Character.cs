using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IMoveable
{
    #region PUBLIC_PROPERTIES
    public float MovementSpeed => _movementSpeed;
    public AudioSource audioPlayer;
    #endregion

    #region PRIVATE_PROPERTIES
    [SerializeField] private float _movementSpeed = 5f;
    [SerializeField] private float jumpforce = 10f;
    private float horizontalInput;
    private float verticalInput;
    private Rigidbody rb;
    [SerializeField] private Transform orientation;
    #endregion

    #region PUBLIC_METHODS
    public void Translate(Vector3 direction) => transform.Translate(direction * Time.deltaTime * _movementSpeed);
    #endregion

    #region UNITY_METHODS

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioPlayer = GetComponent<AudioSource>();
    }
    private void Update()
    {
        UpdateInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpforce,ForceMode.Impulse);
                
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Tree")
        {
            audioPlayer.Play();
        }
    }
    #endregion

    #region PRIVATE_METHODS
    private void UpdateInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }
    private void MovePlayer()
    {
        Vector3 moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        Translate(moveDirection);
    }
    #endregion
}
