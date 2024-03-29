using UnityEngine;

public class CharacterSwap : MonoBehaviour
{
    public GameObject playerCharacter1; // Reference to the first player character GameObject
    public GameObject playerCharacter2; // Reference to the second player character GameObject

    private GameObject currentPlayerCharacter; // Reference to the currently active player character

    void Start()
    {
        // Set the first player character as the initial active character
        currentPlayerCharacter = playerCharacter1;
        playerCharacter1.SetActive(true);
        playerCharacter2.SetActive(false);
    }

    void Update()
    {
        // Check for space bar input to toggle between player characters
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TogglePlayerCharacter();
        }
    }

    void TogglePlayerCharacter()
    {
        // Store the current position of the player character
        Vector3 currentPosition = currentPlayerCharacter.transform.position;

        // Deactivate the current player character
        currentPlayerCharacter.SetActive(false);

        // Toggle between playerCharacter1 and playerCharacter2
        if (currentPlayerCharacter == playerCharacter1)
        {
            currentPlayerCharacter = playerCharacter2;
        }
        else
        {
            currentPlayerCharacter = playerCharacter1;
        }

        // Set the position of the new current player character to match the x position of the previous one
        Vector3 newPosition = new Vector3(currentPosition.x, currentPlayerCharacter.transform.position.y, currentPlayerCharacter.transform.position.z);
        currentPlayerCharacter.transform.position = newPosition;

        // Activate the new current player character
        currentPlayerCharacter.SetActive(true);
    }
}
