internal class ApiKey(){
    public static string Read(){
        string apiKey = "";
        string path = Path.Join(Path.GetTempPath(),"ApiKey");
        if (!Path.Exists(path)){throw new FileNotFoundException("File with ApiKey wasn't found.");}
        using (StreamReader sr = File.OpenText(path)){
            apiKey = sr.ReadToEnd();
        }
        return apiKey;
    } 
}
