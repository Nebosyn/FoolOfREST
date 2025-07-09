using System.Diagnostics;

internal class PythonLogger{

    public string PythonScriptPath {get; set;}
    public string PythonScriptDirectory {get;set;}
    public string PythonExecutablePath {get;set;}
    public Process? PythonProcess {get; init;}

    public PythonLogger(){
        string cwd = Directory.GetCurrentDirectory();
        PythonScriptDirectory = Path.Join(cwd, "TelegramLogger");
        PythonExecutablePath = Path.Join(PythonScriptDirectory, ".venv", "bin", "python");
        PythonScriptPath = Path.Join(PythonScriptDirectory, "main.py");
        ProcessStartInfo processInfo = new ProcessStartInfo{
            FileName = PythonExecutablePath,
            Arguments = PythonScriptPath,
            WorkingDirectory = PythonScriptDirectory,
        };
        PythonProcess = Process.Start(processInfo);

    }
}
