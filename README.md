# File Organizer
A C# console app to organize files into subfolders (Images, Videos, Documents, Audio, Others) based on extensions defined in `FileExtensionsList.json`. Logs actions to `organizer_log.txt`.

## Features
- Organizes files by extension into category folders.
- Configurable via `FileExtensionsList.json`.
- Logs file movements and errors.

## Prerequisites
- .NET SDK (6.0+)
- Editor: Visual Studio or VS Code

## Setup
```bash
# Clone the repo
git clone https://github.com/your-username/file-organizer.git
cd file-organizer
```

Ensure `FileExtensionsList.json` exists in the project root.

```bash
# Restore and build
dotnet restore
dotnet build
```

## Usage
```bash
# Run the app
dotnet run
```

1. Enter the full path of the folder to organize.  
2. Files are moved to category subfolders.  
3. Check `organizer_log.txt` for details.

## Contributing
Fork, branch, commit, and open a pull request.

## License
MIT License.
