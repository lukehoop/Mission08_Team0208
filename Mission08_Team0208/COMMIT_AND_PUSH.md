# Commit and push to GitHub

## Folder structure (repo vs Cursor)

- **GitHub repo root** = the folder that contains `.git` and the **Mission08_Team0208** project folder.
- In your setup that is: `...\mission 8 please\Mission08_Team0208` (the outer folder).
- The **project** (`.csproj`, `Program.cs`, `Controllers/`, etc.) lives inside **Mission08_Team0208/Mission08_Team0208/**.
- Cursor may show paths with or without the inner `Mission08_Team0208/` prefix depending on which folder you opened as the workspace. Either way, **always run git from the repo root** (the folder that contains `.git`).

## Steps to commit and push

1. **Open a terminal in the repo root**  
   In Cursor: open the folder that contains `.git` and the inner `Mission08_Team0208` folder, then open Terminal (or run the commands below from that folder).

2. **Stage your changes**
   ```bash
   git add Mission08_Team0208/Controllers/HomeController.cs
   git add Mission08_Team0208/Program.cs
   git add Mission08_Team0208/Properties/launchSettings.json
   git add Mission08_Team0208/Views/Home/AddEdit.cshtml
   git add Mission08_Team0208/Views/Home/Delete.cshtml
   git add Mission08_Team0208/Views/Home/Quadrants.cshtml
   git add Mission08_Team0208/Views/Shared/_Layout.cshtml
   git add .gitignore
   ```
   Or stage everything (excluding ignored files like `tasks.db`):
   ```bash
   git add -A
   ```

3. **Commit**
   ```bash
   git commit -m "Fix build and runtime: controller, views, DB migration, category dropdown"
   ```

4. **Push**
   ```bash
   git push origin master
   ```
   (Use `main` instead of `master` if your default branch is `main`.)

## If you opened the inner project folder in Cursor

If your Cursor workspace is the **inner** `Mission08_Team0208` (the one with the `.csproj` inside it), then your repo root is the **parent** of that folder. In Terminal, go up one level and run git there:

```bash
cd ..
git status
git add -A
git commit -m "Your message"
git push origin master
```

## Optional: include .vscode (launch/tasks)

To commit the Cursor/VS Code run configs so others can F5 the same way:

```bash
git add .vscode/launch.json .vscode/tasks.json
git add Mission08_Team0208/.vscode/launch.json Mission08_Team0208/.vscode/tasks.json
```

Then commit and push as above.
