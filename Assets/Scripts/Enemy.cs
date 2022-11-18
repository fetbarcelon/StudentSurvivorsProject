using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] GameObject crystalPrefab;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        var destination = player.transform.position;
        var source = transform.position;
        var direction = destination - source;
        direction.Normalize();

        transform.localScale = new Vector3(direction.x > 0 ? -1 : 1, 1, 1);

        transform.position += direction * Time.deltaTime * moveSpeed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<Player>();
        if (player != null)
        {
            if (player.Damage())
            {
                Destroy(gameObject);
            }
        }
    }

    internal void Damage()
    {
        Instantiate(crystalPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
