using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public Button interactButton;
    public Sprite defaultButtonImage;
    public Sprite interactableButtonImage;

    private GameObject player;
    private bool isNearPlayer = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        interactButton.gameObject.SetActive(true);  // 버튼 항상 보이기
        interactButton.image.sprite = defaultButtonImage;  // 기본 이미지
        interactButton.onClick.AddListener(Interact);
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < 2f)
        {
            if (!isNearPlayer)
            {
                isNearPlayer = true;
                ShowInteractButton(true);
            }
        }
        else
        {
            if (isNearPlayer)
            {
                isNearPlayer = false;
                ShowInteractButton(false);
            }
        }
    }

    void ShowInteractButton(bool canInteract)
    {
        // 버튼은 항상 켜두고, 이미지 스프라이트만 바꿈
        interactButton.image.sprite = canInteract ? interactableButtonImage : defaultButtonImage;
    }

    void Interact()
    {
        if (isNearPlayer)
        {
            var npcDialogue = GetComponent<NPCDialogue>();
            if (npcDialogue != null)
            {
                interactButton.gameObject.SetActive(false);
                dialogueManager.interactButton = interactButton;
                dialogueManager.StartDialogue(npcDialogue.dialogueLines);
            }
        }
    }
}
