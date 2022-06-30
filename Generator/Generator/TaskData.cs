namespace Generator
{
    public class TaskData
    {
        public string Header { get; set; }
        public string Description { get; set; }
        public TaskData() { }
        public TaskData(string Header, string Description)
        {
            this.Header = Header;
            this.Description = Description;
        }

    }
}
