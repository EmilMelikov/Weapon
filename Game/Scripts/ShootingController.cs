using UnityEngine;
public class ShootingController : MonoBehaviour
{
    [SerializeField] private WeaponManager weaponManager;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bouncingProjectile;
    [SerializeField] private GameObject physicsProjectile;

    private bool _isCharging;
    private float _chargeTime;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began && weaponManager.GetCurrentWeapon() == WeaponType.Physics)
            {
                _isCharging = true;
                _chargeTime = 0f;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                if (_isCharging) ShootPhysics();
                else ShootBouncing();
                _isCharging = false;
            }

            if (_isCharging) _chargeTime += Time.deltaTime;
        }
    }

    private void ShootBouncing()
    {
        Instantiate(bouncingProjectile, firePoint.position, firePoint.rotation).GetComponent<Projectile>().Launch(firePoint.right);
        PlayShootAnimation();
    }

    private void ShootPhysics()
    {
        GameObject projectile = Instantiate(physicsProjectile, firePoint.position, firePoint.rotation);
        projectile.GetComponent<Projectile>().Launch(firePoint.right * (_chargeTime + 1));
        Destroy(projectile, 2f);
        PlayShootAnimation();
    }

    private void PlayShootAnimation()
    {
        LeanTween.moveLocal(gameObject, transform.localPosition - Vector3.up * 0.2f, 0.1f).setLoopPingPong(1);
    }
}