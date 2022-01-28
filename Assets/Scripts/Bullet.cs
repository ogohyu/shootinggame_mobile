using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.up;
        transform.position += dir * speed * Time.deltaTime;

        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        if(viewPos.y > 1)
        {
            gameObject.SetActive(false);

            GameObject player = GameObject.Find("Player");
            PlayerFire fire = player.GetComponent<PlayerFire>();

            fire.bulletObjectPool.Add(gameObject);
        }
    }
}
