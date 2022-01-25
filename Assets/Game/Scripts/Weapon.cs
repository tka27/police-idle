using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] List<Rigidbody> projectilesPool;
    [SerializeField] Transform projectileSpawnPoint;
    [SerializeField] float shootDelay;
    [SerializeField] float shootForce;
    [SerializeField] ParticleSystem shootParticles;
    int currentProjectileIndex;


    public void Shoot(Vector3 tgt)
    {
        StartCoroutine(ShootWhithDelay(tgt));
    }

    IEnumerator ShootWhithDelay(Vector3 tgt)
    {
        yield return new WaitForSeconds(shootDelay);
        if (shootParticles != null)
        {
            shootParticles.Play();
        }

        var projectile = projectilesPool[currentProjectileIndex];

        projectile.gameObject.SetActive(true);
        projectile.transform.position = projectileSpawnPoint.position;
        projectile.transform.rotation = Quaternion.identity;

        Vector3 shootVector = (tgt - projectileSpawnPoint.position).normalized * shootForce;
        projectile.isKinematic = false;
        projectile.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        projectile.AddForce(shootVector);

        //Debug.DrawRay(projectileSpawnPoint.position, shootVector,Color.red,10);

        StartCoroutine(DeactivateProjectile(projectile));

        currentProjectileIndex++;
        if (currentProjectileIndex == projectilesPool.Count)
        {
            currentProjectileIndex = 0;
        }
    }

    IEnumerator DeactivateProjectile(Rigidbody rb)
    {
        yield return new WaitForSeconds(3);
        rb.HideRB();
    }
}
