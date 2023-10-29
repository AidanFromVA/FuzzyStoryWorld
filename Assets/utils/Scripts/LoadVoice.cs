/*
 * - Name: LoadVoice.cs
 * 
 * - Content: A script created to reuse code previously applied to scenes during the modification of the VoiceManager. It handles the previous responsibilities of the VoiceManager.
 * 
 * - History:
 * 1) 2021-08-24: Code implementation.
 * 2) 2021-08-24: Commented.
 *
 * - LoadVoice Member Variables:
 * 
 * VoiceInfo[] mvifl_setVoiceInfoList: A struct data containing customizable voice settings from the Inspector window. Inside the structure, you'll find:
 *    public Voice svt_voiceType: An enum data that sets the default voice of the desired Google TTS API. We restructured it into enum format with only the necessary data. The available enum types are: KR_FEMALE_A, KR_FEMALE_B, KR_MALE_A, KR_MALE_B, EN_FEMALE_A, EN_FEMALE_B, EN_MALE_A, EN_MALE_B, JP_FEMALE_A, JP_FEMALE_B, JP_MALE_A, JP_MALE_B, CN_FEMALE_A, CN_FEMALE_B.
 *    public string sstr_words: A variable that stores what words the voice will speak in a string format.
 *    public float sf_pitch: A variable to adjust the pitch (high/low) of the voice.
 *    public string sf_speakingRate: A variable to adjust the speaking rate of the voice.
 *    public AudioClip sac_voiceAudioClip: A variable to store the final voice data received from TTS communication.
 * mtts_getVoice: A class defining TTS communication.
 * mb_CheckLoadComplete: A variable indicating when the API communication has finished.
 * mn_checkCurInx: A variable needed for indexing the work of the thread. It represents the current scene index, and when this index changes, the setter uses coroutines and threads to perform communication.
 * mquefa_queue: A queue for data communication between the main thread and created threads. The created threads store their work in this queue, and the main thread uses this work to generate voices.
 * mth_workThread: The created thread mentioned above, responsible for TTS communication.
 * mb_checkSceneReady: A variable that, when the work is done, is set to true to allow detection in other scripts.
 * 
 * - LoadVoice Member Functions:
 *
 * Start(): Executed when the VoiceManager GameObject is created. Initializes the necessary voice data for scenes based on voice settings entered in the Inspector window.
 * isPlaying(): Returns whether the AudioSource is currently playing audio. It returns true if audio is playing and false if not.
 * runThread(): Function where the TTS processing code of the mth_workThread thread is executed. The processed float array result is stored in the mquefa_queue queue.
 * CheckQueue(): Defines the work stages for each scene using this coroutine.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class LoadVoice : MonoBehaviour {

    [System.Serializable]
    public struct VoiceInfo {
        [SerializeField]
        private TTS.Voice svt_voiceType;
        public TTS.Voice voiceType {
            set {
                svt_voiceType = value;
            }
            get {
                return svt_voiceType;
            }
        }      

        [SerializeField]
        private string sstr_words;
        public string words {
            set {
                sstr_words = value;
            }
            get {
                return sstr_words;
            }
        }
        [SerializeField]
        private float sf_pitch;
        public float pitch {
            set {
                sf_pitch = value;
            }
            get {
                return sf_pitch;
            }
        }
        [SerializeField]
        private string sf_speakingRate;
        public string speakingRate {
            set {
                sf_speakingRate = value;
            }
            get {
                return sf_speakingRate;
            }
        }
        [SerializeField]
        private AudioClip sac_voiceAudioClip;
        public AudioClip audioClip {
            set {
                sac_voiceAudioClip = value;
            }
            get {
                return sac_voiceAudioClip;
            }
        }
    }

    public VoiceInfo[] mvifl_setVoiceInfoList;
    private int mn_checkCurInx = 0;
    public int CurrentIndex {
        set {
            mn_checkCurInx = value;
            StartCoroutine(CheckQueue());
            mth_workThread = new Thread(new ParameterizedThreadStart(runThread));
            mth_workThread.Start(value);
        }
        get {
            return mn_checkCurInx;
        }
    }
    private bool mb_CheckLoadComplete = false;
    public bool CheckLoadComplete {
        set {
            mb_CheckLoadComplete = value;
        }
        get {
            return mb_CheckLoadComplete;
        }
    }
    private TTS mtts_getVoice;
    private Queue<float[]> mquefa_queue = new Queue<float[]>();
    private Thread mth_workThread;
    public bool mb_checkSceneReady = false;

    // Declares the class for TTS.
    void Awake() {
        mtts_getVoice = TTS.GetInstance();
    }

    // Checks the queue every frame. If there is content in the queue, it is transformed into an AudioClip. If there's nothing, it waits.
    IEnumerator CheckQueue() {
        while (true) {
            if(mquefa_queue.Count > 0) {
                var fa_convertFloatArray = mquefa_queue.Dequeue();
                
                AudioClip ac_createAudioClip = AudioClip.Create("audioContent", fa_convertFloatArray.Length, 1, 44100, false);

                ac_createAudioClip.SetData(fa_convertFloatArray, 0);
                mvifl_setVoiceInfoList[mn_checkCurInx].audioClip = ac_createAudioClip;
                mb_CheckLoadComplete = true;
                yield break;
            }
            yield return null;  // Checks every frame.
        }
    }

    // The function where the created thread should work (TTS communication).
    private void runThread(object nLoadId) {
        float tempSpeakRate = 0.8f;
        int n_LoadIndex = (int)nLoadId;
        // Load the audio clips as needed...
        if (float.TryParse(mvifl_setVoiceInfoList[n_LoadIndex].speakingRate, out tempSpeakRate)) {
            mquefa_queue.Enqueue(mtts_getVoice.CreateAudio(mvifl_setVoiceInfoList[n_LoadIndex].words, mvifl_setVoiceInfoList[n_LoadIndex].voiceType, mvifl_setVoiceInfoList[n_LoadIndex].pitch, tempSpeakRate));
        } else {
            mquefa_queue.Enqueue(mtts_getVoice.CreateAudio(mvifl_setVoiceInfoList[n_LoadIndex].words, mvifl_setVoiceInfoList[n_LoadIndex].voiceType, mvifl_setVoiceInfoList[n_LoadIndex].pitch));
        }
    }
}
