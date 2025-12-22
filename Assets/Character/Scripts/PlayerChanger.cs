using UnityEngine;

public class PlayerChanger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] GameObject changer;
    [SerializeField] GameObject _changed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {

            changer.SetActive(false);
            _changed.SetActive(true);
            
            Debug.Log("Pressed R");
        }
    }
}
