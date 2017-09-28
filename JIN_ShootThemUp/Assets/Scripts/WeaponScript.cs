using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Launch projectile
/// </summary>
public class WeaponScript : MonoBehaviour
{
    
    /// Projectile prefab for shooting
    public Transform shotPrefab;

    /// Cooldown in seconds between two shots
    public float shootingRate = 0.25f;

    // Number of shots before recharging
    public int numberShots = 6;
    private int numberShotsRemaining = 0;
    
    // Cooldown
    private float shootCooldown = 0f;

    // Recharge the number of shots
    void RechargeShots()
    {
        shootCooldown = 0f;
        numberShotsRemaining = numberShots;
    }

    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
    }
   
    /// Create a new projectile if possible
    public void Attack(bool isEnemy)
    {
        if (CanAttack)
        {
            if (numberShotsRemaining > 0)
            {
                shootCooldown = shootingRate;

                // Create a new shot
                var shotTransform = Instantiate(shotPrefab) as Transform;

                // Assign position
                shotTransform.position = transform.position;

                // The is enemy property
                ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
                if (shot != null)
                {
                    shot.isEnemyShot = isEnemy;
                }

                // Make the weapon shot always towards it
                MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
                if (move != null)
                {
                    move.direction = this.transform.right; // towards in 2D space is the right of the sprite
                }
                numberShotsRemaining--;
            }
            else
            {
                RechargeShots();
            }
        }   
    }

    /// Is the weapon ready to create a new projectile?
    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }
}
