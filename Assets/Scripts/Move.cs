using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
	private Vector3 _vec3TargetScreenSpace;// Ŀ���������Ļ�ռ�����
	private Vector3 _vec3TargetWorldSpace;// Ŀ�����������ռ�����
	private Transform _trans;// Ŀ������Ŀռ�任���
	private Vector3 _vec3MouseScreenSpace;// ������Ļ�ռ�����
	private Vector3 _vec3Offset;// ƫ��
	private float y = 0.892f;
	private float z = -0.56f;
	void Awake() { _trans = transform; }

	IEnumerator OnMouseDown()

	{
		Debug.Log("in onmousedonw");
		// ��Ŀ�����������ռ�����ת�������������Ļ�ռ����� 

		_vec3TargetScreenSpace = Camera.main.WorldToScreenPoint(_trans.position);

		// �洢������Ļ�ռ����꣨Zֵʹ��Ŀ���������Ļ�ռ����꣩ 

		_vec3MouseScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _vec3TargetScreenSpace.z);

		// ����Ŀ���������������������ռ��е�ƫ���� 

		_vec3Offset = _trans.position - Camera.main.ScreenToWorldPoint(_vec3MouseScreenSpace);

		// ���������� 

		while (Input.GetMouseButton(0))
		{
			Debug.Log("getmousebutton");
			// �洢������Ļ�ռ����꣨Zֵʹ��Ŀ���������Ļ�ռ����꣩

			_vec3MouseScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _vec3TargetScreenSpace.z);

			// ��������Ļ�ռ�����ת��������ռ����꣨Zֵʹ��Ŀ���������Ļ�ռ����꣩������ƫ�������Դ���ΪĿ�����������ռ�����

			_vec3TargetWorldSpace = Camera.main.ScreenToWorldPoint(_vec3MouseScreenSpace) + _vec3Offset;

			// ����Ŀ�����������ռ����� 
			if (_vec3TargetWorldSpace.x > 1.5f)
			{
				_vec3TargetWorldSpace.x = 1.5f;

			}
			if (_vec3TargetWorldSpace.x < 0f)
			{
				_vec3TargetWorldSpace.x = 0f;

			}
			_trans.position = new Vector3(_vec3TargetWorldSpace.x, y, z);

			// �ȴ��̶����� 

			yield return new WaitForFixedUpdate();
		}
	}
}
