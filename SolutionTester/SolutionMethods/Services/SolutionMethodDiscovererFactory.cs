﻿using System.Reflection;

namespace CCHelper;

internal static class SolutionMethodDiscovererFactory
{
    internal static SolutionMethod SearchSolutionContainer(object solutionContainer)
    {
        var singleSolutionMethod = solutionContainer.DiscoverSolutionMethod();
        if (singleSolutionMethod.IsOutputSolution()) return new OutputSolution(singleSolutionMethod, solutionContainer);
        if (singleSolutionMethod.IsInputSolution()) return new InputSolution(singleSolutionMethod, solutionContainer);
        throw new ApplicationException("Something went wrong when trying to detect the solution method.");
    }
    static MethodInfo DiscoverSolutionMethod(this object container)
    {
        return GetSingleSolutionInContainerOrThrow(container);
    }
    static MethodInfo GetSingleSolutionInContainerOrThrow(object container)
    {
        var validSolutionMethods = container.RetrieveValidSolutionMethods();

        if (!validSolutionMethods.Any()) throw new EntryPointNotFoundException("Solution method was not found inside the provided solution container.");
        if (validSolutionMethods.Count() > 1) throw new AmbiguousMatchException("Solution container must contain exactly one solution method.");

        return validSolutionMethods.Single();
    }
}