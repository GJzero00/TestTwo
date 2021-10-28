using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class volume : MonoBehaviour
{

    public AudioMixer audioMixer;
   
    public void SetVoiume(float value)
    {
        audioMixer.SetFloat("MainVolune", value);
    }
}
