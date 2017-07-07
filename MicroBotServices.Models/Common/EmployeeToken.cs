namespace MicroBotServices.Models.Common
{
    public class EmployeeToken
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public bool Active { get; set; }
        public string Type { get; set; }
    }
}
