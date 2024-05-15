using System.Collections;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<Player>(out Player player))
        {
            player.Damage(GameObject.FindFirstObjectByType<EnemyAI>().damage);
            Destroy(gameObject);
        }
        StartCoroutine(DestroyBullet());
    }
    private IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
