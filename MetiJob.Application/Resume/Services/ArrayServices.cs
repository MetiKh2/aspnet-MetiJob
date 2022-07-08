﻿
namespace MetiJob.Application.Resume.Services
{
    public static class ArrayServices
    {
        public static bool CheckSplitNull(string text)
        {
            var array = text.Split("/");
            if (array.Any(p => string.IsNullOrEmpty(p))) return false;
            return true;
        }
    }
}
