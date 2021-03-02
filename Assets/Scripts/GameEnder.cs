using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnder : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private int WaitTime = 20;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    
     public IEnumerator RollCredits()
    {
        yield return new WaitForSeconds(WaitTime);
        animator.SetBool("CreditsOut", true);
    }
     
    
   public IEnumerator Finish()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("StartMenu");
    }
}
