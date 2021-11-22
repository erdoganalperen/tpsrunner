using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text playText;
    public Text restartText;
    public Text highScoreText;
    Animator playerAnimator;
    PlayerInputController _playerInputController;
    Vector2 _mouseDelta;
    public float speed;
    private CharacterController _characterController;
    private bool _firing;
    Vector3 _simpleMoveSpeed;
    private float groundSizeX;
    private bool _gameStarted;
    private bool failed;
    private void Awake()
    {
        _gameStarted = false;
        failed = false;
        _playerInputController = new PlayerInputController();
        _playerInputController.Movement.Delta.performed += ProcessMouseDelta;
        _playerInputController.Movement.Click.started += x =>
        {
            if (failed)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            if (!_gameStarted)
            {
                playText.gameObject.SetActive(false);
                _gameStarted = true;
                StartCoroutine(Shoot());
                EnemyManager.Instance.StartSpawn();
                return;
            }

            _firing = true;
            playerAnimator.SetTrigger("fire");
        };
        _playerInputController.Movement.Click.canceled += x =>
        {
            _firing = false;
            playerAnimator.SetTrigger("run");
        };
    }
    public Transform weaponTransform;
    private void Start()
    {
        var s = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "HighScore: " + s;
        Cursor.lockState = CursorLockMode.Locked;
        groundSizeX = 5;
        playerAnimator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
        _characterController.detectCollisions = true;

    }
    
    private void Update()
    {
        if (!_gameStarted)
        {
            return;
        }
        _simpleMoveSpeed = Vector3.forward * speed;
        if (_mouseDelta.x != 0) //if (_firing && _mouseDelta.x != 0)
        {
            _simpleMoveSpeed += new Vector3( 1.5f*speed * Mathf.Sign(_mouseDelta.x), 0, 0);

            if (Mathf.Abs(transform.position.x) > groundSizeX / 2)
            {
                if (Mathf.Sign(transform.position.x) * Mathf.Sign(_simpleMoveSpeed.x) < 0)
                {
                }
                else
                {
                    _simpleMoveSpeed.x = 0;
                }
            }
        }
        
        _characterController.SimpleMove(_simpleMoveSpeed);
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            if (_firing)
            {
                var obj=ObjectPool.Instance.SpawnFromPool("bullet", weaponTransform.position, weaponTransform.rotation);
            }
            yield return new WaitForSeconds(.5f);
        }
  
    }
    void ProcessMouseDelta(InputAction.CallbackContext context)
    {
        _mouseDelta = context.ReadValue<Vector2>();
    }

    private void OnEnable()
    {
        _playerInputController.Movement.Enable();
    }
    private void OnDisable()
    {
        _playerInputController.Movement.Disable();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Enemy"))
        {
            _gameStarted = false;
            failed = true;
            var hs=PlayerPrefs.GetInt("HighScore", 0);
            var score = EnemyManager.Instance.score;
            if (score>hs)
            {
                PlayerPrefs.SetInt("HighScore",score);
            }
            restartText.gameObject.SetActive(true);
        }    }
}