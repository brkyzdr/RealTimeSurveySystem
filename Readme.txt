# RTSS - Real-Time Survey System

**RTSS** is an in-game survey system for Unity that allows testers to provide real-time feedback during gameplay. Designed with Google Forms integration, it ensures structured and centralized data collection without interrupting the playtest flow.

---

## 🔧 Features

- 🎮 In-game survey UI (non-intrusive)
- 🧩 Supports **Yes/No**, **Paragraph**, and **Scale (1–10)** question types
- ⏸️ Pauses the game during survey interaction
- 📊 Google Forms integration (all responses submitted in one final step)
- ⚙️ Works with both **2D** and **3D** Unity projects
- 🪄 Plug-and-play with ready-to-use prefabs

---

## 📦 Installation

1. Clone or download this repository into your Unity project.
2. Drag `RTSSCanvas.prefab` into your scene.
3. Add one or more `RTSSTrigger.prefab` objects where you want survey questions to appear.
4. Make sure your player object is tagged as `"Player"` and has a `Rigidbody` or `Rigidbody2D`.
5. In each trigger, set:
   - The question text  
   - The corresponding Google Forms entry ID  
   - Mark one trigger as the final one (`isFinalTrigger = true`)  

---

## ▶️ How It Works

- Each trigger displays a survey question during gameplay.
- The game pauses until a response is provided.
- All responses are collected locally.
- When the final trigger is activated, all answers are submitted to the linked Google Form in one batch.

---

## ✅ Supported Question Types

- Yes / No  
- Paragraph  
- Scale (1–10)

---

## 📌 Google Forms Setup

- Use "Get pre-filled link" in Google Forms to find each question's `entry.ID`.
- Copy the base form URL (excluding any `entry=...`).
- Assign each survey question a unique entry ID via the trigger Inspector.

> Note: Due to Google Forms security, Unity cannot send answers directly via HTTP POST. Therefore, responses are submitted by opening a browser with pre-filled answers using `Application.OpenURL()`.
