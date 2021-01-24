using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StoryText : MonoBehaviour
{
    
    public Text txt;
    public float scrollSpeed = 10f;
    public float loadPoint; // value for top one-minus.
    public int LevelID;

    private TextMeshProUGUI _TMTxt;
    private RectTransform _trans;

    void Start()
    {
        _trans = GetComponent<RectTransform>();
        
        _TMTxt = GetComponent<TextMeshProUGUI>();
        _TMTxt.text = txt.text;
    }

    void Update()
    {
        _trans.offsetMax += new Vector2(0f, scrollSpeed * Time.deltaTime);

        if(_trans.offsetMax.y > loadPoint)
        {
            SceneManager.LoadScene(LevelID);
        }
    }
}
