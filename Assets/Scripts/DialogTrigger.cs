using TMPro;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialogue;

    private bool isInrange;

    private TextMeshProUGUI interactUI;

    private void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("TextUI").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (isInrange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("dialogue enclenché");
            TriggerDialog();
        }
    }

    void TriggerDialog()
    {
        DialogManager.instance.StartDialog(dialogue);
        interactUI.enabled = false;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInrange = true;
            interactUI.enabled = true;
            interactUI.SetText("PRESS E TO TALK");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInrange = false;
            interactUI.enabled = false;
            DialogManager.instance.EndDialog();
        }
    }
}
