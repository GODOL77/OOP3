using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    // 1
    public float MoveSpeed = 10f;
    public float RotateSpeed = 75f;

    // 2
    private float _vInput;
    private float _hInput;

    private Rigidbody _rb;

    public float JumpVelocity = 5f;
    private bool _isJumping;

    public float DistanceToGround = 0.1f;
    public LayerMask GroundLayer;
    private CapsuleCollider _col;

    public GameObject Bullet;
    public float BulletSpeed = 100f;

    private bool _isShooting;
    // Start is called before the first frame update
    void Start()
    {
        // 3
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        // 4
        _vInput = Input.GetAxis("Vertical") * MoveSpeed;
        
        // 5
        _hInput = Input.GetAxis("Horizontal") * RotateSpeed;
        _isJumping |= Input.GetKeyDown(KeyCode.Space);

        _isShooting |= Input.GetKeyDown(KeyCode.F);
        // // 5
        // this.transform.Translate(Vector3.forward * _vInput * Time.deltaTime);

        // // 6
        // this.transform.Rotate(Vector3.up * _hInput * Time.deltaTime);
    }

    // 1
    void FixedUpdate()
    {
        // 2
        Vector3 rotation = Vector3.up * _hInput;

        // 3
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        // 4
        _rb.MovePosition(this.transform.position + this.transform.forward * _vInput * Time.fixedDeltaTime);

        // 5
        _rb.MoveRotation(_rb.rotation * angleRot);
        if (IsGrounded() && _isJumping)
        {
            _rb.AddForce(Vector3.up * JumpVelocity, ForceMode.Impulse);
            _isJumping = false;
        }

        if (_isShooting)
        {
            GameObject newBullet = Instantiate(Bullet, this.transform.position + new Vector3(0, 0, 1), this.transform.rotation);

            Rigidbody BulletRB = newBullet.GetComponent<Rigidbody>();

            BulletRB.velocity = this.transform.forward * BulletSpeed;
        }

        _isShooting = false;
    }

    private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z);

        bool grounded = Physics.CheckCapsule(_col.bounds.center, capsuleBottom, DistanceToGround, GroundLayer, QueryTriggerInteraction.Ignore);

        return grounded;
    }
}
