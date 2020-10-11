using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks 
{
 
    public static GameManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<GameManager>();
            }
            return m_instance;
        }
    }

    private static GameManager m_instance;
    public GameObject playerPrefab;
    public bool isGameover { get; private set; }  

    private void Awake()
    {
        //Debug.Log(this.GetInstanceID()); GetInstanceID -> Instance의 주소값
        if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void GameOver()
    {
        isGameover = true;
    }

   
}
