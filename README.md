# Star Wars App

This repository contains two projects:

- **Front-End:** A Vue.js application located in the `frontend/star-wars-app` folder.
- **Back-End:** A .NET API project named **StarWarsApp_API**, located in `backend/StarWarsApp_API`.

---

## Repository Structure

```
.
├── frontend/               # Contains the front-end Vue app
│   ├── star-wars-app/      # Vue project
│   │   ├── .env-example
│   │   ├── .env           # Local environment settings (gitignored)
│   │   ├── src/
│   │   ├── public/
│   │   └── ...                
└── backend/                # Contains the back-end .NET API
    ├── StarWarsApp_API/    # .NET project
    │   ├── Controllers/
    │   ├── Services/
    │   └── ...
```

---

## Prerequisites

- **Node.js** (v12 or later) and **npm** for the Vue app.
- **.NET SDK** (v6 or later) for the API.
- Git

---

## Setup Instructions

### Front-End (Vue App)

1. **Clone the Repository:**
   ```bash
   git clone https://github.com/yourusername/yourrepo.git
   cd yourrepo/frontend/star-wars-app
   ```

2. **Install Dependencies:**
   ```bash
   npm install
   ```

3. **Configure Environment Variables:**
   - Copy `.env-example` to `.env`:
     ```bash
     cp .env-example .env
     ```
   - Open `.env` and update the API URL:
     ```env
     VUE_APP_API_URL=https://your-api-url-here
     ```

4. **Run the Application:**
   ```bash
   npm run serve
   ```

### Back-End (.NET API - StarWarsApp_API)

1. **Navigate to the API Directory:**
   ```bash
   cd ../../backend/StarWarsApp_API
   ```

2. **Restore Dependencies and Run:**
   ```bash
   dotnet restore
   dotnet run
   ```

---

## .gitignore Details

### For the Vue App (frontend/star-wars-app)

The following is included in your `.gitignore` to keep sensitive and build files out of Git:

```
# Environment file (keep local settings private)
.env

# Node modules and build output
node_modules/
dist/
build/

# Log files
npm-debug.log*
yarn-debug.log*
yarn-error.log*
coverage/

# Editor and OS specific files
.vscode/
.idea/
.DS_Store
```

### For the .NET API (backend/StarWarsApp_API)

Your `.gitignore` for the API project should include:

```
# Build output directories
bin/
obj/

# Visual Studio temporary files and user settings
.vs/
*.user
*.suo

# ASP.NET temporary files
wwwroot/

# Editor-specific files
.vscode/

# Log files
*.log
```

---

## Editor Settings

- **VS Code:**  
  The `.vscode/` folder is typically gitignored to prevent sharing personal settings. If you have project-wide configurations (e.g., launch settings), consider providing an example file (like `settings.example.json`) instead of sharing your personal settings.

---

## Additional Notes

- **CORS Configuration:**  
  The .NET API is currently set to allow requests from `http://localhost:8080` during development. Before deploying to production, update the CORS settings in `Program.cs` to allow requests from your production domain.

- **CI/CD:**  
  You can set up GitHub Actions (or another CI/CD tool) to automate builds, tests, and deployments for both the front-end and back-end projects.

Happy coding!

