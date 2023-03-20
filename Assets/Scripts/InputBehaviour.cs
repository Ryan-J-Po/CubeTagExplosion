using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBehaviour : MonoBehaviour
{
    private MovementBehaviour _movementBehaviour;
    public int PlayerNum;
    // Start is called before the first frame update
    void Start()
    {
        _movementBehaviour = GetComponent<MovementBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerNum == 1)
        {
            _movementBehaviour.SetMoveDirection(new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0));

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _movementBehaviour.Jump();
            }

        }
        else if (PlayerNum == 2)
        {
            _movementBehaviour.SetMoveDirection(new Vector3(Input.GetAxisRaw("Horizontal2"), 0, 0));

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                _movementBehaviour.Jump();
            }

        }
    }
}
