﻿namespace TeamcityTestingFramework.Api.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class OptionalAttribute : Attribute
    {
    }
}