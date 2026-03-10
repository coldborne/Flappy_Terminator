using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.CollidedWithObstacle += Finish;
    }

    private void Finish()
    {
        _player.GetComponent<Rigidbody2D>().simulated = false;
    }
}
