using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private FloatingJoystick joystick;
    private Character character;

    private void Awake()
    {
        character = GetComponent<Character>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        var direction = new Vector2(joystick.Direction.x, joystick.Direction.y);
        transform.Translate(direction * character.speed * Time.deltaTime);
    }
}
