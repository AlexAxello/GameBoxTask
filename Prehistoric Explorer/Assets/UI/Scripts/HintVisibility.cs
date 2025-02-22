using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HintVisibility : MonoBehaviour
{
    private Image[] _imageElements;
    private TMP_Text[] _textElements;

    [SerializeField] private Transform targetObject;
    [SerializeField] private float minDistance, maxDistance;

    private void Start()
    {
        _imageElements = GetComponentsInChildren<Image>();
        _textElements = GetComponentsInChildren<TMP_Text>();
    }

    private void Update()
    {
        ChangeTransparency();
    }

    private void ChangeTransparency()
    {
        var distanceToTarget = Mathf.Abs(transform.position.x - targetObject.position.x);

        if (distanceToTarget > maxDistance)
        {
            distanceToTarget = maxDistance;
        }

        if (distanceToTarget < minDistance)
        {
            distanceToTarget = minDistance;
        }

        var range = maxDistance - minDistance;
        
        var newAlpha = (1 - ((distanceToTarget - minDistance) / range));

        if (_imageElements.Length >0)
        {
            foreach (var image in _imageElements)
            {
                image.color = new Color(image.color.r, image.color.g, image.color.b, newAlpha);
            } 
        }

        if (_textElements.Length > 0)
        {
            foreach (var text in _textElements)
            {
                text.color = new Color(text.color.r, text.color.g, text.color.b, newAlpha);
            }
        }
    }
}
