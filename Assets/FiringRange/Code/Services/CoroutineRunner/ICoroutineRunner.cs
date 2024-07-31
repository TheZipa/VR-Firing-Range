using System.Collections;
using UnityEngine;

namespace FiringRange.Code.Services.CoroutineRunner
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator routine);
    }
}