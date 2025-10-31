RTSS - Real-Time Survey System
===============================
Unity Compatibility: 2D & 3D Projects & VR  
Developer: Berkay Ozder  
Download RTSS v0.5 UnityPackage  
[Download from Releases](https://github.com/brkyzdr/RealTimeSurveySystem/releases)
-------------------------------
🔧 Overview
-------------------------------
RTSS is a modular, developer-friendly in-game survey system for Unity that allows testers to provide real-time feedback during gameplay.  
It is fully integrated with Google Forms and supports structured, centralized data collection without interrupting the test flow.  
RTSS includes a login system, 3 flexible trigger types, centralized question management via ScriptableObjects, and a modern, responsive UI.

---

Getting Started – Step by Step
-------------------------------

### 1. Setup Scenes
1. Add `LoginScene` as the first scene in Build Settings.
2. Add your test/demo scene (e.g., `DemoScene`) as the second.
3. After successful login, RTSS will automatically load the next scene.

---

### 2. Setup Google Form
1. Go to [Google Forms](https://forms.google.com) and create a new form.
2. Add one question per in-game question.
3. For each question:
   - Click the **3-dot menu** > **Get pre-filled link**
   - Fill in a dummy answer and click **Get link**
   - Copy the link → look for the parameter: `entry.xxxxxxxxxx`
     - Example: `entry.1234567890` → this is your **entry ID**
4. Also copy your **base form URL**, for example:  
   `https://docs.google.com/forms/d/e/.../viewform?usp=pp_url`  
   Do not include any `&entry=` or response data.

> **Important:** In Yes/No questions, make sure the answer options are written exactly as `"Yes"` and `"No"` (case-sensitive). These values must match what RTSS sends.

---

### 3. Assign Google Form to RTSS
1. Select the object with the `SurveyManager` script.
2. Paste your base form URL in the `Base Form URL` field.
3. RTSS will append all collected entries to this URL upon submission.

---

### 4. Create Questions with ScriptableObjects
1. Right-click in the Project panel → `Create > RTSS > Survey Question`
2. For each question:
   - Set `Question Text`
   - Set `Entry ID` (from your form)
   - Choose `Question Type` (Yes/No, Paragraph, Scale)
   - Enable `Is Final Question` if this should trigger Google Form submission

---

### 5. Add Triggers to Scene
RTSS supports three trigger types:

| Trigger Type  |        Script        | Description |
|---------------|----------------------|-------------|
| Area Trigger  | `SurveyTriggerArea`  | Triggered when player enters a zone |
| Timer Trigger | `SurveyTriggerTimer` | Triggered after X minutes |
| Event Trigger | `SurveyTriggerEvent` | Triggered manually via code |

For each trigger:
- Add the corresponding script to a GameObject
- Assign a `SurveyQuestionData` asset
- Enable `pauseGameOnSurvey` if you want the game to pause while answering

---

### 6. Link Player Settings
- Player must be tagged as `"Player"`
- Attach a `Rigidbody` (3D) or `Rigidbody2D` (2D)
- Ensure colliders are marked as `IsTrigger` for trigger-based activation

---

### 7. Test and Build
- Run the project starting from `LoginScene`
- Login with a valid tester username/password
- Answer questions as you play
- Final question will trigger submission via browser to Google Forms

---

### 8. Add Testers
1. Select the object with the `LoginManager` script.
2. Add tester accounts via Inspector:
   - Username
   - Password
3. Only listed testers will be able to proceed past login.

---

Question Types
-------------------------------
- Yes / No → Button-based choice  
- Paragraph → Free text input  
- Scale 1–10 → Slider with numeric value

---

UI Features
-------------------------------
- Built entirely with TextMeshPro
- Modern rounded panels and clean font
- Responsive layout (default: bottom-right screen position)
- Works across resolutions and supports fade-in animations

---

Notes
-------------------------------
- Use exact answer strings in the Google Form (e.g., “Yes”, “No”)
- Don’t include entry parameters in your base form URL
- All responses are sent once, after the final question
- RTSS works in both 2D and 3D physics environments
- Add `RTSSCanvas` prefabs if not already in your scene

---

License
-------------------------------
Free for academic and non-commercial use.  
Supported by TÜBİTAK 2209-A Research Program.
