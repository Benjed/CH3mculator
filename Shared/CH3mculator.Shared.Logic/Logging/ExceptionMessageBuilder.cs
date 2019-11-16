using System;
using System.Text;

namespace CH3mculator.Shared.Logic.Logging
{
    public static class ExceptionMessageBuilder
    {
        public static string BuildExceptionMessage(Exception exception, string methodName = "", string lineNumber = "")
        {
            var exceptionTextBuilder = new StringBuilder();

            exceptionTextBuilder.AppendLine($"Exception thrown in {methodName}:{lineNumber} at {DateTime.Now.ToString("ddMMyyyy hh:mm:ss")}");
            exceptionTextBuilder.AppendLine($".NET Version: {Environment.Version}");
            exceptionTextBuilder.AppendLine("----------------------------------------------");
            AppendExceptiontext(exception, exceptionTextBuilder);

            return exceptionTextBuilder.ToString();
        }
        private static void AppendExceptiontext(Exception exception, StringBuilder exceptionTextBuilder)
        {
            exceptionTextBuilder.AppendLine(string.Concat("MESSAGE: ", exception.Message));
            exceptionTextBuilder.AppendLine(string.Concat("STACKTRACE: ", Environment.NewLine, exception.StackTrace));
            exceptionTextBuilder.AppendLine("----------------------------------------------");

            if (exception.InnerException != null)
                AppendExceptiontext(exception.InnerException, exceptionTextBuilder);
        }
    }
}
