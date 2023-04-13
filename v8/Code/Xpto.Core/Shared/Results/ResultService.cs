namespace Xpto.Core.Shared.Results
{
    public class ResultService : IResultService
    {
        public IList<string> Messages { get; set; }

        public ResultService()
        {
            this.Messages = new List<string>();
        }

        public void ClearMessages()
        {
            this.Messages = new List<string>();
        }
    }
}
