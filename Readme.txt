===============================
RTSS - Real-Time Survey System
===============================

Version: 2.0  
Unity Compatibility: 2D & 3D Projects  
Author: Berkay Özder

-------------------------------
🔧 Overview
-------------------------------
RTSS is a modular, developer-friendly in-game survey system for Unity that allows testers to provide real-time feedback during gameplay. It is fully integrated with Google Forms and supports structured, centralized data collection without interrupting the test flow. It now includes ScriptableObject-based question management and supports multiple trigger types for flexible use in any game.

-------------------------------
📦 Installation
-------------------------------
1. Import the RTSS folder into your Unity project.
2. Add `RTSS_Canvas.prefab` to your scene.
3. Add any of the following trigger prefabs depending on how you want to ask questions:
   - `SurveyTriggerArea` → Triggers on player collision
   - `SurveyTriggerTimer` → Triggers after a delay
   - `SurveyTriggerEvent` → Triggers manually via script
4. Create one or more `SurveyQuestionData` assets (Right-click → Create → RTSS → Survey Question).
5. Assign a `SurveyQuestionData` asset to each trigger.
6. Make sure your player object:
   - Has the tag `Player`
   - Has a Rigidbody (3D) or Rigidbody2D (2D) depending on your project type

-------------------------------
▶️ How It Works
-------------------------------
- A survey is triggered based on area, time, or in-game events.
- The game pauses while the survey UI is displayed.
- Testers answer the question using one of the available formats.
- RTSS stores answers locally during gameplay.
- When the final question is answered, all responses are sent at once to a Google Form via a single redirect.

-------------------------------
✅ Supported Question Types
-------------------------------
1. Yes / No  
2. Paragraph (free text)  
3. Scale (1–10)

-------------------------------
🧠 Data Handling
-------------------------------
- Survey questions are managed via `ScriptableObject` assets (`SurveyQuestionData`).
- Each question includes its display text, Google Forms entry ID, and its type.
- Final trigger flag determines when the answers are submitted.

-------------------------------
⚙️ Trigger Types
-------------------------------
- `SurveyTriggerArea`: Triggered when player enters a collider zone.
- `SurveyTriggerTimer`: Triggered after X seconds.
- `SurveyTriggerEvent`: Triggered manually by calling `TriggerSurveyExternally()`.

-------------------------------
⚠️ Notes
-------------------------------
- Each question must match a corresponding entry ID in your Google Form.
- The base form URL must not include `&entry=` or answer data — RTSS appends it automatically.
- RTSS works seamlessly in both 2D and 3D projects.
- Make sure to use correct collider + rigidbody pairs based on your project type.

-------------------------------
📄 License
-------------------------------
Free for academic and non-commercial use.

