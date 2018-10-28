using UnityEngine;


public class Movement
{
    public float Speed;

    public Movement(float speed)
    {
        Speed = speed;
    }

    public Vector3 Calculate(float moveHorizontal, float moveVertical)
    {
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        movement = movement * Speed;
        return movement;
    }

}
