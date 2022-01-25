using System;
using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private const string EnemyTag = "Enemy";
    [SerializeField] private float explosionForce;
    [SerializeField] private float explosionRadius;
    public static event Action<Rigidbody> onEnemyHitEvent;
    private Rigidbody _selfRB;
    private void Start()
    {
        _selfRB = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision other)
    {
        var rb = other.rigidbody;

        if (rb != null && rb.tag == EnemyTag)
        {
            var contact = other.GetContact(0);
            // SceneData.singleton.hitParticles.transform.position = contact.point;
            // SceneData.singleton.hitParticles.Play();
            onEnemyHitEvent.Invoke(rb);
            StartCoroutine(ApplyExplosion(rb, contact.point));
        }
        StartCoroutine(HideProjectile());
    }
    IEnumerator HideProjectile()
    {
        yield return new WaitForFixedUpdate();
        _selfRB.HideRB();
    }

    IEnumerator ApplyExplosion(Rigidbody rb, Vector3 contact)
    {
        yield return new WaitForFixedUpdate();
        rb.AddExplosionForce(explosionForce, contact, explosionRadius);
    }
}
