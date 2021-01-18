using System.Collections;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.Model
{
    public static class AnimationCounter
    { 
        #region VARIABLES
        
        private const int _duration = 2;
        
        #endregion
        
        public static IEnumerator CountTo(TMP_Text textValue, int target)
        {
            var start = int.Parse(textValue.text);
             
            for (float timer = 0; timer < _duration; timer += Time.deltaTime) {
                var progress = timer / _duration; 
                
                textValue.text = ((int)Mathf.Lerp (start, target, progress)).ToString();
                
                yield return null;
            }
            textValue.text = target.ToString();
        }
            
    }
}