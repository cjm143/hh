using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Extentions
{
    public static class Utilities
    {
        /*
            Example:

            public static Vector3 CalculatePositionOnCircle(Vector3 _center, float _angle, float _radius)
            {
                _angle = 270 - _angle;
                float angleRad = _angle * Mathf.Deg2Rad; // 도에서 라디안으로 변환
                float x = _center.x + _radius * Mathf.Cos(angleRad);
                float z = _center.z + _radius * Mathf.Sin(angleRad);

                return new Vector3(x, _center.y, z); // Y 좌표는 필요에 따라 조정
            }
        */

        // Int 값을 받아 제곱해 int 값을 리턴하는 메서드
        public static int IntPow(int x, uint pow)
        {
            int ret = 1;
            while (pow != 0)
            {
                if ((pow & 1) == 1)
                    ret *= x;
                x *= x;
                pow >>= 1;
            }
            return ret;
        }

        // 후에 추가 편집 예정
        // 위치로 받은 
        public static bool RotateCheck(Vector2Int checkPosition)
        {
            int rotateCount = 0;
            do
            {
                // 체크
                
            } while (rotateCount++ < 3);
            return false;
        }
    }
}
