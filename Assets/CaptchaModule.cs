using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CaptchaModule : MonoBehaviour
{
    public List<Texture2D> BombImages;

    public KMSelectable Selectable;
    public KMBombModule Module;
    public KMAudio Audio;

    public KMSelectable[] ImageButtons;
    public GameObject[] CorrectChecks;
    public KMSelectable VerifyButton;

    public TextMesh SearchText;

    public GameObject MainStuff;
    public GameObject CheckArea;
    public GameObject Checkbox;
    public GameObject MainCheck;
    public GameObject AutoSolveText;
    public Texture2D RedCheckbox;
    
    private class BombImage
    {
        public int Index;
        public List<string> Modules;
        public BombImage(int index, List<string> modules)
        {
            Index = index;
            Modules = modules;
        }
    }

    private static readonly Dictionary<string, string> Modules = new Dictionary<string, string>
    {
        { "Wires", "Wires" },
        { "Button", "The Button" },
        { "Keypad", "Keypads" },
        { "Simon", "Simon Says" },
        { "Whos", "Who's On First" },
        { "Memory", "Memory" },
        { "Morse", "Morse Code" },
        { "Venn", "Complicated Wires" },
        { "Seq", "Wire Sequences" },
        { "Maze", "Mazes" },
        { "Password", "Passwords" },
        { "Vent", "Venting Gas" },
        { "Cap", "Capacitor Discharge" },
        { "Knob", "Knobs" }
    };

    private List<BombImage> BombImageData = new List<BombImage>
    {
        new BombImage(0, new List<string>{ "Maze", "Venn" }),
        new BombImage(1, new List<string>{ "Wires" }),
        new BombImage(2, new List<string>{ "Button" }),
        new BombImage(3, new List<string>{ "Wires", "Keypad" }),
        new BombImage(4, new List<string>{ "Venn", "Maze", "Whos" }),
        new BombImage(5, new List<string>()),
        new BombImage(6, new List<string>{ "Whos", "Maze" }),
        new BombImage(7, new List<string>{ "Password" }),
        new BombImage(8, new List<string>{ "Morse", "Simon" }),
        new BombImage(9, new List<string>{ "Seq", "Venn" }),
        new BombImage(10, new List<string>{ "Venn", "Knob", "Simon" }),
        new BombImage(11, new List<string>{ "Button" }),
        new BombImage(12, new List<string>{ "Knob", "Maze", "Whos" }),
        new BombImage(13, new List<string>{ "Simon" }),
        new BombImage(14, new List<string>{ "Knob" }),
        new BombImage(15, new List<string>{ "Keypad", "Whos", "Venn" }),
        new BombImage(16, new List<string>{ "Memory", "Wires" }),
        new BombImage(17, new List<string>{ "Simon", "Whos", "Vent" }),
        new BombImage(18, new List<string>{ "Simon", "Venn", "Cap", "Button" }),
        new BombImage(19, new List<string>{ "Whos" }),
        new BombImage(20, new List<string>{ "Button", "Venn" }),
        new BombImage(21, new List<string>{ "Simon", "Password", "Knob" }),
        new BombImage(22, new List<string>{ "Morse" }),
        new BombImage(23, new List<string>{ "Password", "Seq", "Keypad", "Knob" }),
        new BombImage(24, new List<string>{ "Knob", "Button" }),
        new BombImage(25, new List<string>{ "Seq", "Morse", "Password" }),
        new BombImage(26, new List<string>{ "Keypad", "Wires", "Simon", "Password" }),
        new BombImage(27, new List<string>{ "Morse", "Wires", "Seq" }),
        new BombImage(28, new List<string>{ "Vent", "Button" }),
        new BombImage(29, new List<string>{ "Vent", "Morse", "Memory" }),
        new BombImage(30, new List<string>{ "Whos", "Password" }),
        new BombImage(31, new List<string>{ "Seq", "Wires" }),
        new BombImage(32, new List<string>{ "Venn", "Knob", "Button" }),
        new BombImage(33, new List<string>{ "Button", "Whos", "Morse", "Venn" }),
        new BombImage(34, new List<string>{ "Keypad" }),
        new BombImage(35, new List<string>{ "Simon", "Wires", "Button", "Whos" }),
        new BombImage(36, new List<string>{ "Seq" }),
        new BombImage(37, new List<string>{ "Simon", "Button", "Password", "Seq" }),
        new BombImage(38, new List<string>{ "Maze" }),
        new BombImage(39, new List<string>{ "Keypad", "Whos", "Memory" }),
        new BombImage(40, new List<string>{ "Morse", "Morse" }),
        new BombImage(41, new List<string>{ "Seq", "Whos", "Button" }),
        new BombImage(42, new List<string>{ "Morse", "Maze" }),
        new BombImage(43, new List<string>{ "Wires", "Whos", "Venn", "Maze" }),
        new BombImage(44, new List<string>{ "Simon" }),
        new BombImage(45, new List<string>{ "Whos", "Button", "Simon" }),
        new BombImage(46, new List<string>{ "Password", "Morse" }),
        new BombImage(47, new List<string>{ "Cap", "Button" }),
        new BombImage(48, new List<string>{ "Password", "Memory", "Venn" }),
        new BombImage(49, new List<string>{ "Knob", "Keypad", "Seq", "Whos" }),
        new BombImage(50, new List<string>{ "Wires" }),
        new BombImage(51, new List<string>{ "Morse", "Seq" }),
        new BombImage(52, new List<string>{ "Simon", "Knob", "Seq" }),
        new BombImage(53, new List<string>{ "Knob", "Keypad", "Button", "Maze" }),
        new BombImage(54, new List<string>{ "Memory" }),
        new BombImage(55, new List<string>{ "Wires", "Knob", "Venn", "Venn", "Morse" }),
        new BombImage(56, new List<string>{ "Wires", "Keypad" }),
        new BombImage(57, new List<string>{ "Vent", "Whos", "Memory" }),
        new BombImage(58, new List<string>{ "Knob", "Password" }),
        new BombImage(59, new List<string>{ "Password", "Morse", "Memory" }),
        new BombImage(60, new List<string>{ "Knob", "Memory", "Password", "Venn" }),
        new BombImage(61, new List<string>{ "Maze" }),
        new BombImage(62, new List<string>{ "Wires" }),
        new BombImage(63, new List<string>{ "Morse", "Simon", "Button", "Cap" })
    };

    private List<BombImage> CurrentImages = new List<BombImage>();
    private static readonly int MinRepetitions = 2;
    private static readonly int MaxRepetitions = 6;
    private int NumRepititions;

    private string CurrentModId;
    private List<bool> ButtonIsFading = new List<bool>();
    private List<bool> ButtonIsHighlighted = new List<bool>();

    private static int midCounter;
    private int mId;

	void Start()
    {
        mId = ++midCounter;

        MainStuff.SetActive(true);
        CheckArea.SetActive(false);
        AutoSolveText.SetActive(false);
        MainCheck.SetActive(false);
        foreach (GameObject check in CorrectChecks) check.SetActive(false);
        VerifyButton.OnInteract += OnVerify;
        List<string> possibleIDs = new List<string>();
        int i = 0;
        foreach (KMSelectable button in ImageButtons)
        {
            int y = i;
            ButtonIsFading.Add(false);
            ButtonIsHighlighted.Add(false);
            BombImage image = GetBombImage();
            button.GetComponent<Renderer>().material.mainTexture = BombImages[image.Index];
            CurrentImages.Add(image);
            possibleIDs.AddRange(image.Modules);

            Vector3 normalScale = new Vector3(0.005f, 0.02f, 0.005f);
            float normalPositionY = 0.0152f;
            BoxCollider collider = button.Highlight.GetComponent<BoxCollider>();
            Vector3 normalColScale = new Vector3(10f, 0.5f, 10f);
            button.OnHighlight += delegate
            {
                ButtonIsHighlighted[y] = true;
                if (ButtonIsFading[y]) return;
                button.transform.localScale = normalScale * 1.7f;
                button.transform.localPosition = new Vector3(button.transform.localPosition.x, normalPositionY + 0.004f, button.transform.localPosition.z);
                collider.size = 1f / 1.7f * normalColScale;
                collider.center = new Vector3(0f, collider.size.y / 2f, 0f);
            };
            button.OnHighlightEnded += delegate
            {
                ButtonIsHighlighted[y] = false;
                if (ButtonIsFading[y]) return;
                button.transform.localScale = normalScale;
                button.transform.localPosition = new Vector3(button.transform.localPosition.x, normalPositionY, button.transform.localPosition.z);
                collider.size = normalColScale;
                collider.center = new Vector3(0f, collider.size.y / 2f, 0f);
            };
            button.OnInteract += delegate
            {
                if (!ButtonIsFading[y] && !IsSolved)
                {
                    Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, button.transform);
                    button.AddInteractionPunch(1f);
                    bool IsCorrect = CurrentImages[y].Modules.Contains(CurrentModId);
                    Debug.LogFormat("[I'm Not a Robot #{0}] {1} image pressed. It {2} contain {3}.", mId, new string[6] { "First", "Second", "Third", "Fourth", "Fifth", "Sixth" }[y], IsCorrect ? "does" : "does not", Modules[CurrentModId]);
                    if (IsCorrect) StartCoroutine(FadeButton(y));
                    else Module.HandleStrike();
                }
                return false;
            };

            i++;
        }
        CurrentModId = possibleIDs.GroupBy(index => index).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();
        SearchText.text = Modules[CurrentModId].ToLower();
        Debug.LogFormat("[I'm Not a Robot #{0}] Selected module: {1}", mId, Modules[CurrentModId]);
        LogState();
    }

    void LogState()
    {
        Debug.LogFormat("[I'm Not a Robot #{0}] Current images: {1}", mId, string.Join(", ", CurrentImages.Select(i => i.Index + " (" + string.Join(", ", i.Modules.Select(m => Modules[m]).ToArray()) + ")").ToArray()));
    }

    IEnumerator FadeButton(int index)
    {
        ButtonIsFading[index] = true;
        CorrectChecks[index].SetActive(true);
        NumRepititions++;
        BombImage newImage = GetBombImage(NumRepititions < MinRepetitions || (NumRepititions <= MaxRepetitions && UnityEngine.Random.value > 0.7f) ? true : false);
        CurrentImages[index] = newImage;
        LogState();
        Transform trans = ImageButtons[index].transform;
        yield return new WaitForSeconds(0.4f);
        Vector3 originalScale = trans.localScale;
        float duration = 0.4f;

        float initialTime = Time.time;
        while (Time.time - initialTime < duration)
        {
            float lerp = (Time.time - initialTime) / duration;
            trans.localScale = originalScale * Mathf.SmoothStep(1f, 0f, lerp);
            yield return null;
        }

        CorrectChecks[index].SetActive(false);
        ImageButtons[index].GetComponent<Renderer>().material.mainTexture = BombImages[newImage.Index];

        Vector3 s = new Vector3(0.005f, 0.02f, 0.005f);
        initialTime = Time.time;
        while (Time.time - initialTime < duration)
        {
            float lerp = (Time.time - initialTime) / duration;
            trans.localScale = (ButtonIsHighlighted[index] ? s * 1.7f : s) * Mathf.SmoothStep(0f, 1f, lerp);
            yield return null;
        }
        ButtonIsFading[index] = false;
        if (ButtonIsHighlighted[index]) ImageButtons[index].OnHighlight();
        else ImageButtons[index].OnHighlightEnded();
        yield break;
    }

    private bool IsSolved;

    bool OnVerify()
    {
        Audio.PlayGameSoundAtTransform(KMSoundOverride.SoundEffect.ButtonPress, VerifyButton.transform);
        VerifyButton.AddInteractionPunch(1f);
        if (!IsSolved)
        {
            Debug.LogFormat("[I'm Not a Robot #{0}] Submit button pressed.", mId);
            bool IsCorrect = CurrentImages.All(i => !i.Modules.Contains(CurrentModId));
            if (IsCorrect)
            {
                Debug.LogFormat("[I'm Not a Robot #{0}] All images cleared, module is solved.", mId);
                IsSolved = true;
                MainStuff.SetActive(false);
                CheckArea.SetActive(true);
                Checkbox.SetActive(false);
                StartCoroutine(MainCheckAnim());
                Module.HandlePass();
            }
            else
            {
                Debug.LogFormat("[I'm Not a Robot #{0}] There are still {1} image(s) with {2} in them! Striking.", mId, CurrentImages.Count(i => i.Modules.Contains(CurrentModId)), Modules[CurrentModId]);
                Module.HandleStrike();
            }
        }
        return false;
    }

    IEnumerator MainCheckAnim()
    {
        int frame = 0;
        yield return null;
        MainCheck.SetActive(true);
        Material mat = MainCheck.GetComponent<Renderer>().material;
        yield return new WaitForSeconds(0.2f);
        while (frame <= 20)
        {
            mat.mainTextureOffset = new Vector2(0f, frame / -42f);
            frame++;
            yield return new WaitForSeconds(0.02f);
        }
    }

    BombImage GetBombImage(bool force = false)
    {
        IEnumerable<int> indexes = Enumerable.Range(0, BombImageData.Count);
        int index = force && BombImageData.Any(i => i.Modules.Contains(CurrentModId)) ? indexes.Where(i => BombImageData[i].Modules.Contains(CurrentModId)).PickRandom() : NumRepititions > MaxRepetitions ? indexes.Where(i => !BombImageData[i].Modules.Contains(CurrentModId)).PickRandom() : indexes.PickRandom();
        BombImage image = BombImageData[index];
        BombImageData.RemoveAt(index);
        return image;
    }

#pragma warning disable 414
    private readonly string TwitchHelpMessage = "!{0} select 1 2 4 | Once all images are cleared, use !{0} verify (or \"submit\")";
#pragma warning restore 414

    KMSelectable[] ProcessTwitchCommand(string command)
    {
        List<string> split = command.ToLowerInvariant().Split(' ').ToList();
        switch (split[0])
        {
            case "select":
                split.RemoveAt(0);
                List<int> buttons = new List<int>();
                foreach (string n in split)
                {
                    int number;
                    if (int.TryParse(n, out number))
                    {
                        int index = number - 1;
                        if (index > -1 && index < 6) buttons.Add(index);
                    }
                }
                return buttons.Distinct().Select(i => ImageButtons[i]).ToArray();
            case "verify":
            case "submit":
            case "enter":
                return new[] { VerifyButton };
        }
        return null;
    }

    IEnumerator TwitchHandleForcedSolve()
    {
        /* yield return null;
        if (!IsSolved)
        {
            IsSolved = true;
            MainStuff.SetActive(false);
            CheckArea.SetActive(true);
            AutoSolveText.SetActive(true);
            Checkbox.GetComponent<Renderer>().material.mainTexture = RedCheckbox;
            yield return new WaitForSeconds(5f);
            MainStuff.SetActive(true);
            CheckArea.SetActive(false);
            AutoSolveText.SetActive(false);
            IsSolved = false;
        } */
        yield return null;
        while (CurrentImages.Any(i => i.Modules.Contains(CurrentModId)))
        {
            foreach (KMSelectable button in Enumerable.Range(0, 6).Where(i => CurrentImages[i].Modules.Contains(CurrentModId)).Select(i => ImageButtons[i])) button.OnInteract();
            yield return new WaitForSeconds(1.5f);
        }
        VerifyButton.OnInteract();
    }
}
