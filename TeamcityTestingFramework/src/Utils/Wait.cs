using System.Diagnostics;
using TeamcityTestingFramework.src.Exceptions;

namespace TeamcityTestingFramework.src.Utils
{
    public class Wait
    {
        public static T UntilActionIsFinished<T>(Func<T> condition, int timeoutMilliseconds = 50000, int delayIntervalMilliseconds = 500)
        {
            return UntilActionIsFinishedInternal(condition, string.Empty, timeoutMilliseconds, delayIntervalMilliseconds);
        }

        public static T UntilActionIsFinished<T>(Func<T> condition, string customerExceptionMessage,
            int timeoutMilliseconds = 50000, int delayIntervalMilliseconds = 500)
        {
            return UntilActionIsFinishedInternal(condition, customerExceptionMessage, timeoutMilliseconds, delayIntervalMilliseconds);
        }

        private static T UntilActionIsFinishedInternal<T>(Func<T> condition, string customExceptionMessage,
            int timeoutMilliseconds = 50000, int delayIntervalMilliseconds = 500)
        {
            var returnType = typeof(T);
            Exception innerException = null;

            var watch = new Stopwatch();
            watch.Start();
            while (watch.ElapsedMilliseconds < timeoutMilliseconds)
            {
                try
                {
                    T result = condition();
                    if (returnType == typeof(bool))
                    {
                        var booleanResult = result as bool?;
                        if (booleanResult.HasValue)
                        {
                            if (booleanResult.Value)
                            {
                                watch.Stop();
                                return result;
                            }
                        }
                    }
                    else if (result != null)
                    {
                        watch.Stop();
                        return result;
                    }
                }
                catch (StopRetryException stopException)
                {
                    throw stopException;
                }
                catch (Exception e)
                {
                    innerException = e;
                }

                Thread.Sleep(delayIntervalMilliseconds);
            }

            watch.Stop();

            var exceptionMessage = string.IsNullOrEmpty(customExceptionMessage)
                ? $"Action was not finished within '{timeoutMilliseconds}' milliseconds\n"
                : $"{customExceptionMessage}\nAction was not finished within '{timeoutMilliseconds}' milliseconds\n";

            throw new TimeoutException(exceptionMessage, innerException);
        }
    }
}
