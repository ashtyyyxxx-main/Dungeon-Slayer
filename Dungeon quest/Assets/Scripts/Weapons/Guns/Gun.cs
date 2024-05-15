using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    private Item item;
    private bool readyToAttack = true;
    private Text ammoText;

    [SerializeField] private KeyCode attackKeyCode;
    [SerializeField] private int damage;
    [SerializeField] private int shootCooldown;
    [SerializeField] private int reloadTime;
    [SerializeField] private AudioSource shootSound;
    [SerializeField] private ParticleSystem muzzleFlash;

    private void Start()
    {
        item = GetComponent<Item>();
    }

    private void Update()
    {
        Physics.Raycast(transform.position, Camera.main.transform.forward, out RaycastHit hitInfo,50,9);
        if (item.isEquiped && readyToAttack && Input.GetKeyDown(attackKeyCode))
        {
            muzzleFlash.Play();
            shootSound.Play();

            if (hitInfo.collider != null)
            {
                if (hitInfo.collider.gameObject.TryGetComponent<Buddy>(out Buddy buddy))
                {
                    buddy.Damage(damage);
                }
            }
        }
    }

    /*private void Attack()
    {
        Physics.Raycast(transform.position, Camera.main.transform.forward, out RaycastHit hitInfo);
        muzzleFlash.Play();
        shootSound.Play();

        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.gameObject.TryGetComponent<Buddy>(out Buddy buddy))
            {
                buddy.Damage(damage);
            }
        }

    }*/

        //случается баг, поэтому стрельба без задержки
        //StartCoroutine(AttackCooldown());
    

    IEnumerator AttackCooldown()
    {
        readyToAttack = false;
        yield return new WaitForSeconds(shootCooldown);
        readyToAttack = true;
    }
}
