using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    private float timeSpeed=0.2f; 
   private void Update()
    {
        //TimeIsSLow();
       
    }
    public void TimeIsSLow()
    {
        Time.timeScale = timeSpeed;
        Time.fixedDeltaTime = Time.timeScale*0.15f;
    }

    private void OnMouseDown()
    {
        TimeIsSLow();
        Debug.Log("Touched");
    }

}
