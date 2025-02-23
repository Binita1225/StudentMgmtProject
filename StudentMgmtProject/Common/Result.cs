namespace StudentMgmtProject.Common
{
    public class Result<t>
    {
        public t? Data { get; set; }
        public Status Status { get; set; }
        public string Message { get; set; }
    }

    public enum Status
    {
        Success,
        Error,
        Failure
    }
}
