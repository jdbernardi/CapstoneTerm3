﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ProportionValue<T>
{
    public double Proportion { get; set; }
    public T Value { get; set; }
}

public static class ProportionValue
{
    public static ProportionValue<T> Create<T>(double proportion, T value)
    {
        return new ProportionValue<T> { Proportion = proportion, Value = value };
    }

    static System.Random random = new System.Random();
    public static T ChooseByRandom<T>(
        this IEnumerable<ProportionValue<T>> collection)
    {
        var rnd = random.NextDouble();
        foreach (var item in collection)
        {
            if (rnd < item.Proportion)
                return item.Value;
            rnd -= item.Proportion;
        }
        throw new Exception(
            "The proportions in the collection do not add up to 1.");
    }
}
