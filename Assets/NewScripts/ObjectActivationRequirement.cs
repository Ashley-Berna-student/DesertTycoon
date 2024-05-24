using UnityEngine;

public class GameObjectActivationManager : MonoBehaviour
{
    public GameObject[] requiredObjects; // Objects that need to be active for targets to activate
    public GameObject[] targetObjects; // Objects to activate when requiredObjects are active
    [HideInInspector] public bool isActivated = false; // Flag to track if targets have been activated

    private void Start()
    {
        // Ensure all target objects are initially inactive
        SetObjectsActive(targetObjects, false);
    }

    private void Update()
    {
        // Check if required objects are active
        if (!isActivated && CheckCompletion(requiredObjects))
        {
            ActivateObjects(targetObjects);
            isActivated = true;
        }
    }

    private bool CheckCompletion(GameObject[] objects)
    {
        foreach (GameObject obj in objects)
        {
            if (!obj.activeSelf)
                return false;
        }
        return true;
    }

    private void ActivateObjects(GameObject[] objects)
    {
        SetObjectsActive(objects, true);
    }

    private void SetObjectsActive(GameObject[] objects, bool active)
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(active);
        }
    }
}
