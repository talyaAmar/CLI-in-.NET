# Project 1 | CLI Application for Bundling Code Files

## Project Objective
This project involves the development of a CLI (Command Line Interface) tool designed to bundle multiple code files into a single file, aiming to make it easier for teachers to review students' projects quickly and efficiently.  
The tool is executed from the command line and automatically merges files based on the provided configurations.  
Instead of opening multiple folders and handling each file individually, the teacher can simply run the command, receive the merged file, and finish the task.

## Project Description
A **Console** application developed in C#, based on the **System.CommandLine** library, serving as a CLI tool for bundling code files into a single file (bundle).  
The tool allows filtering by programming language, removing empty lines, adding credit to the code author, logging the file source, and more. Additionally, the tool enables the automatic creation of a response file (.rsp) to simplify command execution.

## Technologies Used
- **Programming Language:** C#
- **Framework:** .NET Console App
- **CLI Framework:** System.CommandLine
- **Development Tools:** Visual Studio, Dotnet CLI

## Supported Commands

### `bundle`
Command for bundling code files in a folder into a single **bundle** file.

#### Supported Options:
- `--language / -l` – List of programming languages to include. **Required**. Special value: `all`.
- `--output / -o` – Name or path of the output file.
- `--note / -n` – Add a source note (name and relative path) for each file.
- `--sort / -s` – Sorting: by file name or by file type. Default: by file name.
- `--remove-empty-lines / -e` – Remove empty lines.
- `--author / -a` – Name of the author to be added as a comment at the top of the file.

### `create-rsp`
Command for creating a response file (`.rsp`) that contains the full `bundle` command.

This command performs an interactive process with the user:  
It asks the user to enter values for each option supported by the `bundle` command, then creates an `.rsp` file with the completed command.

#### Example usage with the response file:
```bash
dotnet @my-command.rsp
```
## Installation and Execution Instructions

### Project Creation
Create a **Console Application** project with as short a name as possible (e.g., `cb`), so that the command to run it is short.

### Installing System.CommandLine
1. Right-click on the project → **Manage NuGet Packages**.
2. Search for **System.CommandLine** under the **Browse** tab.
3. Install the package.

### Adding the Project to the PATH
1. **Publish the application:**
   ```bash
   dotnet publish -c Release -o publish
   ```
2. **Setting the PATH Environment Variable:**
   - Go to: Control Panel → System → Advanced System Settings → Environment Variables.
   - Edit the `Path` variable and add the path to the **publish** folder.

### Running Commands from Anywhere on the Computer
After setting the PATH, you can run the commands from any folder in CMD or PowerShel


----------------------------------------------------------------------------------------------------------------------------------------------------------------------------


# פרויקט 1 | אפליקציית CLI לאריזת קבצי קוד

## מטרת הפרויקט
במסגרת הפרויקט פותח כלי CLI (Command Line Interface) שמטרתו לארוז קבצי קוד מרובים לקובץ אחד מאוחד,
במטרה להקל על המורה לעבור על פרויקטים של תלמידות בצורה מהירה ונוחה. 
הכלי מופעל משורת הפקודה, ומבצע איחוד אוטומטי של קבצים לפי הגדרות המועברות לו.
במקום לפתוח תיקיות רבות ולטפל בכל קובץ בנפרד – המורה תוכל פשוט להריץ את הפקודה, לקבל קובץ מאוחד – ולסיים. 

## תיאור הפרויקט
אפליקציית **Console** בפיתוח C# המבוססת על הספרייה **System.CommandLine**, המשמשת ככלי CLI לאריזת קבצי קוד לקובץ אחד (bundle).
 הכלי מאפשר סינון לפי שפת תכנות, הסרת שורות ריקות, הוספת קרדיט ליוצר הקוד, רישום מקור הקובץ ועוד. בנוסף, הכלי מאפשר יצירה אוטומטית של קובץ תגובה (.rsp) לצורך הפשטת הרצת הפקודה.

## טכנולוגיות בשימוש
- **שפת פיתוח:** C#
- **תשתית:** .NET Console App
- **CLI Framework:** System.CommandLine
- **כלי פיתוח:** Visual Studio, Dotnet CLI

## פקודות נתמכות

 ### `bundle`
פקודה לאריזת קבצי קוד בתיקייה לקובץ **bundle** אחד.

#### אפשרויות נתמכות:

- `--language / -l` – רשימת שפות קוד שייכללו. **חובה**. ערך מיוחד: `all`.
- `--output / -o` – שם או נתיב הקובץ המיוצא.
- `--note / -n` – הוספת הערת מקור (שם ונתיב יחסי) לכל קובץ.
- `--sort / -s` – סדר: לפי שם קובץ או לפי סוג. ברירת מחדל: לפי שם קובץ.
- `--remove-empty-lines / -e` – מחיקת שורות ריקות.
- `--author / -a` – שם יוצר הקובץ שירשם כהערה בראש הקובץ.

### `create-rsp`
פקודה ליצירת קובץ תגובה (rsp) הכולל את פקודת ה-`bundle` המלאה.

הפקודה מבצעת תהליך אינטראקטיבי עם המשתמש:
מבקשת מהמשתמש להזין ערכים לכל אחת מהאפשרויות הנתמכות בפקודת `bundle`, ולאחר מכן יוצרת קובץ `.rsp` עם הפקודה המוכנה.

#### דוגמה לשימוש בקובץ:
```bash
dotnet @my-command.rsp
```
## הנחיות התקנה והרצה

### יצירת הפרויקט
פרויקט מסוג **Console Application** עם שם קצר ככל האפשר (למשל: `cb`), על מנת שהפקודה להרצה תהיה קצרה.

### התקנת System.CommandLine
1. לחצן ימני על הפרויקט → **Manage NuGet Packages**.
2. חפש את **System.CommandLine** בלשונית **Browse**.
3. התקן את החבילה.

### הוספת הפרויקט ל-PATH
1. **פרסם את האפליקציה:**
   ```bash
   dotnet publish -c Release -o publish
     ```
2. **הגדרת משתנה ה-PATH:**
- גש ל:לוח הבקרה → מערכת → הגדרות מערכת מתקדמות → משתני סביבה.
- ערוך את משתנה ה-`Path` והוסף את הנתיב לתיקיית **publish**.

### שימוש בפקודות מכל מקום במחשב
לאחר הגדרת ה-PATH, ניתן להריץ את הפקודות מכל תיקייה ב-CMD או ב-Powershell.




