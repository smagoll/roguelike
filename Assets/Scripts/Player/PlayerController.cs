using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private FloatingJoystick joystick;
    private Character character;
    private SpriteRenderer spriteRenderer;
    public Vector2 directionLook;

    private bool flipRight;

    private void Awake()
    {
        character = GetComponent<Character>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        var direction = new Vector2(joystick.Direction.x, joystick.Direction.y);
        transform.Translate(character.Speed * Time.deltaTime * direction);

        var isMove = direction.magnitude > 0;
        character.animator.SetBool("isMove", isMove);

        if (isMove)
            directionLook = direction;

        CheckFlip(direction);
    }

    private void Flip() // поворот персонажа
    {
        flipRight = !flipRight;
        spriteRenderer.flipX = flipRight;
    }

    private void CheckFlip(Vector2 direction)
    {
        if (direction.x < 0 && !flipRight)
        {
            Flip();
        }
        else if (direction.x > 0 && flipRight)
        {
            Flip();
        }

    }
}
