using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float groundSizeX;
    public GameObject player;
    public static EnemyManager Instance;
    public int score;
    public Text scoreText;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score;
        groundSizeX = 5;
    }

    public void StartSpawn()
    {
        InvokeRepeating(nameof(CreateEnemy),0f,1f);
    }

   public void Kill()
   {
       score++;
       scoreText.text = "Score: " + score;
   }
    void CreateEnemy()
    {
        Vector3 pos = new Vector3(Random.Range(groundSizeX / -2, groundSizeX / 2),1,player.transform.position.z+15);
        ObjectPool.Instance.SpawnFromPool("enemy", pos, Quaternion.identity);
        // Instantiate(enemyPrefab, pos, Quaternion.identity);
    }
}
