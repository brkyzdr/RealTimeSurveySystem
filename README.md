===============================
RTSS - Real-Time Survey System
===============================

Unity Compatibility: 2D & 3D Projects & VR
Author: Berkay Ozder

-------------------------------
🔧 Overview
-------------------------------
RTSS is a modular, developer-friendly in-game survey system for Unity that allows testers to provide real-time feedback during gameplay. It is fully integrated with Google Forms and supports structured, centralized data collection without interrupting the playtest flow.

-------------------------------
🚀 Getting Started – Step by Step
-------------------------------

### ✅ 1. Setup Scenes
1. Add `LoginScene` as the first scene in Build Settings.
2. Add your test scene (e.g., `MainScene`) as the second scene.
3. On successful login, RTSS automatically loads the next scene.

---

### ✅ 2. Setup Google Form
1. Go to [Google Forms](https://forms.google.com) and create a new form.
2. Add one question per in-game question.
3. For each question:
   - Click the **3-dot menu** > **Get pre-filled link**
   - Fill in a dummy answer and click **Get link**
   - Copy the link → look for the parameter: `entry.xxxxxxxxxx`
     - Example: `entry.1234567890` → this is your **entry ID**
4. Also copy your **base form URL**, e.g.:  
   `https://docs.google.com/forms/d/e/.../viewform?usp=pp_url`  
   (⚠️ Do not include any `&entry=` or answers)

---

### ✅ 3. Assign Google Form to RTSS
1. Select the object with `SurveyManager.cs`
2. Paste your base form URL in the `Base Form URL` field
3. This URL will be used when submitting all answers

---

### ✅ 4. Create Questions with ScriptableObjects
1. Right-click in Project view → `Create > RTSS > Survey Question`
2. Fill in the fields:
   - Question Text
   - Entry ID (from step 2)
   - Question Type: Yes/No, Paragraph, or Scale
   - Mark as final question? (submits all answers)

---

### ✅ 5. Add Triggers to Scene
RTSS supports three trigger types:

| Trigger Type  |        Script        | Description 
|---------------|----------------------|-------------------------------
| Area Trigger  | `SurveyTriggerArea`  | Activates when player enters a zone 
| Timer Trigger | `SurveyTriggerTimer` | Activates after X minutes 
| Event Trigger | `SurveyTriggerEvent` | Activates from code (e.g., boss killed)

➡️ For each trigger:
- Attach the relevant trigger script to an empty GameObject
- Assign a `SurveyQuestionData` asset to it
- Set `pauseGameOnSurvey = true` if you want to pause gameplay

---

### ✅ 6. Link Player Settings
1. Ensure your player object:
   - Has the tag: `Player`
   - Uses `Rigidbody` (3D) or `Rigidbody2D` (2D)
2. Use colliders marked as `IsTrigger` for area-based triggers

---

### ✅ 7. Test and Build
- Run the game starting from `LoginScene`
- Log in with a valid tester username and password
- Play the game, trigger questions
- Final trigger submits all answers via browser redirect to Google Forms

---

### ✅ 8. Add Testers
1. In `LoginManager.cs`, you can add allowed testers via Inspector.
2. Each tester has:
   - Username
   - Password
3. Only registered testers can pass the login screen.

-------------------------------
📊 Question Types
-------------------------------
- Yes / No → two buttons  
- Paragraph → text input  
- Scale 1–10 → slider and label

-------------------------------
🎨 UI Features
-------------------------------
- Built using TextMeshPro
- Modern rounded panels and buttons
- Responsive layout (bottom-right position)
- Fade and transition ready

-------------------------------
⚠️ Notes
-------------------------------
- Do NOT include entry parameters in the base form URL
- All data is sent via `Application.OpenURL()` at once
- System stores answers locally until the final question is answered
- Compatible with both 2D and 3D physics

-------------------------------
📄 License
-------------------------------
Free for academic and non-commercial use.

TUBITAK 2209 A RESEARCH PROGRAM SUPPORT
