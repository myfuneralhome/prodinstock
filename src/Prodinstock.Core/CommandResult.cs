namespace Prodinstock.Core
{
    public sealed class CommandResult
    {
        public IEnumerable<string> Errors => _errors;

        private readonly IList<string> _errors;

        public CommandResult()
        {
            _errors = new List<string>();
        }

        public CommandResult(IEnumerable<string> errors)
        {
            _errors = errors.ToList();
        }

        public bool IsFullSuccess()
        {
            return !Errors.Any();
        }

        public void AddError(string error)
        {
            _errors.Add(error);
        }
    }
}