using System.Collections;
using UnityEngine;

public class Scythe : BaseWeapon
{
    [SerializeField] GameObject scytheProjectile;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(SpawnScytheCoroutine());
    }

    private IEnumerator SpawnScytheCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            float randomAngle = UnityEngine.Random.Range(0, 360f);
            Instantiate(scytheProjectile, player.transform.position, Quaternion.Euler(0, 0, randomAngle));
        }
    }
}
