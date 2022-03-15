﻿namespace CCEasy;

/// <summary>
/// Labels a solution method that provides its result in one of the parameters.
/// </summary>
[AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
public class ResultAttribute : Attribute
{
}