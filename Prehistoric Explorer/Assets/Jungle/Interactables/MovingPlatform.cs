using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private List<Vector3> points;
    [SerializeField] private float distanceDelta;
    [SerializeField] private float speed;

    private Vector3 _destinationPoint;
    private int _destinationPointIndex;
    
    private void Start()
    {
        transform.position = points[0];
        _destinationPointIndex = 1;
        _destinationPoint = points[_destinationPointIndex];
    }

    private void Update()
    {
        var distanceToDestinationPoint = Vector3.Distance(_destinationPoint, transform.position);

        if (distanceToDestinationPoint <= distanceDelta)
        {
            _destinationPointIndex++;

            if (_destinationPointIndex > points.Count - 1)
            {
                _destinationPointIndex = 0;
            }

            _destinationPoint = points[_destinationPointIndex];
        }
        
        var direction = (_destinationPoint - transform.position).normalized;
        transform.Translate(speed * Time.deltaTime * direction);
    }
}
