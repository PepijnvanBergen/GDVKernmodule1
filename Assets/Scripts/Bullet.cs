using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : IDamageable, IConstantmove
{
    public GameObject MyModel;

    public float health;
    public float Health {
        get { return health; }
        set { health = value;
              if (health < 1) Debug.Log("DESTROY BULLET");
            }
    }

    public float Speed { get; set; }

    public void Move(float speed)
    {
        Debug.Log("Im Moving Up or Down Depending on the Speed!");
    }

    public float GivePositionX()
    {
        float xx = MyModel.transform.position.x;
        return xx;
    }

    public float GivePositionY()
    {
        float yy = MyModel.transform.position.y;
        return yy;
    }
    public void TakeDamage(float dmg)
    {
        Health -= dmg;
    }

}
