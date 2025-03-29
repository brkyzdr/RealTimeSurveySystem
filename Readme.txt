===============================
RTSS - Real-Time Survey System
===============================

Version: 1.0  
Unity Compatibility: 2D & 3D Projects  
Author: Berkay Özder

-------------------------------
🔧 Overview
-------------------------------
RTSS is a lightweight, developer-friendly in-game survey system for Unity that allows testers to provide real-time feedback during gameplay. It is fully integrated with Google Forms and designed for efficient and structured playtesting.

-------------------------------
📦 Installation
-------------------------------
1. Import the RTSS folder into your Unity project.
2. Add "RTSS_Canvas.prefab" and at least one "RTSS_Trigger.prefab" to your scene.
3. Ensure the player object has the tag "Player" and a Rigidbody2D or Rigidbody component.
4. In each trigger, assign the survey question, Google Form entry ID, and other settings via the Inspector.

-------------------------------
▶️ How It Works
-------------------------------
- When the player enters a trigger zone, the game pauses and a survey question appears.
- After answering, the game resumes.
- RTSS stores all answers locally during gameplay.
- When the final trigger is reached, all answers are submitted at once to a Google Form via a single redirect.

-------------------------------
✅ Supported Question Types
-------------------------------
1. Yes / No  
2. Paragraph (free text)  
3. Scale (1–10)

-------------------------------
⚠️ Notes
-------------------------------
- Each question must have a corresponding "entry ID" from the target Google Form.
- The base form URL must not include any entry parameters (should end before &entry=).
- RTSS works with both 2D and 3D physics. Be sure to use appropriate colliders and "Is Trigger" settings.
- The system submits all answers only once, via the final trigger.

