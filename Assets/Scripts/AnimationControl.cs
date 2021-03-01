using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private string _animationState;
    [SerializeField] private Animator _animator;
    [SerializeField] private Animator _childAnimator;
    [SerializeField] private GameObject _nextPoint;
    
    
    private float _timer;
    private BoxCollider _collider;

    private void Start()
    {
        _collider = GetComponent<BoxCollider>();
        _audioSource.clip = _clip;
    }

    private void Update()
    {
        if (_timer > 0)
        {
            _timer -= 1 * Time.deltaTime;
        }
        else if (_timer <= 0)
        {
            _animator.Play(_animationState);
            _childAnimator.Play("Spinning");
            _nextPoint.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _childAnimator.Play("SpinIdle");
        
        if (CompareTag("Player"))
        {
            _audioSource.Play();
            _timer = _clip.length;
            _collider.enabled = false;
        }
    }
}