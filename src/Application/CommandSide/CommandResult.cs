namespace Application.CommandSide
{
    public class CommandResult
    {
        public CommandResult(bool success, string message, ErrorTypes? errorType)
        {
            Success = success;
            Message = message;
            ErrorType = errorType;
        }

        public CommandResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; internal set; }

        public string Message { get; internal set; }

        public ErrorTypes? ErrorType { get; internal set; }

        public static CommandResult Ok(string message)
        {
            return new CommandResult(true, message);
        }

        public static CommandResult NotFound(string message)
        {
            return new CommandResult(false, message, ErrorTypes.NotFound);
        }

        public static CommandResult BadRequest(string message)
        {
            return new CommandResult(false, message, ErrorTypes.BadRequest);
        }

        public enum ErrorTypes
        {
            BadRequest,
            NotFound
        }
    }
}
