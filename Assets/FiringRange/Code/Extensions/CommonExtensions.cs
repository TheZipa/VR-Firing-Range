using System;
using Newtonsoft.Json;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FiringRange.Code.Extensions
{
    public static class CommonExtensions
    {
        public static T With<T>(this T self, Action<T> set)
        {
            set.Invoke(self);
            return self;
        }
        
        public static T With<T>(this T self, Action<T> apply, Func<bool> when)
        {
            if(when()) apply.Invoke(self);
            return self;
        }
        
        public static T With<T>(this T self, Action<T> apply, bool when)
        {
            if(when) apply.Invoke(self);
            return self;
        }

        public static float GetRandomInVector(this Vector2 vector) => Random.Range(vector.x, vector.y);
        
        public static T ToDeserialized<T>(this string json) => JsonConvert.DeserializeObject<T>(json);

        public static string ToJson(this object obj) => JsonConvert.SerializeObject(obj);
    }
}