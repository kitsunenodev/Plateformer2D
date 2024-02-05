using TMPro;
using UnityEngine;

public class InformationPopUp : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            text.enabled = true;
            text.SetText("YOU  CAN  USE  UP  AND  DOWN  TO  CLIMB  THE  LADDER");
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
            {
                text.enabled = false;
                Destroy(this);
                
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            text.enabled = false;
        }
    }
}
