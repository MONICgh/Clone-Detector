namespace RainWater;

public class RainWater
{
    public int CountVolume(int[] height)
    {
        int leftMax = 0;
        int rightMax = 0;
        int left = 0;
        int right = height.Length - 1;
        int volume = 0;
        while (left < right)
        {
            leftMax = Math.Max(leftMax, height[left]);
            rightMax = Math.Max(rightMax, height[right]);
            if (leftMax >= rightMax)
            {
                volume += rightMax - height[right];
                right--;
            }
            else
            {
                volume += leftMax - height[left];
                left++;
            }
        }

        return volume;
    }
}