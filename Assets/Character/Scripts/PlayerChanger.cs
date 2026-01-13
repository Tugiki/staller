using UnityEngine;

public class PlayerChanger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] GameObject changer;
    [SerializeField] GameObject _changed;
    private GameObject changerHolder;
   
    // Update is called once per frame
    void Update()
     {
        

        if (Input.GetKeyDown(KeyCode.R))
        {

            // This section sets the position of the new active player character to match the previous one.
            _changed.transform.position =  new Vector3(changer.transform.position.x, _changed.transform.position.y, changer.transform.position.z);

            // NEED A ROTATION MATCHER HERE 
            

            // This section switches the active player character when the "R" key is pressed.
            changer.SetActive(false);
            _changed.SetActive(true);

            changerHolder = changer.gameObject;
            changer = _changed.gameObject;
            _changed = changerHolder.gameObject;

            
            Debug.Log("Pressed R");
        }
    }
}
