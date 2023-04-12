namespace Xpto.Core.Shared.Results;

public interface IResultService
{
    IList<string> Messages { get; set; }
    void ClearMessages();
}