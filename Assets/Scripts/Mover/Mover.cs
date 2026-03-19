using System.Collections;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField, Min(0f)] private float _speed = 1.5f;

    private void OnValidate()
    {
        if (Mathf.Approximately(_speed, 0f))
            Debug.LogWarning($"Speed ({nameof(_speed)}) is approximately 0, mover won't be working.");
    }

    public IEnumerator ChangePosition(Vector3 destination)
    {
        if (Mathf.Approximately(_speed, 0))
            yield break;

        var await = new WaitForEndOfFrame();

        while (true)
        {
            Vector3 normalizedPath = (destination - transform.position).normalized;
            transform.position += _speed * Time.deltaTime * normalizedPath;

            if (destination == transform.position)
                yield break;

            yield return await;
        }
    }
}
