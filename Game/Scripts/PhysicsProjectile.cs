using UnityEngine;
public class PhysicsProjectile : Projectile
{
    [SerializeField] private float speed = 5f;
    private Rigidbody2D _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    public override void Launch(Vector2 direction)
    {
        _rb.AddForce(direction * speed, ForceMode2D.Impulse);
        _rb.gravityScale = 1f;
    }
}