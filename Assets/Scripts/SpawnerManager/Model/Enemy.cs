using UnityEngine;

[RequireComponent(typeof(Mover))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Mover _mover;

    private Coroutine _moving;

    public void Move(in Vector3 destination)
    {
        _moving = StartCoroutine(_mover.ChangePosition(destination));
    }

    public void Stop()
    {
        if (_moving != null)
            StopCoroutine(nameof(_mover.ChangePosition));
    }
}
