# PlayerSkillValidator

A simple C# console application that validates player skill values using custom attributes and reflection.

---

## 📖 Overview
This project demonstrates how to define validation rules for player skills using the `[Skill]` attribute and verify those values dynamically at runtime.  
If any player's skill value is outside the allowed range, the program prints a detailed error including the player's name, the invalid field, and the accepted value range.

---

## ✨ Features
- Use of **custom attributes** to define skill validation ranges.  
- **Reflection-based validation** for flexibility and reusability.  
- **Detailed error messages** per player and property.  
- Easy to extend or integrate with larger systems.

---

## 🖼️ Example Output

When you run the program, you’ll see something like this:

<img width="1102" height="119" alt="image" src="https://github.com/user-attachments/assets/e3ad30a2-adbd-455e-a2da-b9d0c0df7aa4" />
