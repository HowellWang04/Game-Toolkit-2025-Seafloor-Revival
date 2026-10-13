using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResourceConst
{
    public static class Seahares
    {
        public const string Origin = "House";
        public const string CostType = "Food";
        public const int CostQuantity = 5;
        public const int CostTime = 0;
        public const int BuildSpeed = 5;
    }

    public static class TechPoints
    {
        public const string Origin = "Workshop";
        public const string CostType = "Glass";
        public const int CostQuantity = 2;
        public const int CostTime = 20;
        public const int BuildSpeed = 5;
    }

    public static class Food
    {
        public const string Origin = "-";
        public const string CostType = "-";
        public const int CostQuantity = 0;
        public const int CostTime = 0;
        public const int BuildSpeed = 0;
    }

    public static class Shell
    {
        public const string Origin = "-";
        public const string CostType = "-";
        public const int CostQuantity = 0;
        public const int CostTime = 0;
        public const int BuildSpeed = 0;
    }

    public static class Fuel
    {
        public const string Origin = "-";
        public const string CostType = "-";
        public const int CostQuantity = 0;
        public const int CostTime = 0;
        public const int BuildSpeed = 0;
    }

    public static class Glass
    {
        public const string Origin = "Shell";
        public const string CostType = "Fuel";
        public const int CostQuantity = 5;
        public const int CostQuantity2 = 2;
        public const int CostTime = 5;
        public const int BuildSpeed = 0;
    }
}
