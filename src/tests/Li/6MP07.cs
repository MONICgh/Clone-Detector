using System.Runtime.ExceptionServices;

ExceptionDispatchInfo dispatchInfo = null;

try
{
    int[] nums = {1, 2, 3};
    Console.WriteLine(nums[5]);
}
catch (IndexOutOfRangeException ex)
{
    Console.WriteLine(ex.Message);
    dispatchInfo = ExceptionDispatchInfo.Capture(ex);
}

try
{
    dispatchInfo?.Throw();
}
catch (IndexOutOfRangeException ex)
{
    Console.WriteLine(ex.Message);
}