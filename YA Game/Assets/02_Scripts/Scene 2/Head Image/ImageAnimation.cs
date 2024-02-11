using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ImageAnimation : MonoBehaviour
{
    [Header("Links")] 
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private Image _imageTarget;

    [Header("General Settings")] 
    [SerializeField] private float _imageFlipTime = 1.2f;
    [SerializeField] private Vector2 _scaleImageBounds = new Vector2(0.6f, 1.5f);
    [SerializeField] private Vector3 _rotateImageBounds = new Vector3(100, 20f, 20f);
    [SerializeField] private float _animationTime = 1f;

    private Vector3 _initScale;
    void Awake()
    {
        _initScale = _imageTarget.transform.localScale;
    }

    private IEnumerator Start()
    {
        while (true)
        {
            SetRandomScaleAndRotation();
            SetRandomImage();
            
            yield return new WaitForSeconds(_imageFlipTime);
        }
    }

    private void SetRandomScaleAndRotation()
    {
        _imageTarget.transform.DOScale(_initScale * Random.Range(_scaleImageBounds.x, _scaleImageBounds.y), _animationTime).SetEase(Ease.OutSine);
        
        _imageTarget.transform.DORotate(new Vector3(Random.Range(-_rotateImageBounds.x, _rotateImageBounds.x),
            Random.Range(-_rotateImageBounds.y, _rotateImageBounds.y), Random.Range(-_rotateImageBounds.z, 
                _rotateImageBounds.z)), _animationTime).SetEase(Ease.OutSine);
    }

    private void SetRandomImage()
    {
        _imageTarget.sprite = _sprites[Random.Range(0, _sprites.Length)];
    }
    
}
