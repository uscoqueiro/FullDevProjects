namespace Xpto.Core.Shared.Results
{
    public class ResultService : IResultService
    {
        public IList<string> Messages { get; set; }

        public void ClearMessages()
        {
            this.Messages = new List<string>();
        }
    }
}
