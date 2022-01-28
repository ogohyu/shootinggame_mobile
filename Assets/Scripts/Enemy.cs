using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    Vector3 dir;
    public GameObject explosionFactory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable() 
    {
        int randValue = UnityEngine.Random.Range(0, 10);

        if(randValue < 3)
        {
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position;

            dir.Normalize();
        }
        else
        {
            dir = Vector3.down;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;

        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        if (0 > viewPos.y)
        {
            gameObject.SetActive(false);

            GameObject emObject = GameObject.Find("EnemyManager");
            EnemyManager manager = emObject.GetComponent<EnemyManager>();

            manager.enemyObjectPool.Add(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.name.Contains("Player"))
        {
            SceneManager.LoadScene("GameOverScene");
        }
        else
        {
            ScoreManager.Instance.Score++;

            GameObject explosion = Instantiate(explosionFactory);
            explosion.transform.position = transform.position;

            if (other.gameObject.name.Contains("Bullet"))
            {
                other.gameObject.SetActive(false);

                GameObject player = GameObject.Find("Player");
                PlayerFire fire = player.GetComponent<PlayerFire>();

                fire.bulletObjectPool.Add(other.gameObject);
            }
            gameObject.SetActive(false);

            GameObject emObject = GameObject.Find("EnemyManager");
            EnemyManager manager = emObject.GetComponent<EnemyManager>();

            manager.enemyObjectPool.Add(gameObject);
        }
    }
}
