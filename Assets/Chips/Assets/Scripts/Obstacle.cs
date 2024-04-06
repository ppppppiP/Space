using UnityEngine;

enum ObstacleTipe
{
    Dirt,
    Ravine,
    Rock,
    ImpassableObstacle
}
public interface IObstacle
{
    public void SetDamage(bool canTake, PlayerHP hP, int damage);
}

public class Dirt : IObstacle
{

    public void SetDamage(bool canTake, PlayerHP hP, int damage)
    {
        if (canTake)
        {
            hP.TakeDamage(damage);
        }
    }
    
}

public class Ravine: IObstacle
{
    
    public void SetDamage(bool canTake, PlayerHP hP, int damage)
    {
        if (canTake)
        {
            hP.TakeDamage(damage);
        }
    }
}
public class ImpassableObstacle : IObstacle
{
    
    public void SetDamage(bool canTake, PlayerHP hP, int damage)
    {
        if (canTake)
        {
            hP.TakeDamage(damage);
        }
    }
}

public class Rock: IObstacle
{
    
    public void SetDamage(bool canTake, PlayerHP hP, int damage)
    {
        if (canTake)
        {
            hP.TakeDamage(damage);
        }
    }
}

public class Obstacle: MonoBehaviour
{
    IObstacle obstacle;
    [SerializeField] ObstacleTipe obstacleTipe;
    [SerializeField] int _damage;

    private void Start()
    {
        switch (obstacleTipe)
        {
            case ObstacleTipe.Dirt:
                obstacle = new Dirt();
                break;
            case ObstacleTipe.Ravine:
                obstacle = new Ravine();
                break;
            case ObstacleTipe.Rock:
                obstacle = new Rock();
                break; 
            case ObstacleTipe.ImpassableObstacle:
                obstacle = new ImpassableObstacle();
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerHP>(out PlayerHP hp))
        {
            other.TryGetComponent<PlayerInventory>(out PlayerInventory inventory);
            switch (obstacle)
            {
                case Dirt:
                    obstacle.SetDamage(inventory.Tires, hp, _damage);
                    break;
                case Ravine:
                    obstacle.SetDamage(inventory.Wings, hp, _damage);
                    break;
                case Rock:
                    obstacle.SetDamage(inventory.BoolBar, hp, _damage);
                    break;
                case ImpassableObstacle:
                    obstacle.SetDamage(inventory.Train, hp, _damage);
                    break;
            }
            
        }

    }


}