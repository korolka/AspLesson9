namespace AspLesson9.Services
{
    public class Saver
    {
        string path = "App_data/NameAction.txt";
        public void SaveActionName(string actionName,DateTime time)
        {
            StreamWriter streamWriter = new StreamWriter(path, true);
            streamWriter.WriteLine(actionName+" "+time.ToString("t"));
            streamWriter.WriteLine();
            streamWriter.Close();
        }
    }
}
