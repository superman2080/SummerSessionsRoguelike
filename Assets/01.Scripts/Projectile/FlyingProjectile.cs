using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FlyingProjectile : MonoBehaviour
{
    public Tilemap tilemap;
    public Transform target;

    public void Update()
    {
        Pathfinder.Follow(tilemap, transform, target.position, 6);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.TryGetComponent(out Entity entity)) return;
        
        entity.Damage(10f);
        Destroy(this.gameObject, 0f);
            
        ParticleManager.Instance.SpawnParticle(transform.position, "Smoke");
    }
}
