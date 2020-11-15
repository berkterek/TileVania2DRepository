using System.Collections;
using System.Collections.Generic;
using TileVania2D.Abstracts.Combats;
using TileVania2D.Abstracts.Cores;
using TileVania2D.Abstracts.Inputs;
using TileVania2D.Abstracts.Movements;
using TileVania2D.Cores;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace TileVania2D.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        IMove _move;
        IJump _jump;
        IClimb _climb;
        IHealth _health;
        IBaseInput _inputControl;
        Animator _animator;
        BoxCollider2D _collider2D;
        Rigidbody2D _rigidbody2D;

        bool _isTouchGround;
        bool _isOneTimePlayed = false;
        bool _isJumpButtonPress;

        private void Awake()
        {
            _health = GetComponent<IHealth>();
            _move = GetComponent<IMove>();
            _jump = GetComponent<IJump>();
            _climb = GetComponent<IClimb>();
            _inputControl = GetComponent<IBaseInput>();
            _animator = GetComponent<Animator>();
            _collider2D = GetComponent<BoxCollider2D>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (!_health.IsAlive) 
            {
                if(!_isOneTimePlayed)
                {
                    GameSession.Instance.TryAgain();
                    _isOneTimePlayed = true;
                }

                return;
            } 

            MoveInputs();
            ClimbUpOrDownInputs();
            _isJumpButtonPress = _inputControl.IsJump;
        }

        private void FixedUpdate()
        {
            if (!_health.IsAlive) return;

            JumpAction();
            _isTouchGround = _collider2D.IsTouchingLayers(LayerMask.GetMask("Climbing"));
        }

        private void ClimbUpOrDownInputs()
        {
            if (_isTouchGround)
            {
                if (_rigidbody2D.gravityScale == 1f) _rigidbody2D.gravityScale = 0f;

                _climb.ClimbAction(_inputControl.Veritical);

                _animator.SetBool("IsClimbing", true);
            }
            else
            {
                if (_rigidbody2D.gravityScale == 0f)
                {
                    _rigidbody2D.gravityScale = 1f;
                    _animator.SetBool("IsClimbing", false);
                }
            }
        }

        private void JumpAction()
        {
            if (_isJumpButtonPress)
            {
                _jump.JumpAction(_rigidbody2D);
            }
        }

        private void MoveInputs()
        {
            float horizontal = _inputControl.Horizontal;

            if (horizontal == 0f)
            {
                _animator.SetBool("IsRunning", false);
            }
            else
            {
                _move.MoveCharacter(horizontal);
                _animator.SetBool("IsRunning", true);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            IDamage damage = collision.transform.GetComponent<IDamage>();

            if (damage != null && _health.IsAlive)
            {
                BoxCollider2D boxCollider = collision.collider as BoxCollider2D;
                if (boxCollider != null) return;
                
                _health.SetCurrentHealth(damage.ToDamage);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            IDamage damage = collision.transform.GetComponent<IDamage>();

            if (damage != null && _health.IsAlive)
            {
                _health.SetCurrentHealth(damage.ToDamage);
            }
        }
    }
}

